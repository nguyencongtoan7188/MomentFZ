namespace LENS_FZ.GUI
{
    partial class Frm_Query
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Query));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ExportData = new System.Windows.Forms.Button();
            this.btnQueryDay = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txt_SN = new System.Windows.Forms.TextBox();
            this.lbSN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.DGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.88133F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.11868F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1202, 573);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.Lavender;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(4, 95);
            this.DGV.Margin = new System.Windows.Forms.Padding(4);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 21;
            this.DGV.Size = new System.Drawing.Size(1194, 474);
            this.DGV.TabIndex = 185;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ExportData);
            this.panel1.Controls.Add(this.btnQueryDay);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.txt_SN);
            this.panel1.Controls.Add(this.lbSN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 85);
            this.panel1.TabIndex = 0;
            // 
            // btn_ExportData
            // 
            this.btn_ExportData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportData.Location = new System.Drawing.Point(1027, 45);
            this.btn_ExportData.Name = "btn_ExportData";
            this.btn_ExportData.Size = new System.Drawing.Size(160, 30);
            this.btn_ExportData.TabIndex = 2;
            this.btn_ExportData.Text = "Xuất dữ liệu .csv";
            this.btn_ExportData.UseVisualStyleBackColor = true;
            this.btn_ExportData.Click += new System.EventHandler(this.btn_ExportData_Click);
            // 
            // btnQueryDay
            // 
            this.btnQueryDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQueryDay.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnQueryDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryDay.Location = new System.Drawing.Point(1027, 9);
            this.btnQueryDay.Name = "btnQueryDay";
            this.btnQueryDay.Size = new System.Drawing.Size(160, 30);
            this.btnQueryDay.TabIndex = 2;
            this.btnQueryDay.Text = "Truy vấn trong ngày";
            this.btnQueryDay.UseVisualStyleBackColor = false;
            this.btnQueryDay.Visible = false;
            this.btnQueryDay.Click += new System.EventHandler(this.btnQueryDay_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(337, 27);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(98, 30);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Truy vấn";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txt_SN
            // 
            this.txt_SN.Location = new System.Drawing.Point(136, 29);
            this.txt_SN.Name = "txt_SN";
            this.txt_SN.Size = new System.Drawing.Size(184, 28);
            this.txt_SN.TabIndex = 1;
            this.txt_SN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SN_KeyPress);
            // 
            // lbSN
            // 
            this.lbSN.AutoSize = true;
            this.lbSN.Location = new System.Drawing.Point(17, 32);
            this.lbSN.Name = "lbSN";
            this.lbSN.Size = new System.Drawing.Size(107, 21);
            this.lbSN.TabIndex = 0;
            this.lbSN.Text = "Nhập mã SN:";
            // 
            // Frm_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Query";
            this.Text = "[TAMRON] TRUY VẤN";
            this.Load += new System.EventHandler(this.Frm_Query_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txt_SN;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Button btnQueryDay;
        private System.Windows.Forms.Button btn_ExportData;
    }
}