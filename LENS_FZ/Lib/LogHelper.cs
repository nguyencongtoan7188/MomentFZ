using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LENS_FZ
{
    /// <summary>
    /// 多线程安全Log记录工具20180314
    /// </summary>
    public class LogHelper
    {
        private static Thread WriteThread;
        private static readonly Queue<string> MsgQueue;

        private static readonly string FilePath;

        private static Boolean autoResetEventFlag = false;
        private static AutoResetEvent aEvent = new AutoResetEvent(false);
        private static bool flag = true;
        public static bool LogFlag = true;

        static LogHelper()
        {
            FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "App_Log\\";
            WriteThread = new Thread(WriteMsg);
            MsgQueue = new Queue<string>();
            WriteThread.Start();
        }

        public static void LogInfo(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Info", msg));
            Monitor.Exit(MsgQueue);
            if (autoResetEventFlag)
            {
                aEvent.Set();
            }
        }
        public static void LogError(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Error", msg));
            Monitor.Exit(MsgQueue);
            if (autoResetEventFlag)
            {
                aEvent.Set();
            }
        }
        public static void LogWarn(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"), "Warn", msg));
            Monitor.Exit(MsgQueue);
            if (autoResetEventFlag)
            {
                aEvent.Set();
            }
        }

        /// <summary>
        /// ExitThread là một phương thức để thoát khỏi chuỗi ghi nhật ký. Sau khi thoát, nó không thể mở được. Nó thường được thực thi khi đóng chương trình
        /// </summary>
        public static void ExitThread()
        {
            flag = false;
            aEvent.Set();
        }

        private static void WriteMsg()
        {
            while (flag)
            {
                //Write
                if (LogFlag)
                {
                    autoResetEventFlag = false;
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                    string fileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + "-Dic.log";
                    var logStreamWriter = new StreamWriter(fileName, true);
                    while (MsgQueue.Count > 0)
                    {
                        Monitor.Enter(MsgQueue);
                        string msg = MsgQueue.Dequeue();
                        Monitor.Exit(MsgQueue);
                        logStreamWriter.WriteLine(msg);
                        if (GetFileSize(fileName) > 1024 * 5)
                        {
                            logStreamWriter.Flush();
                            logStreamWriter.Close();
                            CopyToBak(fileName);
                            logStreamWriter = new StreamWriter(fileName, false);
                            logStreamWriter.Write("");
                            logStreamWriter.Flush();
                            logStreamWriter.Close();
                            logStreamWriter = new StreamWriter(fileName, true);
                        }
                        System.Diagnostics.Debug.WriteLine("BS_Debug:" + msg);
                        System.Diagnostics.Trace.WriteLine("BS_Release:" + msg);
                    }
                    logStreamWriter.Flush();
                    logStreamWriter.Close();
                    autoResetEventFlag = true;
                    aEvent.WaitOne();
                }
                else
                {
                    autoResetEventFlag = true;
                    aEvent.WaitOne();
                }
            }
        }
        private static long GetFileSize(string fileName)
        {
            long strRe = 0;
            if (File.Exists(fileName))
            {
                var myFs = new FileInfo(fileName);
                strRe = myFs.Length / 1024;
            }
            return strRe;
        }
        private static void CopyToBak(string sFileName)
        {
            int fileCount = 0;
            string sBakName = "";
            do
            {
                fileCount++;
                sBakName = sFileName + "." + fileCount + ".BAK";
            }
            while (File.Exists(sBakName));
            File.Copy(sFileName, sBakName);
        }
    }
}
