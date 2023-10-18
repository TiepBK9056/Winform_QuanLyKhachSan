namespace QuanLyKhachSanNhom9.Admin
{
    partial class Uc_QuanLiPhongBan
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
            this.dgvphongban = new System.Windows.Forms.DataGridView();
            this.IDphongban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btload = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.bttimkiem = new System.Windows.Forms.Button();
            this.texttimkiem = new System.Windows.Forms.TextBox();
            this.btsua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textIDphongban = new System.Windows.Forms.TextBox();
            this.textTenPhongBan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvphongban)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvphongban
            // 
            this.dgvphongban.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvphongban.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvphongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvphongban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDphongban,
            this.TenPhongBan});
            this.dgvphongban.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvphongban.Location = new System.Drawing.Point(299, 81);
            this.dgvphongban.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvphongban.Name = "dgvphongban";
            this.dgvphongban.RowHeadersWidth = 51;
            this.dgvphongban.RowTemplate.Height = 24;
            this.dgvphongban.Size = new System.Drawing.Size(352, 207);
            this.dgvphongban.TabIndex = 1;
            this.dgvphongban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvphongban_CellClick);
            // 
            // IDphongban
            // 
            this.IDphongban.HeaderText = "ID Phòng ban";
            this.IDphongban.MinimumWidth = 6;
            this.IDphongban.Name = "IDphongban";
            this.IDphongban.Width = 200;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.HeaderText = "Tên Phòng Ban";
            this.TenPhongBan.MinimumWidth = 6;
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 170;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quản lí phòng ban";
            // 
            // btload
            // 
            this.btload.BackColor = System.Drawing.Color.Yellow;
            this.btload.Location = new System.Drawing.Point(393, 315);
            this.btload.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btload.Name = "btload";
            this.btload.Size = new System.Drawing.Size(85, 38);
            this.btload.TabIndex = 3;
            this.btload.Text = "Load";
            this.btload.UseVisualStyleBackColor = false;
            this.btload.Click += new System.EventHandler(this.btload_Click);
            // 
            // btclose
            // 
            this.btclose.BackColor = System.Drawing.Color.Yellow;
            this.btclose.Location = new System.Drawing.Point(533, 315);
            this.btclose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(85, 38);
            this.btclose.TabIndex = 3;
            this.btclose.Text = "Đóng";
            this.btclose.UseVisualStyleBackColor = false;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // bttimkiem
            // 
            this.bttimkiem.BackColor = System.Drawing.Color.Yellow;
            this.bttimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttimkiem.ForeColor = System.Drawing.Color.Red;
            this.bttimkiem.Location = new System.Drawing.Point(578, 43);
            this.bttimkiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bttimkiem.Name = "bttimkiem";
            this.bttimkiem.Size = new System.Drawing.Size(73, 31);
            this.bttimkiem.TabIndex = 4;
            this.bttimkiem.Text = "tìm kiếm";
            this.bttimkiem.UseVisualStyleBackColor = false;
            this.bttimkiem.Click += new System.EventHandler(this.bttimkiem_Click);
            // 
            // texttimkiem
            // 
            this.texttimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texttimkiem.ForeColor = System.Drawing.Color.Silver;
            this.texttimkiem.Location = new System.Drawing.Point(299, 43);
            this.texttimkiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.texttimkiem.Name = "texttimkiem";
            this.texttimkiem.Size = new System.Drawing.Size(239, 32);
            this.texttimkiem.TabIndex = 5;
            this.texttimkiem.Text = "nhập tên phòng ban";
            this.texttimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.texttimkiem.Click += new System.EventHandler(this.texttimkiem_Click);
            // 
            // btsua
            // 
            this.btsua.BackColor = System.Drawing.Color.Yellow;
            this.btsua.Location = new System.Drawing.Point(11, 306);
            this.btsua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(85, 38);
            this.btsua.TabIndex = 3;
            this.btsua.Text = "Sửa";
            this.btsua.UseVisualStyleBackColor = false;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Phòng ban";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Phòng Ban";
            // 
            // textIDphongban
            // 
            this.textIDphongban.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIDphongban.Location = new System.Drawing.Point(122, 59);
            this.textIDphongban.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textIDphongban.Name = "textIDphongban";
            this.textIDphongban.Size = new System.Drawing.Size(135, 26);
            this.textIDphongban.TabIndex = 1;
            this.textIDphongban.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textIDphongban_KeyPress);
            // 
            // textTenPhongBan
            // 
            this.textTenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTenPhongBan.Location = new System.Drawing.Point(124, 101);
            this.textTenPhongBan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textTenPhongBan.Name = "textTenPhongBan";
            this.textTenPhongBan.Size = new System.Drawing.Size(134, 26);
            this.textTenPhongBan.TabIndex = 1;
            this.textTenPhongBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTenPhongBan_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aqua;
            this.groupBox1.Controls.Add(this.textTenPhongBan);
            this.groupBox1.Controls.Add(this.textIDphongban);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(1, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(280, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phòng ban";
            // 
            // Uc_QuanLiPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(662, 384);
            this.Controls.Add(this.texttimkiem);
            this.Controls.Add(this.bttimkiem);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btload);
            this.Controls.Add(this.btsua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvphongban);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Uc_QuanLiPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uc_QuanLiPhongBan";
            this.Load += new System.EventHandler(this.Uc_QuanLiPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvphongban)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvphongban;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDphongban;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.Button btload;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.Button bttimkiem;
        private System.Windows.Forms.TextBox texttimkiem;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textIDphongban;
        private System.Windows.Forms.TextBox textTenPhongBan;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}