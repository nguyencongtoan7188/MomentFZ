using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using MySql.Data.MySqlClient;
using PublicClass;

namespace Updata
{
    public class Updata
    {
        private static System.Timers.Timer aTimer;

        private static int atimerInterval;

        private static string AccessPassword;

        private static string AccessPath;

        public static int TablesNum;

        public static int WhichTables;

        public static string WhichAccessPath;

        private static string UpdataLogFilePath = Environment.CurrentDirectory + "\\UpdataLog.txt";

        public static int jitai;

        public static string MysqlTableName;

        public static string MysqlIP;

        public static string MysqlUsername;

        public static string MysqlPassword;

        public static string MysqlDatabaseName;

        private static MySqlConnection conn = null;

        public static bool Updataflag = false;

        private static List<string> TableList = new List<string>();

        private static object obj = new object();

        public static void Start()
        {
            SetTimer();
        }

        public static void Stop()
        {
            aTimer.Stop();
        }

        public static void SetTimer()
        {
            try
            {
                atimerInterval = Convert.ToInt32(GetINI("setting", "atimerInterval", "", Environment.CurrentDirectory + "\\setting.ini").Trim());
                aTimer = new System.Timers.Timer(atimerInterval);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Start();
            }
            catch (Exception ex)
            {
                WriteLog("SetTimer", ex.ToString());
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                GetINI();
                bool netflag = PingHelper.Ping(MysqlIP);
                if (netflag == true)
                {
                    DataSet dataSet = new DataSet();
                    for (int i = 0; i < TableList.Count; i++)
                    {
                        if (!Updataflag)
                        {
                            Updataflag = true;
                            string[] array = TableList[i].Split(',');
                            if (array[0] == "" || array[1] == "")
                            {
                                Updataflag = false;
                                continue;
                            }
                            WhichAccessPath = array[0];
                            dataSet = getAccessDataset("SELECT * FROM [temp] order by [ID] desc", array[0]);
                            UpMdbData(dataSet, array[1]);
                            Updataflag = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("OnTimedEvent", ex.ToString());
                Stop();
            }
        }

        private static void GetINI()
        {
            TablesNum = Convert.ToInt32(GetINI("setting", "TablesNum", "", Environment.CurrentDirectory + "\\setting.ini").Trim());
            TableList.Clear();
            for (int i = 1; i <= TablesNum; i++)
            {
                string key = "AccessPath" + i;
                string key2 = "MysqlTableName" + i;
                AccessPath = GetINI("setting", key, "", Environment.CurrentDirectory + "\\setting.ini").Trim();
                MysqlTableName = GetINI("setting", key2, "", Environment.CurrentDirectory + "\\setting.ini").Trim();
                TableList.Add(AccessPath + "," + MysqlTableName);
            }
            AccessPassword = GetINI("setting", "AccessPassword", "", Environment.CurrentDirectory + "\\setting.ini").Trim();
            MysqlIP = GetINI("setting", "MysqlIP", "", Environment.CurrentDirectory + "\\setting.ini").Trim();
            MysqlUsername = GetINI("setting", "MysqlUsername", "", Environment.CurrentDirectory + "\\setting.ini").Trim();
            MysqlPassword = GetINI("setting", "MysqlPassword", "", Environment.CurrentDirectory + "\\setting.ini").Trim();
            MysqlDatabaseName = GetINI("setting", "MysqlDatabaseName", "", Environment.CurrentDirectory + "\\setting.ini").Trim();
        }

        public static void UpMdbData(DataSet DT, string mysqltablename)
        {
            try
            {
                if (DT.Tables[0].Rows.Count <= 0)
                {
                    return;
                }
                int count = DT.Tables[0].Columns.Count;
                int num = 0;
                string[] array = new string[count];
                num = ((DT.Tables[0].Rows.Count < 100) ? DT.Tables[0].Rows.Count : 100);
                List<string> list = new List<string>();
                if (!connect())
                {
                    return;
                }
                for (int i = 0; i <= num - 1; i++)
                {
                    int num2 = Convert.ToInt32(DT.Tables[0].Rows[i].ItemArray[0]);
                    array[0] = num2.ToString();
                    for (int j = 1; j <= array.GetUpperBound(0); j++)
                    {
                        array[j] = "," + DT.Tables[0].Rows[i].ItemArray[j].ToString();
                        if (DT.Tables[0].Rows[i].ItemArray[j].GetType() == Type.GetType("System.DateTime"))
                        {
                            //array[j] = "," + string.Format(DT.Tables[0].Rows[i].ItemArray[j].ToString(), "yyyy/MM/dd HH:mm:ss");
                            DateTime datetime = Convert.ToDateTime(DT.Tables[0].Rows[i].ItemArray[j].ToString());
                            array[j] = "," + datetime.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                    }
                    string text = "";
                    for (int k = 0; k < count; k++)
                    {
                        text += array[k];
                    }
                    if (SendDataToMysql(text, mysqltablename))
                    {
                        list.Add(num2 + "," + WhichAccessPath);
                    }
                }
                conn.Close();
                Thread thread = new Thread(deleData);
                thread.Start(list);
            }
            catch (Exception ex)
            {
                WriteLog("UpMdbData", ex.ToString());
                Stop();
            }
        }

        private static void deleData(object list)
        {
            lock (obj)
            {
                try
                {
                    List<string> list2 = (List<string>)list;
                    if (list2.Count > 0)
                    {
                        for (int i = 0; i <= list2.Count - 1; i++)
                        {
                            string[] array = list2[i].Split(',');
                            int num = Convert.ToInt32(array[0]);
                            setAccessDataset(("delete * from [temp] where [ID]=" + num) ?? "", array[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("deleData", ex.ToString());
                    Stop();
                }
            }
        }

        private static bool SendDataToMysql(string SqlString, string mysqltablename)
        {
            try
            {
                if (SqlString.Contains(","))
                {
                    string[] array = SqlString.Split(',');
                    if (array.Length != 0)
                    {
                        string text = "";
                        text = "''";
                        for (int i = 1; i <= array.Length - 1; i++)
                        {
                            text = text + ",'" + array[i] + "'";
                        }

                        //Edit ThucNV 15/08/2023                        
                        text = text.Replace("''", "0");
                        int num = setMysqlDataSet("insert into " + mysqltablename + "  values (" + text + ") ");
                        if (num > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                WriteLog("SendDataToMysql", ex.ToString());
                return false;
            }
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void SetINI(string Section, string Key, string Value, string inipath)
        {
            WritePrivateProfileString(Section, Key, Value, inipath);
        }

        public static string GetINI(string Section, string Key, string sDefault, string inipath)
        {
            StringBuilder stringBuilder = new StringBuilder(500);
            int privateProfileString = GetPrivateProfileString(Section, Key, sDefault, stringBuilder, 500, inipath);
            return stringBuilder.ToString();
        }

        public static bool WriteLog(string FunctionName, string ErrorText)
        {
            try
            {
                if (!File.Exists(UpdataLogFilePath))
                {
                    StreamWriter streamWriter = new StreamWriter(UpdataLogFilePath, append: false, Encoding.Unicode);
                    streamWriter.WriteLine("Create Time : " + DateTime.Now.ToString());
                    streamWriter.WriteLine("--------------Error--Text----------------");
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("======> FunctionName: " + FunctionName + " -- " + DateTime.Now.ToString() + " <======");
                    streamWriter.WriteLine(ErrorText);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
                else
                {
                    StreamWriter streamWriter = new StreamWriter(UpdataLogFilePath, append: true, Encoding.Unicode);
                    streamWriter.WriteLine();
                    streamWriter.WriteLine("======> FunctionName: " + FunctionName + " -- " + DateTime.Now.ToString() + " <======");
                    streamWriter.WriteLine(ErrorText);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataSet getAccessDataset(string sql, string accespath)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string connectionString = "Provider=Microsoft.jet.OLEDB.4.0;Persist Security Info=True;Jet OLEDB:Database Password=" + AccessPassword + ";Data Source= " + accespath;
                OleDbConnection selectConnection = new OleDbConnection(connectionString);
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, selectConnection);
                dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet, "temp");
            }
            catch (Exception ex)
            {
                WriteLog("getAccessDataset", ex.ToString());
            }
            return dataSet;
        }

        public static bool setAccessDataset(string sql, string accesspath)
        {
            try
            {
                string connectionString = "Provider=Microsoft.jet.OLEDB.4.0;Persist Security Info=True;Jet OLEDB:Database Password=" + AccessPassword + ";Data Source= " + accesspath;
                OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                oleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDbConnection);
                oleDbCommand.ExecuteNonQuery();
                oleDbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                WriteLog("setAccessDataset", ex.ToString());
                return false;
            }
        }

        public static bool connect()
        {
            conn = new MySqlConnection("Database=" + MysqlDatabaseName + ";Data Source=" + MysqlIP + ";User Id=" + MysqlUsername + ";Password=" + MysqlPassword + ";pooling=false;CharSet=utf8;port=3306");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                WriteLog("connect", ex.ToString());
                return false;
            }
            return true;
        }

        public static int setMysqlDataSet(string sql)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                return mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog("setMysqlDataSet", ex.ToString());
                return 0;
            }
        }

        public static DataSet getMysqlDataSet(string sql)
        {
            try
            {
                connect();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet);
                conn.Close();
                return dataSet;
            }
            catch (Exception ex)
            {
                WriteLog("getMysqlDataSet", ex.ToString());
                return null;
            }
        }
    }
}	


