namespace Project_CuoiKi.All_User_Control
{
    partial class UC_Baocao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Baocao));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.date2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.date3 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.rbtn1 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbtn2 = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnBoqua = new Guna.UI2.WinForms.Guna2Button();
            this.btnDT = new Guna.UI2.WinForms.Guna2Button();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.cboMahoadon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboManhanvien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnHienthitatca = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1035, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(808, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Từ";
            // 
            // date1
            // 
            this.date1.Checked = true;
            this.date1.FillColor = System.Drawing.Color.White;
            this.date1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date1.Location = new System.Drawing.Point(855, 126);
            this.date1.Margin = new System.Windows.Forms.Padding(4);
            this.date1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(152, 44);
            this.date1.TabIndex = 4;
            this.date1.Value = new System.DateTime(2024, 5, 29, 21, 32, 15, 706);
            this.date1.ValueChanged += new System.EventHandler(this.date1_ValueChanged);
            // 
            // date2
            // 
            this.date2.Checked = true;
            this.date2.FillColor = System.Drawing.Color.White;
            this.date2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date2.Location = new System.Drawing.Point(1119, 126);
            this.date2.Margin = new System.Windows.Forms.Padding(4);
            this.date2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(149, 44);
            this.date2.TabIndex = 6;
            this.date2.Value = new System.DateTime(2024, 5, 29, 21, 32, 15, 706);
            this.date2.ValueChanged += new System.EventHandler(this.date2_ValueChanged);
            // 
            // date3
            // 
            this.date3.Checked = true;
            this.date3.FillColor = System.Drawing.Color.White;
            this.date3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date3.Location = new System.Drawing.Point(855, 240);
            this.date3.Margin = new System.Windows.Forms.Padding(4);
            this.date3.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date3.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date3.Name = "date3";
            this.date3.Size = new System.Drawing.Size(152, 44);
            this.date3.TabIndex = 7;
            this.date3.Value = new System.DateTime(2024, 5, 29, 21, 32, 15, 706);
            this.date3.ValueChanged += new System.EventHandler(this.date3_ValueChanged);
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbtn1.CheckedState.BorderThickness = 0;
            this.rbtn1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbtn1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbtn1.CheckedState.InnerOffset = -4;
            this.rbtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn1.Location = new System.Drawing.Point(577, 140);
            this.rbtn1.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(160, 29);
            this.rbtn1.TabIndex = 8;
            this.rbtn1.Text = "Theo khoảng";
            this.rbtn1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbtn1.UncheckedState.BorderThickness = 2;
            this.rbtn1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbtn1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbtn1.CheckedChanged += new System.EventHandler(this.rbtn1_CheckedChanged);
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbtn2.CheckedState.BorderThickness = 0;
            this.rbtn2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbtn2.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbtn2.CheckedState.InnerOffset = -4;
            this.rbtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn2.Location = new System.Drawing.Point(577, 255);
            this.rbtn2.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(136, 29);
            this.rbtn2.TabIndex = 9;
            this.rbtn2.Text = "Theo ngày";
            this.rbtn2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbtn2.UncheckedState.BorderThickness = 2;
            this.rbtn2.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbtn2.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbtn2.CheckedChanged += new System.EventHandler(this.rbtn2_CheckedChanged);
            // 
            // btnBoqua
            // 
            this.btnBoqua.BorderRadius = 18;
            this.btnBoqua.BorderThickness = 1;
            this.btnBoqua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBoqua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBoqua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBoqua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBoqua.FillColor = System.Drawing.Color.White;
            this.btnBoqua.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBoqua.ForeColor = System.Drawing.Color.Black;
            this.btnBoqua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoqua.Image")));
            this.btnBoqua.Location = new System.Drawing.Point(1119, 341);
            this.btnBoqua.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(165, 55);
            this.btnBoqua.TabIndex = 11;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnDT
            // 
            this.btnDT.BorderRadius = 18;
            this.btnDT.BorderThickness = 1;
            this.btnDT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDT.FillColor = System.Drawing.Color.White;
            this.btnDT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDT.ForeColor = System.Drawing.Color.Black;
            this.btnDT.Location = new System.Drawing.Point(681, 341);
            this.btnDT.Margin = new System.Windows.Forms.Padding(4);
            this.btnDT.Name = "btnDT";
            this.btnDT.Size = new System.Drawing.Size(165, 55);
            this.btnDT.TabIndex = 12;
            this.btnDT.Text = "Doanh thu";
            this.btnDT.Click += new System.EventHandler(this.btnDT_Click);
            // 
            // datagridview
            // 
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Location = new System.Drawing.Point(180, 437);
            this.datagridview.Margin = new System.Windows.Forms.Padding(4);
            this.datagridview.Name = "datagridview";
            this.datagridview.RowHeadersWidth = 51;
            this.datagridview.Size = new System.Drawing.Size(1191, 375);
            this.datagridview.TabIndex = 13;
            this.datagridview.Click += new System.EventHandler(this.datagridview_Click);
            // 
            // cboMahoadon
            // 
            this.cboMahoadon.BackColor = System.Drawing.Color.Transparent;
            this.cboMahoadon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMahoadon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMahoadon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMahoadon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMahoadon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMahoadon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMahoadon.ItemHeight = 30;
            this.cboMahoadon.Location = new System.Drawing.Point(307, 126);
            this.cboMahoadon.Margin = new System.Windows.Forms.Padding(4);
            this.cboMahoadon.Name = "cboMahoadon";
            this.cboMahoadon.Size = new System.Drawing.Size(262, 36);
            this.cboMahoadon.TabIndex = 15;
            // 
            // cboManhanvien
            // 
            this.cboManhanvien.BackColor = System.Drawing.Color.Transparent;
            this.cboManhanvien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboManhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManhanvien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboManhanvien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboManhanvien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboManhanvien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboManhanvien.ItemHeight = 30;
            this.cboManhanvien.Location = new System.Drawing.Point(307, 240);
            this.cboManhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.cboManhanvien.Name = "cboManhanvien";
            this.cboManhanvien.Size = new System.Drawing.Size(262, 36);
            this.cboManhanvien.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mã hoá đơn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 251);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mã nhân viên";
            // 
            // btnXuat
            // 
            this.btnXuat.BorderRadius = 18;
            this.btnXuat.BorderThickness = 1;
            this.btnXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuat.FillColor = System.Drawing.Color.White;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnXuat.ForeColor = System.Drawing.Color.Black;
            this.btnXuat.Location = new System.Drawing.Point(900, 341);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(165, 55);
            this.btnXuat.TabIndex = 21;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BorderRadius = 18;
            this.btnTimkiem.BorderThickness = 1;
            this.btnTimkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimkiem.FillColor = System.Drawing.Color.White;
            this.btnTimkiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTimkiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.Image")));
            this.btnTimkiem.Location = new System.Drawing.Point(209, 341);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(165, 55);
            this.btnTimkiem.TabIndex = 10;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnHienthitatca
            // 
            this.btnHienthitatca.BorderRadius = 18;
            this.btnHienthitatca.BorderThickness = 1;
            this.btnHienthitatca.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHienthitatca.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHienthitatca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHienthitatca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHienthitatca.FillColor = System.Drawing.Color.White;
            this.btnHienthitatca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnHienthitatca.ForeColor = System.Drawing.Color.Black;
            this.btnHienthitatca.Image = ((System.Drawing.Image)(resources.GetObject("btnHienthitatca.Image")));
            this.btnHienthitatca.Location = new System.Drawing.Point(428, 341);
            this.btnHienthitatca.Margin = new System.Windows.Forms.Padding(4);
            this.btnHienthitatca.Name = "btnHienthitatca";
            this.btnHienthitatca.Size = new System.Drawing.Size(197, 55);
            this.btnHienthitatca.TabIndex = 22;
            this.btnHienthitatca.Text = "Hiển thị tất cả";
            this.btnHienthitatca.Click += new System.EventHandler(this.btnHienthitatca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(537, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 62);
            this.label1.TabIndex = 23;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // UC_Baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHienthitatca);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboManhanvien);
            this.Controls.Add(this.cboMahoadon);
            this.Controls.Add(this.datagridview);
            this.Controls.Add(this.btnDT);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.rbtn2);
            this.Controls.Add(this.rbtn1);
            this.Controls.Add(this.date3);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Baocao";
            this.Size = new System.Drawing.Size(1572, 999);
            this.Load += new System.EventHandler(this.UC_Baocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker date1;
        private Guna.UI2.WinForms.Guna2DateTimePicker date2;
        private Guna.UI2.WinForms.Guna2DateTimePicker date3;
        private Guna.UI2.WinForms.Guna2RadioButton rbtn1;
        private Guna.UI2.WinForms.Guna2RadioButton rbtn2;
        private Guna.UI2.WinForms.Guna2Button btnBoqua;
        private Guna.UI2.WinForms.Guna2Button btnDT;
        private System.Windows.Forms.DataGridView datagridview;
        private Guna.UI2.WinForms.Guna2ComboBox cboManhanvien;
        private Guna.UI2.WinForms.Guna2ComboBox cboMahoadon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnXuat;
        private Guna.UI2.WinForms.Guna2Button btnTimkiem;
        private Guna.UI2.WinForms.Guna2Button btnHienthitatca;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
