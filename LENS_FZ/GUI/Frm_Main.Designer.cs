namespace LENS_FZ
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Lab_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lab_COM = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lab_Addr = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lab_Steps = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lab_IDLens = new System.Windows.Forms.Label();
            this.LbTime = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbINFO = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.Label_KS = new System.Windows.Forms.Label();
            this.Label_S = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Alarm = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.NGCount = new System.Windows.Forms.Label();
            this.OKCount = new System.Windows.Forms.Label();
            this.lbNG = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbOK = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Lab_viewQR = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txt_QR = new System.Windows.Forms.TextBox();
            this.Lab_QR = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timerD = new System.Windows.Forms.Timer(this.components);
            this.TNPPort = new System.IO.Ports.SerialPort(this.components);
            this.loadtimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lab_Time,
            this.toolStripStatusLabel2,
            this.Lab_COM,
            this.toolStripStatusLabel4,
            this.Lab_Addr});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1189, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Lab_Time
            // 
            this.Lab_Time.Name = "Lab_Time";
            this.Lab_Time.Size = new System.Drawing.Size(63, 20);
            this.Lab_Time.Text = "00:00:00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel2.Text = "Connected:";
            // 
            // Lab_COM
            // 
            this.Lab_COM.Name = "Lab_COM";
            this.Lab_COM.Size = new System.Drawing.Size(42, 20);
            this.Lab_COM.Text = "COM";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(81, 20);
            this.toolStripStatusLabel4.Text = "IP Address:";
            // 
            // Lab_Addr
            // 
            this.Lab_Addr.Name = "Lab_Addr";
            this.Lab_Addr.Size = new System.Drawing.Size(106, 20);
            this.Lab_Addr.Text = "192.168.200.11";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.73809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.2619F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.4065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.5935F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1189, 620);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Lab_Steps);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Lab_IDLens);
            this.panel1.Controls.Add(this.LbTime);
            this.panel1.Controls.Add(this.lbUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(392, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 126);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Công đoạn kiểm tra:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Model ống kính:";
            // 
            // Lab_Steps
            // 
            this.Lab_Steps.AutoSize = true;
            this.Lab_Steps.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Steps.Location = new System.Drawing.Point(542, 78);
            this.Lab_Steps.Name = "Lab_Steps";
            this.Lab_Steps.Size = new System.Drawing.Size(35, 21);
            this.Lab_Steps.TabIndex = 7;
            this.Lab_Steps.Text = "NA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thời gian đăng nhập:";
            // 
            // Lab_IDLens
            // 
            this.Lab_IDLens.AutoSize = true;
            this.Lab_IDLens.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_IDLens.Location = new System.Drawing.Point(164, 78);
            this.Lab_IDLens.Name = "Lab_IDLens";
            this.Lab_IDLens.Size = new System.Drawing.Size(35, 21);
            this.Lab_IDLens.TabIndex = 5;
            this.Lab_IDLens.Text = "NA";
            // 
            // LbTime
            // 
            this.LbTime.AutoSize = true;
            this.LbTime.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTime.Location = new System.Drawing.Point(542, 22);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(35, 21);
            this.LbTime.TabIndex = 3;
            this.LbTime.Text = "NA";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(164, 22);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(35, 21);
            this.lbUser.TabIndex = 1;
            this.lbUser.Text = "NA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên nhân viên:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbINFO);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.Label_KS);
            this.panel2.Controls.Add(this.Label_S);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.Alarm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(392, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 383);
            this.panel2.TabIndex = 2;
            // 
            // lbINFO
            // 
            this.lbINFO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbINFO.AutoSize = true;
            this.lbINFO.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbINFO.Location = new System.Drawing.Point(8, 74);
            this.lbINFO.Name = "lbINFO";
            this.lbINFO.Size = new System.Drawing.Size(0, 21);
            this.lbINFO.TabIndex = 4;
            this.lbINFO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Query);
            this.groupBox1.Location = new System.Drawing.Point(7, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 151);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DỮ LIỆU";
            // 
            // btn_Query
            // 
            this.btn_Query.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Query.ForeColor = System.Drawing.Color.White;
            this.btn_Query.Location = new System.Drawing.Point(14, 61);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(165, 41);
            this.btn_Query.TabIndex = 0;
            this.btn_Query.Text = "Truy vấn";
            this.btn_Query.UseVisualStyleBackColor = false;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // Label_KS
            // 
            this.Label_KS.BackColor = System.Drawing.Color.Silver;
            this.Label_KS.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_KS.Location = new System.Drawing.Point(7, 107);
            this.Label_KS.Name = "Label_KS";
            this.Label_KS.Size = new System.Drawing.Size(191, 49);
            this.Label_KS.TabIndex = 0;
            this.Label_KS.Text = "0";
            this.Label_KS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_S
            // 
            this.Label_S.AutoSize = true;
            this.Label_S.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_S.ForeColor = System.Drawing.Color.Blue;
            this.Label_S.Location = new System.Drawing.Point(215, 5);
            this.Label_S.Name = "Label_S";
            this.Label_S.Size = new System.Drawing.Size(0, 28);
            this.Label_S.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(391, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 34);
            this.label7.TabIndex = 2;
            this.label7.Text = "DỮ LIỆU ĐO";
            // 
            // Alarm
            // 
            this.Alarm.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alarm.Location = new System.Drawing.Point(204, 107);
            this.Alarm.Name = "Alarm";
            this.Alarm.Size = new System.Drawing.Size(581, 251);
            this.Alarm.TabIndex = 1;
            this.Alarm.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(794, 99);
            this.label1.TabIndex = 3;
            this.label1.Text = "TRẠNG THÁI ỐNG KÍNH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.NGCount);
            this.panel4.Controls.Add(this.OKCount);
            this.panel4.Controls.Add(this.lbNG);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.lbOK);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 524);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 93);
            this.panel4.TabIndex = 4;
            // 
            // NGCount
            // 
            this.NGCount.BackColor = System.Drawing.Color.Transparent;
            this.NGCount.Font = new System.Drawing.Font("SimSun", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NGCount.Location = new System.Drawing.Point(127, 51);
            this.NGCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NGCount.Name = "NGCount";
            this.NGCount.Size = new System.Drawing.Size(97, 38);
            this.NGCount.TabIndex = 3;
            this.NGCount.Text = "0";
            this.NGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OKCount
            // 
            this.OKCount.BackColor = System.Drawing.Color.Transparent;
            this.OKCount.Font = new System.Drawing.Font("SimSun", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKCount.Location = new System.Drawing.Point(127, 9);
            this.OKCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OKCount.Name = "OKCount";
            this.OKCount.Size = new System.Drawing.Size(97, 38);
            this.OKCount.TabIndex = 1;
            this.OKCount.Text = "0";
            this.OKCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNG
            // 
            this.lbNG.AutoSize = true;
            this.lbNG.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNG.ForeColor = System.Drawing.Color.Red;
            this.lbNG.Location = new System.Drawing.Point(14, 59);
            this.lbNG.Name = "lbNG";
            this.lbNG.Size = new System.Drawing.Size(94, 22);
            this.lbNG.TabIndex = 2;
            this.lbNG.Text = "Tổng NG:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(261, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(119, 39);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Xóa Tổng";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbOK
            // 
            this.lbOK.AutoSize = true;
            this.lbOK.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOK.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbOK.Location = new System.Drawing.Point(14, 17);
            this.lbOK.Name = "lbOK";
            this.lbOK.Size = new System.Drawing.Size(94, 22);
            this.lbOK.TabIndex = 0;
            this.lbOK.Text = "Tổng OK:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.Lab_viewQR);
            this.panel5.Controls.Add(this.btn_Clear);
            this.panel5.Controls.Add(this.txt_QR);
            this.panel5.Controls.Add(this.Lab_QR);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(383, 126);
            this.panel5.TabIndex = 0;
            // 
            // Lab_viewQR
            // 
            this.Lab_viewQR.BackColor = System.Drawing.Color.Silver;
            this.Lab_viewQR.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_viewQR.Location = new System.Drawing.Point(97, 44);
            this.Lab_viewQR.Name = "Lab_viewQR";
            this.Lab_viewQR.Size = new System.Drawing.Size(231, 32);
            this.Lab_viewQR.TabIndex = 1;
            this.Lab_viewQR.Text = "0";
            this.Lab_viewQR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.Orange;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(97, 80);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(231, 35);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "Clear && Thao tác lại";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // txt_QR
            // 
            this.txt_QR.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_QR.Location = new System.Drawing.Point(97, 9);
            this.txt_QR.MaxLength = 20;
            this.txt_QR.Name = "txt_QR";
            this.txt_QR.Size = new System.Drawing.Size(231, 32);
            this.txt_QR.TabIndex = 0;
            this.txt_QR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_QR_KeyPress);
            // 
            // Lab_QR
            // 
            this.Lab_QR.AutoSize = true;
            this.Lab_QR.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_QR.Location = new System.Drawing.Point(12, 14);
            this.Lab_QR.Name = "Lab_QR";
            this.Lab_QR.Size = new System.Drawing.Size(75, 18);
            this.Lab_QR.TabIndex = 3;
            this.Lab_QR.Text = "Quét mã:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.axWindowsMediaPlayer1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 135);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.88251F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.23499F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.62141F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(383, 383);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 60);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(377, 263);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // timerD
            // 
            this.timerD.Enabled = true;
            this.timerD.Interval = 1000;
            this.timerD.Tick += new System.EventHandler(this.timerD_Tick);
            // 
            // loadtimer
            // 
            this.loadtimer.Tick += new System.EventHandler(this.loadtimer_Tick_1);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1189, 646);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[TAMRON] KIỂM TRA LỰC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Lab_Time;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel Lab_COM;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel Lab_Addr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timerD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label NGCount;
        private System.Windows.Forms.Label OKCount;
        private System.Windows.Forms.Label Lab_viewQR;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox txt_QR;
        private System.Windows.Forms.Label Lab_QR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lab_IDLens;
        private System.Windows.Forms.Label LbTime;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Lab_Steps;
        public System.IO.Ports.SerialPort TNPPort;
        private System.Windows.Forms.Timer loadtimer;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Alarm;
        private System.Windows.Forms.Label Label_KS;
        private System.Windows.Forms.Label Label_S;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbNG;
        private System.Windows.Forms.Label lbOK;
        private System.Windows.Forms.Label lbINFO;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

