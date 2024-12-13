using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LENS_FZ.GUI
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        public bool RestoreIniFileEveryTest()
        {            
            System.Resources.ResourceManager resourceManager = Properties.Resources.ResourceManager;
            Object target = null;

            target = resourceManager.GetObject("setting");
            if (target != null)
            {
                if (!File.Exists(@".\setting.ini"))
                {
                    using (StreamWriter writer = new StreamWriter("setting.ini", false, System.Text.Encoding.Unicode))
                    {
                        writer.Write((string)target);
                    }
                }                
            }

            target = resourceManager.GetObject("DATA");
            if (target != null)
            {
                if (!File.Exists(@".\DATA.mdb"))
                {
                    string sourcePath = "\\\\192.168.200.18\\Publish\\Worker\\FZMomen_SW\\DATA\\DATA.mdb";
                    // Check if the destination file already exists
                    if (!File.Exists(sourcePath))
                    {
                        MessageBox.Show($"Can't file {sourcePath}");
                        return false;
                    }

                    // Copy the file from source to destination
                    File.Copy(sourcePath, Application.StartupPath + @"\DATA.mdb");
                }                
            }           

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txt_Login.Text.Substring(0, 1);
            if (txt_Login.Text.Length == 7 && name.ToUpper().Equals("V"))
            {
                string userid = txt_Login.Text.Trim().Substring(1, txt_Login.Text.Length - 1);
                
                Frm_Main main = new Frm_Main(userid);
                this.Hide();
                main.ShowDialog();
                this.Show();

                txt_Login.Text = "";
                txt_Login.Focus();
            }
            else
            {
                txt_Login.Text = "";
                MessageBox.Show("Mật khẩu không đúng, vui lòng đăng nhập lại!");
                txt_Login.Focus();
            }
        }

        private void txt_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(null,null);
            }
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(SystemInformation.WorkingArea.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);

            #region One by One
            Process[] processList = Process.GetProcessesByName(this.ProductName);
            if (processList.Length > 1)
            {
                MessageBox.Show(processList[0].ProcessName + "Chương trình đã được mở，không thể mở quá trình nhiều lần!\r\n\r\n" + "Để khởi động lại phần mềm，Xin vui lòng đóng quá trình cũ và thử lại！\r\n\r\nXin cảm ơn!", "Cảnh báo");
                System.Environment.Exit(0);
            }

            RestoreIniFileEveryTest();

            txt_Login.Focus();
            #endregion           
        }
    }
}
