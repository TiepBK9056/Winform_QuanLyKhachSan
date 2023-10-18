namespace QuanLyKhachSanNhom9.QuanLyNhanVien
{
    partial class MainNhanVien
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
            this.panelMeNu = new System.Windows.Forms.Panel();
            this.icbCustomer = new FontAwesome.Sharp.IconButton();
            this.icbRoom = new FontAwesome.Sharp.IconButton();
            this.icbService = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelHead = new System.Windows.Forms.Panel();
            this.lblTiltle = new System.Windows.Forms.Label();
            this.icbLogout = new FontAwesome.Sharp.IconButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.icbPayment = new FontAwesome.Sharp.IconButton();
            this.panelMeNu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMeNu
            // 
            this.panelMeNu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelMeNu.Controls.Add(this.icbPayment);
            this.panelMeNu.Controls.Add(this.icbCustomer);
            this.panelMeNu.Controls.Add(this.icbRoom);
            this.panelMeNu.Controls.Add(this.icbService);
            this.panelMeNu.Controls.Add(this.pictureBox1);
            this.panelMeNu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMeNu.Location = new System.Drawing.Point(0, 0);
            this.panelMeNu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMeNu.Name = "panelMeNu";
            this.panelMeNu.Size = new System.Drawing.Size(150, 512);
            this.panelMeNu.TabIndex = 0;
            // 
            // icbCustomer
            // 
            this.icbCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.icbCustomer.FlatAppearance.BorderSize = 0;
            this.icbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.icbCustomer.IconChar = FontAwesome.Sharp.IconChar.UsersBetweenLines;
            this.icbCustomer.IconColor = System.Drawing.Color.Navy;
            this.icbCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbCustomer.Location = new System.Drawing.Point(0, 254);
            this.icbCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.icbCustomer.Name = "icbCustomer";
            this.icbCustomer.Size = new System.Drawing.Size(150, 70);
            this.icbCustomer.TabIndex = 6;
            this.icbCustomer.Text = "Customer";
            this.icbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbCustomer.UseVisualStyleBackColor = true;
            this.icbCustomer.Click += new System.EventHandler(this.icbCustomer_Click_1);
            // 
            // icbRoom
            // 
            this.icbRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.icbRoom.FlatAppearance.BorderSize = 0;
            this.icbRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.icbRoom.IconChar = FontAwesome.Sharp.IconChar.Cube;
            this.icbRoom.IconColor = System.Drawing.Color.Navy;
            this.icbRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbRoom.Location = new System.Drawing.Point(0, 184);
            this.icbRoom.Margin = new System.Windows.Forms.Padding(2);
            this.icbRoom.Name = "icbRoom";
            this.icbRoom.Size = new System.Drawing.Size(150, 70);
            this.icbRoom.TabIndex = 5;
            this.icbRoom.Text = "Room";
            this.icbRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbRoom.UseVisualStyleBackColor = true;
            this.icbRoom.Click += new System.EventHandler(this.icbRoom_Click_1);
            // 
            // icbService
            // 
            this.icbService.Dock = System.Windows.Forms.DockStyle.Top;
            this.icbService.FlatAppearance.BorderSize = 0;
            this.icbService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.icbService.IconChar = FontAwesome.Sharp.IconChar.House;
            this.icbService.IconColor = System.Drawing.Color.Navy;
            this.icbService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbService.Location = new System.Drawing.Point(0, 114);
            this.icbService.Margin = new System.Windows.Forms.Padding(2);
            this.icbService.Name = "icbService";
            this.icbService.Size = new System.Drawing.Size(150, 70);
            this.icbService.TabIndex = 1;
            this.icbService.Text = "Home";
            this.icbService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbService.UseVisualStyleBackColor = true;
            this.icbService.Click += new System.EventHandler(this.icbService_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::QuanLyKhachSanNhom9.Properties.Resources.Screenshot_2023_09_22_163302;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelHead
            // 
            this.PanelHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PanelHead.Controls.Add(this.lblTiltle);
            this.PanelHead.Controls.Add(this.icbLogout);
            this.PanelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PanelHead.Location = new System.Drawing.Point(150, 0);
            this.PanelHead.Margin = new System.Windows.Forms.Padding(2);
            this.PanelHead.Name = "PanelHead";
            this.PanelHead.Size = new System.Drawing.Size(774, 49);
            this.PanelHead.TabIndex = 1;
            // 
            // lblTiltle
            // 
            this.lblTiltle.AutoSize = true;
            this.lblTiltle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiltle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTiltle.Location = new System.Drawing.Point(270, 12);
            this.lblTiltle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTiltle.Name = "lblTiltle";
            this.lblTiltle.Size = new System.Drawing.Size(244, 21);
            this.lblTiltle.TabIndex = 1;
            this.lblTiltle.Text = "WELCOME : Nguyễn Ngọc Tiệp";
            // 
            // icbLogout
            // 
            this.icbLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.icbLogout.FlatAppearance.BorderSize = 0;
            this.icbLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.icbLogout.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.icbLogout.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.icbLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbLogout.Location = new System.Drawing.Point(661, 0);
            this.icbLogout.Margin = new System.Windows.Forms.Padding(2);
            this.icbLogout.Name = "icbLogout";
            this.icbLogout.Size = new System.Drawing.Size(113, 49);
            this.icbLogout.TabIndex = 0;
            this.icbLogout.Text = "Logout";
            this.icbLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbLogout.UseVisualStyleBackColor = true;
            this.icbLogout.Click += new System.EventHandler(this.icbLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(150, 49);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(774, 463);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // icbPayment
            // 
            this.icbPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.icbPayment.FlatAppearance.BorderSize = 0;
            this.icbPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.icbPayment.IconChar = FontAwesome.Sharp.IconChar.PhoneVolume;
            this.icbPayment.IconColor = System.Drawing.Color.Navy;
            this.icbPayment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbPayment.Location = new System.Drawing.Point(0, 324);
            this.icbPayment.Margin = new System.Windows.Forms.Padding(2);
            this.icbPayment.Name = "icbPayment";
            this.icbPayment.Size = new System.Drawing.Size(150, 70);
            this.icbPayment.TabIndex = 7;
            this.icbPayment.Text = "Contact";
            this.icbPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icbPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icbPayment.UseVisualStyleBackColor = true;
            this.icbPayment.Click += new System.EventHandler(this.icbPayment_Click_1);
            // 
            // MainNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 512);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.PanelHead);
            this.Controls.Add(this.panelMeNu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainNhanVien";
            this.Load += new System.EventHandler(this.MainNhanVien_Load);
            this.panelMeNu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelHead.ResumeLayout(false);
            this.PanelHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMeNu;
        private System.Windows.Forms.Panel PanelHead;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton icbService;
        private FontAwesome.Sharp.IconButton icbLogout;
        private System.Windows.Forms.Label lblTiltle;
        private FontAwesome.Sharp.IconButton icbRoom;
        private FontAwesome.Sharp.IconButton icbCustomer;
        private FontAwesome.Sharp.IconButton icbPayment;
    }
}