using DAL;
using Google.Protobuf.WellKnownTypes;
using LENS_FZ.GUI;
using LENS_FZ.Lib;
using MOD;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Updata;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LENS_FZ
{
    public partial class Frm_Main : Form
    {
        private Int16 veryNET = 0;
        INIHelper ini = new INIHelper(Application.StartupPath + "\\setting.ini");

        public delegate void AddDataDelegate(FZConfig FZConfig, int Data);
        public AddDataDelegate addDataDel;

        public delegate bool ShowDataDelegate(FZConfig FZConfig);
        public ShowDataDelegate showDataDel;

        private List<ValueTimeData> values = new List<ValueTimeData>();
        private string SN = "";
        string userName = "";

        private int NumberChecks = 0;
        private int _step = 0;
        private bool _sTOPTime = false;

        DataDao DALACCES = new DataDao();

        private void setportbt()
        {
            TNPPort.DataReceived += this.serialPortQR_DataReceived;
        }

        private void serialPortQR_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                var abc = TNPPort.ReadLine();
                string dataStr = abc.Contains("MB") ? TNPPort.ReadLine().Replace("MB", "") : TNPPort.ReadLine();
                double datadouble = double.Parse(dataStr);
                var data = Math.Round(datadouble, 3);
                int intData = Convert.ToInt32(data * 1000);

                addDataDel(Config.list_funcParam[_step], intData);
            }
            catch (Exception ex)
            {
                LogHelper.LogFlag = true;
                LogHelper.LogError("An error occurred in the serial port reading data：" + ex.ToString());
                LogHelper.LogFlag = false;
                LogHelper.ExitThread();
            }
        }

        public bool InitInstrumentAndFixture()
        {
            string[] lines = File.ReadAllLines(Application.StartupPath + "\\setting.ini", System.Text.Encoding.Default);
            var linesUppercase = lines.Select(s => s.ToUpper()).ToArray();

            char[] separators = new char[] { '[', ']' };

            foreach (string line in lines)
            {
                if (line.StartsWith(";") || line.StartsWith("#"))
                    continue;

                if (line.StartsWith("[CD_"))
                {
                    Config.list_funcName.Add(line.Replace(separators, ""));
                }
            }

            return true;
        }

        private void CleanData()
        {
            Label_S.Text = string.Empty;
            Label_KS.Text = "0";
            Label_KS.BackColor = Color.Silver;
            Alarm.Clear();
        }

        private void OnLoadData()
        {
            try
            {
                CleanData();
                txt_QR.Enabled = false;                
                _step = 0;
                _sTOPTime = false;
                NumberChecks = 0;

                Label_S.Text = "BƯỚC => KIỂM TRA: " + Config.list_funcParam[_step].FZtype;
                lbINFO.Text = "MOMEN: " + Config.list_funcParam[_step].FZMin + " ~ " + Config.list_funcParam[_step].FZMax + " / TIME:~" + Config.list_funcParam[_step].NextTime + " sec";

                PlayFile(Config.list_funcParam[_step].FZVideo);

                var result = MessageBox.Show($"LẦN THAO TÁC 01: => {Config.list_funcParam[_step].FZtype}\r\n\r\n[Node: Hãy tham khảo Video hướng dẫn]\r\n\r\nChọn OK=> BẮT ĐẦU ĐO", "KIỂM TRA LỰC MOMEN", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {                    
                    if (!TNPPort.IsOpen)
                    {
                        TNPPort.Open();
                    }
                    TNPPort.WriteLine("BB1" + (char)13);
                                        
                    loadtimer.Interval = Config.list_funcParam[_step].NextTime * 1000;
                    loadtimer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error OnLoadData()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopRunning()
        {
            //========= CLOSE READEXISTING
            if (TNPPort.IsOpen)
            {
                TNPPort.WriteLine("BA" + (char)13);

                TNPPort.ReadExisting();
            }

            //========= CLEAR DATA
            _step = 0;
            _sTOPTime = false;
            NumberChecks = 0;
        }

        public Frm_Main(string user)
        {
            InitializeComponent();
            this.userName = user;
        }

        private void timerD_Tick(object sender, EventArgs e)
        {
            Lab_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (veryNET >= 5)
            {
                veryNET = 0;

                if (Config.NETEnable)
                {                    
                    if (PingHelper.Ping(Config.IPAddr))
                    {
                        Lab_Addr.Text = Config.IPAddr;
                        Lab_Addr.BackColor = Color.Lime;
                    }
                    else
                    {
                        Lab_Addr.Text = Config.IPAddr;
                        Lab_Addr.BackColor = Color.Red;
                    }
                }
                else
                {
                    Lab_Addr.Text = "127.0.0.1";
                    Lab_Addr.BackColor = Color.Gray;
                }
            }

            veryNET++;
        }

        private void Alarmmsg(string msg, Color color)
        {
            this.Invoke(new Action(() =>
            {
                DateTime time = DateTime.Now;
                Alarm.AppendText(time + "--" + msg + "\r\n");
                Alarm.Select(Alarm.Text.Length - (time + "--" + msg).Length - 1, (time + "--" + msg).Length);
                Alarm.SelectionColor = color;
                //Alarm.Focus();
                Alarm.Select(Alarm.Text.Length, 0);
                Alarm.ScrollToCaret();
            }));            
        }

        private void OKorNGState(string state)
        {
            int okcount = 0;
            int ngcount = 0;

            okcount = Convert.ToInt32(ini.IniReadValue("setting", "OK"));
            ngcount = Convert.ToInt32(ini.IniReadValue("setting", "NG"));

            if (state.Equals("OK"))
            {                
                ++okcount;
                ini.IniWriteValue("setting", "OK", okcount.ToString());
            }
            else
            {
                ++ngcount;
                ini.IniWriteValue("setting", "NG", ngcount.ToString());
            }

            OKCount.Text = ini.IniReadValue("setting", "OK");
            NGCount.Text = ini.IniReadValue("setting", "NG");
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lbUser.Text = userName;
            LbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.SetDesktopLocation(SystemInformation.WorkingArea.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);

            txt_QR.Text = "";
            txt_QR.Focus();

            axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);

            //======= CHECK CONFIG
            if (InitInstrumentAndFixture())
            {
                try
                {
                    //=> Machine
                    this.Text += " - " + ini.IniReadValue("Machine", "Lines") + "_ver: " + this.ProductVersion;
                    Lab_IDLens.Text = ini.IniReadValue("Machine", "Lines");
                    Lab_Steps.Text = ini.IniReadValue("Machine", "ProjectName");                   

                    //=> setting
                    Config.NETEnable = Convert.ToBoolean(ini.IniReadValue("setting", "NET"));
                    Config.IPAddr = ini.IniReadValue("setting", "MysqlIP");
                    OKCount.Text = ini.IniReadValue("setting", "OK");
                    NGCount.Text = ini.IniReadValue("setting", "NG");

                    //=> serial
                    Config.SCanOption = Convert.ToBoolean(ini.IniReadValue("SerialPort", "SCanOption"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LoadINI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    //Set Serialport
                    TNPPort.StopBits = (System.IO.Ports.StopBits)1;
                    TNPPort.DataBits = 8;
                    TNPPort.BaudRate = 19200;
                    TNPPort.Parity = System.IO.Ports.Parity.None;
                    TNPPort.ReadTimeout = 200;
                    TNPPort.WriteTimeout = 200;

                    //Open serial port
                    if (Config.SCanOption)
                    {
                        TNPPort.PortName = ini.IniReadValue("SerialPort", "COM");
                        if (!Config.setPort(TNPPort, true))
                        {
                            Lab_COM.Text = TNPPort.PortName;
                            Lab_COM.BackColor = Color.Red;
                            txt_QR.Enabled = false;
                            return;
                        }
                        else
                        {
                            Lab_COM.Text = TNPPort.PortName;
                            Lab_COM.BackColor = Color.Lime;
                            setportbt();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Main Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //======= LOAD CONFIG
            if (Config.list_funcName.Count > 0)
            {
                int id = 0;
                foreach (var itName in Config.list_funcName)
                {
                    id++;
                    FZConfig fZConfig = new FZConfig()
                    {
                        ID = id,
                        FZtype = ini.IniReadValue(itName, "FZtype"),
                        NextTime = int.Parse(ini.IniReadValue(itName, "NextTime")),
                        FZMax = double.Parse(ini.IniReadValue(itName, "FZMax")),
                        FZMin = double.Parse(ini.IniReadValue(itName, "FZMin")),
                        FZNum = int.Parse(ini.IniReadValue(itName, "FZNum")),
                        FZVideo = ini.IniReadValue(itName, "FZVideo"),
                    };

                    Config.list_funcParam.Add(fZConfig);
                }                
            }

            //======= DELEGATE
            this.addDataDel = AddData;
            this.showDataDel = ShowData;

            Updata.Updata.Start();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            Frm_Query query = new Frm_Query();
            query.ShowDialog();
        }

        private void loadtimer_Tick_1(object sender, EventArgs e)
        {
            try
            {
                #region STOP TIMER AND PARSE VALUE

                _sTOPTime = true;

                loadtimer.Stop();

                NumberChecks++;

                bool DataDelegete = showDataDel(Config.list_funcParam[_step]);
                if (!DataDelegete)
                {
                    Config.list_funcParam[_step].FZResult = "NG";
                    Config.list_funcParam[_step].Datatime = DateTime.Now;
                    Config.list_funcParam[_step].MaxData = float.Parse(Label_KS.Text);

                    values.RemoveAll(it => it.FzID == Config.list_funcParam[_step].ID);

                    var result = MessageBox.Show($"LẦN THAO TÁC 01: => {Config.list_funcParam[_step].FZtype}\r\n\r\n[Node: Hãy tham khảo Video hướng dẫn]\r\n\r\nChọn OK=> BẮT ĐẦU ĐO", "KIỂM TRA LỰC MOMEN", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        //======= NẾU SAI XÓA SỐ LẦN ĐỌC ĐƯỢC TRỞ VỀ 0
                        _sTOPTime = false;
                        NumberChecks = 0;
                        loadtimer.Start();
                    }
                }
                else
                {
                    //======== KIỂM TRA SỐ LẦN THAO TÁC THÀNH CÔNG
                    if (NumberChecks >= Config.list_funcParam[_step].FZNum)
                    {
                        Config.list_funcParam[_step].FZResult = "OK";
                        Config.list_funcParam[_step].Datatime = DateTime.Now;
                        Config.list_funcParam[_step].MaxData = float.Parse(Label_KS.Text);

                        _step++;

                        if (_step >= Config.list_funcName.Count)
                        {
                            //PHÂN TÍCH KẾT QUẢ VÀ RETURN
                            StopRunning();
                            ShowAllData();
                            return;
                        }

                        Label_S.Text = "BƯỚC => KIỂM TRA: " + Config.list_funcParam[_step].FZtype;
                        lbINFO.Text = "MOMEN: " + Config.list_funcParam[_step].FZMin + " ~ " + Config.list_funcParam[_step].FZMax + " / TIME:~" + Config.list_funcParam[_step].NextTime + " sec";

                        PlayFile(Config.list_funcParam[_step].FZVideo);

                        var result = MessageBox.Show($"LẦN THAO TÁC 01: => {Config.list_funcParam[_step].FZtype}\r\n\r\n[Node: Hãy tham khảo Video hướng dẫn]\r\n\r\nChọn OK=> BẮT ĐẦU ĐO", "KIỂM TRA LỰC MOMEN", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            loadtimer.Interval = Config.list_funcParam[_step].NextTime * 1000;                            
                            NumberChecks = 0;
                            _sTOPTime = false;
                            loadtimer.Start();
                        }
                    }
                    else
                    {
                        Config.list_funcParam[_step].FZResult = "NA";
                        Config.list_funcParam[_step].Datatime = DateTime.Now;
                        Config.list_funcParam[_step].MaxData = float.Parse(Label_KS.Text);

                        values.RemoveAll(it => it.FzID == Config.list_funcParam[_step].ID);

                        var result = MessageBox.Show($"LẦN THAO TÁC {(NumberChecks + 1)}: => {Config.list_funcParam[_step].FZtype}\r\n\r\n[Node: Hãy tham khảo Video hướng dẫn]\r\n\r\nChọn OK=> BẮT ĐẦU ĐO", "KIỂM TRA LỰC MOMEN", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            _sTOPTime = false;
                            loadtimer.Start();
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.LogFlag = true;
                LogHelper.LogError("Error Timer：" + ex.ToString());
                LogHelper.LogFlag = false;
                LogHelper.ExitThread();
            }
        }

        private void txt_QR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                label1.Text = "TRẠNG THÁI ỐNG KÍNH";
                label1.BackColor = Color.Orange;
                Lab_viewQR.Text = "";
                Alarm.Clear();

                if (txt_QR.Text.Trim() != "")
                {
                    SN = txt_QR.Text.Trim().Replace("p","");
                    txt_QR.Text = "";
                    Lab_viewQR.Text = SN;                    
                    Alarmmsg("SN: " + SN, Color.Green);
                    OnLoadData();
                }
                else
                {
                    txt_QR.Text = "";
                    txt_QR.Focus();
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            loadtimer.Stop();
            StopRunning();
            CleanData();
            values.Clear();
            txt_QR.Enabled = true;
            txt_QR.Text = string.Empty;
            txt_QR.Focus();
            Lab_viewQR.Text = "0";
            lbINFO.Text = string.Empty;
            label1.Text = "TRẠNG THÁI ỐNG KÍNH";
            label1.BackColor = Color.Orange;
        }

        private void AddData(FZConfig fzSec,  int intData)
        {
            #region Hành động

            if (_sTOPTime)
                return;

            values.Add(new ValueTimeData()
            {
                Data = intData,
                Times = Config.list_funcParam[_step].FZtype,
                FzID = fzSec.ID
            });
            #endregion
        }

        /// <summary>
        /// Kiểm tra giá trị trong khoảng Max Min
        /// </summary>
        /// <param name="TypeFZ">Class FZConfig</param>
        /// <param name="FzID">ID of config</param>
        /// <returns></returns>
        private bool ShowData(FZConfig TypeFZ)
        {
            var GroupBy_Values = values.GroupBy(item => item.FzID);
            List<ValueTimeData> list = values.Where(item => item.FzID == TypeFZ.ID).ToList();
            double MaxValue = 0;
            bool isNG = ParseValue(TypeFZ, list, out MaxValue);
            string Max = string.Empty;
            if (MaxValue > 0)
            {
                string MaxStr = MaxValue.ToString();
                if (MaxStr.Length > 4)
                    Max = MaxStr.Substring(0, 4);
                else
                    Max = MaxStr;
            }
            else
            {
                string MaxStr = MaxValue.ToString();
                if (MaxStr.Length > 5)
                    Max = MaxStr.Substring(0, 5);
                else
                    Max = MaxStr;
            }

            if (isNG)
            {
                Label_KS.BackColor = Color.LimeGreen;
                Label_KS.ForeColor = Color.Black;
                Label_KS.Text = Max;
                Alarmmsg(Config.list_funcParam[_step].FZtype + "\t= " + Max + "\tPASS", Color.Blue);
                return true;
            }
            else
            {
                Label_KS.BackColor = Color.Red;
                Label_KS.ForeColor = Color.White;
                Label_KS.Text = Max;
                Alarmmsg(Config.list_funcParam[_step].FZtype + "\t= " + Max + "\tFAIL", Color.Red);
                return false;
            }
        }
       
        private bool ParseValue(FZConfig Fzdata, List<ValueTimeData> list, out double MaxNum)
        {
            List<ValueTimeData> list30 = new List<ValueTimeData>();

            MaxNum = 0;
            if (list.Count == 0) //Can't read value
                return false;

            if (list.Count > 0 && list.Count < (Fzdata.NextTime * 10))
                list30 = list;
            else
                list30 = list.Skip(list.Count - (Fzdata.NextTime * 10)).ToList();

            int MaxData = list30.Max(item => Math.Abs(item.Data));
            var MaxModel = list30.Where(item => Math.Abs(item.Data) == MaxData).FirstOrDefault();
            double MaxValue = Math.Round(MaxModel.Data * 0.001, 3);
            MaxNum = MaxValue;
            var resultData = Math.Abs(MaxValue);

            if (resultData >= Fzdata.FZMin && resultData < Fzdata.FZMax)
                return true;
            else
                return false;
        }

        private void ShowAllData()
        {
            int CountFZ = 0;
            if (Config.list_funcParam.Count > 0)
            {
                foreach (var item in Config.list_funcParam)
                {
                    DALACCES.insetdata(new DataFZ()
                    {
                        LensName = Lab_IDLens.Text,
                        StageID = Lab_Steps.Text,
                        SN = SN,
                        Result = item.FZResult,
                        NGName = item.FZResult == "NG" ? "MOMEN FAIL" : "",
                        StaffName = lbUser.Text,
                        FZtype = item.FZtype,
                        FZData = item.MaxData,
                        Datatime = item.Datatime
                    });

                    if (item.FZResult == "OK")
                        CountFZ++;                        
                }

                if (CountFZ == Config.list_funcParam.Count)
                {
                    OKorNGState("OK");
                    label1.Text = "ỐNG KÍNH => OK";
                    label1.BackColor = Color.LimeGreen;
                }
                else
                {
                    OKorNGState("NG");
                    label1.Text = "ỐNG KÍNH => NG";
                    label1.BackColor = Color.Red;
                }

                txt_QR.Enabled = true;
                txt_QR.Focus();
            }
        }

        private void PlayFile(String url)
        {
            if(File.Exists(url))
            {
                // Set the URL of the media file
                axWindowsMediaPlayer1.URL = url;

                // Optional: Set the media to start automatically
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }            
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 1: // Media stopped
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
                case 2: // Media paused
                    //MessageBox.Show("Media paused.");
                    break;
                case 3: // Media playing
                    //MessageBox.Show("Media playing.");
                    break;
                default:
                    // Handle other states if necessary
                    break;
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (TNPPort.IsOpen)
                    StopRunning();

                Updata.Updata.Stop();
            }
            catch
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult OKorNo = MessageBox.Show("Bạn thực sự muốn xóa Log sản lượng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OKorNo == DialogResult.Yes)
            {
                ini.IniWriteValue("setting", "NG", "0");
                ini.IniWriteValue("setting", "OK", "0");
                OKCount.Text = ini.IniReadValue("setting", "OK");
                NGCount.Text = ini.IniReadValue("setting", "NG");
            }
        }
    }
}
