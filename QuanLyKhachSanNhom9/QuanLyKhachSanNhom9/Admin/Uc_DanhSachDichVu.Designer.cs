namespace Nhom9_DoAnQuanLiKhachSan
{
    partial class Uc_DanhSachDichVu
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
            this.dgvdichvu = new System.Windows.Forms.DataGridView();
            this.ID_dichvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttimkiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchdanhsachDV = new Guna.UI2.WinForms.Guna2TextBox();
            this.btsuathongtin = new Guna.UI2.WinForms.Guna2Button();
            this.dichvuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dichvuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdichvu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dichvuBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dichvuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvdichvu
            // 
            this.dgvdichvu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvdichvu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvdichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdichvu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_dichvu,
            this.TenDichVu,
            this.gia});
            this.dgvdichvu.Location = new System.Drawing.Point(157, 117);
            this.dgvdichvu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvdichvu.Name = "dgvdichvu";
            this.dgvdichvu.RowHeadersWidth = 181;
            this.dgvdichvu.RowTemplate.Height = 24;
            this.dgvdichvu.Size = new System.Drawing.Size(824, 443);
            this.dgvdichvu.TabIndex = 2;
            // 
            // ID_dichvu
            // 
            this.ID_dichvu.HeaderText = "ID";
            this.ID_dichvu.MinimumWidth = 6;
            this.ID_dichvu.Name = "ID_dichvu";
            this.ID_dichvu.Width = 150;
            // 
            // TenDichVu
            // 
            this.TenDichVu.HeaderText = "Tên dịch vụ";
            this.TenDichVu.MinimumWidth = 6;
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.Width = 200;
            // 
            // gia
            // 
            this.gia.HeaderText = "Giá tiền";
            this.gia.MinimumWidth = 6;
            this.gia.Name = "gia";
            this.gia.Width = 200;
            // 
            // bttimkiem
            // 
            this.bttimkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bttimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttimkiem.Location = new System.Drawing.Point(438, 22);
            this.bttimkiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bttimkiem.Name = "bttimkiem";
            this.bttimkiem.Size = new System.Drawing.Size(117, 45);
            this.bttimkiem.TabIndex = 4;
            this.bttimkiem.Text = "tìm kiếm";
            this.bttimkiem.UseVisualStyleBackColor = false;
            this.bttimkiem.Click += new System.EventHandler(this.bttimkiem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.SpringGreen;
            this.panel1.Controls.Add(this.searchdanhsachDV);
            this.panel1.Controls.Add(this.bttimkiem);
            this.panel1.Location = new System.Drawing.Point(381, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 84);
            this.panel1.TabIndex = 5;
            // 
            // searchdanhsachDV
            // 
            this.searchdanhsachDV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchdanhsachDV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchdanhsachDV.DefaultText = "tìm kiếm tên dịch vụ";
            this.searchdanhsachDV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchdanhsachDV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchdanhsachDV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchdanhsachDV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchdanhsachDV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchdanhsachDV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchdanhsachDV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchdanhsachDV.IconLeft = global::QuanLyKhachSanNhom9.Properties.Resources.search;
            this.searchdanhsachDV.Location = new System.Drawing.Point(149, 22);
            this.searchdanhsachDV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.searchdanhsachDV.Name = "searchdanhsachDV";
            this.searchdanhsachDV.PasswordChar = '\0';
            this.searchdanhsachDV.PlaceholderText = "";
            this.searchdanhsachDV.SelectedText = "";
            this.searchdanhsachDV.Size = new System.Drawing.Size(258, 45);
            this.searchdanhsachDV.TabIndex = 3;
            this.searchdanhsachDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchdanhsachDV.Click += new System.EventHandler(this.searchdanhsachDV_Click);
            // 
            // btsuathongtin
            // 
            this.btsuathongtin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btsuathongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btsuathongtin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btsuathongtin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btsuathongtin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btsuathongtin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btsuathongtin.FillColor = System.Drawing.Color.Cyan;
            this.btsuathongtin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsuathongtin.ForeColor = System.Drawing.Color.Black;
            this.btsuathongtin.Image = global::QuanLyKhachSanNhom9.Properties.Resources.service;
            this.btsuathongtin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btsuathongtin.ImageSize = new System.Drawing.Size(40, 40);
            this.btsuathongtin.Location = new System.Drawing.Point(157, 27);
            this.btsuathongtin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btsuathongtin.Name = "btsuathongtin";
            this.btsuathongtin.Size = new System.Drawing.Size(227, 84);
            this.btsuathongtin.TabIndex = 1;
            this.btsuathongtin.Text = "Sửa thông tin";
            this.btsuathongtin.Click += new System.EventHandler(this.btsuathongtin_Click);
            // 
            // dichvuBindingSource1
            // 
            this.dichvuBindingSource1.DataMember = "dichvu";
            // 
            // dichvuBindingSource
            // 
            this.dichvuBindingSource.DataMember = "dichvu";
            // 
            // btnLoad
            // 
            this.btnLoad.AutoRoundedCorners = true;
            this.btnLoad.BorderRadius = 21;
            this.btnLoad.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoad.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(632, 580);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(124, 45);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDong
            // 
            this.btnDong.AutoRoundedCorners = true;
            this.btnDong.BorderRadius = 21;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(849, 580);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(117, 45);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Uc_DanhSachDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(1056, 660);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvdichvu);
            this.Controls.Add(this.btsuathongtin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Uc_DanhSachDichVu";
            this.Text = "Uc_DanhSachDichVu";
            this.Load += new System.EventHandler(this.Uc_DanhSachDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdichvu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dichvuBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dichvuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dichvuBindingSource;

        private System.Windows.Forms.DataGridView dgvdichvu;

        private System.Windows.Forms.BindingSource dichvuBindingSource1;

     
        private Guna.UI2.WinForms.Guna2TextBox searchdanhsachDV;
        private System.Windows.Forms.Button bttimkiem;
        private Guna.UI2.WinForms.Guna2Button btsuathongtin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_dichvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia;
        private Guna.UI2.WinForms.Guna2Button btnLoad;
        private Guna.UI2.WinForms.Guna2Button btnDong;
    }
}