using DAL;
using MOD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LENS_FZ.GUI
{
    public partial class Frm_Query : Form
    {
        private bool sqlQuery = false;
        private MysqlDao DALMySQL = new MysqlDao();
        private DataDao DALACCES = new DataDao();

        List<DataFZ> list;

        public void Set_DGV_DoubleBuffered(DataGridView dgv)
        {
            Type type = dgv.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);
        }

        public static bool WriteTXT_UTF8(string FilePath, string str)
        {
            try
            {
                byte[] s = System.Text.Encoding.UTF8.GetBytes(str.ToString());
                System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fs.Write(s, 0, s.Length);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Frm_Query()
        {
            InitializeComponent();
        }

        private void Frm_Query_Load(object sender, EventArgs e)
        {
            if (Config.NETEnable)
                sqlQuery = true;

            Set_DGV_DoubleBuffered(DGV);
            DGV.DataSource = null;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Bold);
            DGV.RowsDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular);
            DGV.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGV.ReadOnly = true;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void txt_SN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnQuery_Click(null, null);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sn = txt_SN.Text.Trim();
            DGV.DataSource = null;
            list = new List<DataFZ>();

            if (string.IsNullOrEmpty(sn))
            {
                MessageBox.Show("Mã SN không được để trống", "nhắc nhở lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_SN.Focus();
                return;
            }

            txt_SN.Text = string.Empty;

            if (sqlQuery)
            {
                list = DALMySQL.getListData("DataFZ", sn, "SN");                   
            }
            else
            {
                list = DALACCES.selectdata(sn);
            }

            if (list.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu tương ứng với SN được chọn!\r\nXin vui lòng kiểm tra lại...", "Error query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                
            }

            DGV.DataSource = list;
            txt_SN.Text = string.Empty;
        }

        private void btnQueryDay_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;
            list = new List<DataFZ>();

            if (sqlQuery)
            {
                list = DALMySQL.getListData("DataFZ", "", "SN", true);
            }
            else
            {
                list = DALACCES.getSNNewState();
            }

            if (list.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu tương ứng với SN được chọn!\r\nXin vui lòng kiểm tra lại...", "Error query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGV.DataSource = list;
            txt_SN.Text = string.Empty;
        }

        private void btn_ExportData_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV.Rows.Count > 0)
                {

                    if (!Directory.Exists(Application.StartupPath + "\\LOGDATA"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LOGDATA");
                    }

                    string FileSave = "LogMomen_" + DateTime.Now.ToString("yyyyMM_HHmmss") + ".csv";

                    string str = "";
                    for (int i = 0; i < DGV.Rows.Count; i++)
                    {
                        string data = "";
                        for (int j = 0; j < DGV.Columns.Count; j++)
                        {
                            if (DGV.Rows[i].Cells[j].Value != null)
                            {
                                data += DGV.Rows[i].Cells[j].Value.ToString() + ",";
                            }
                            else
                            {
                                data += "" + ",";
                            }
                        }

                        str += data + "\n";
                    }
                    string saveF = Path.Combine(Application.StartupPath + "\\LOGDATA", FileSave);
                    WriteTXT_UTF8(saveF, str);
                    Process.Start(saveF);
                }
                else
                {
                    MessageBox.Show("Dữ liệu không tồn tại, vui lòng kiểm tra trước khi xuất dữ liệu");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
