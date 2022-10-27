
namespace QLKinhDoanh
{
    partial class frmHoadon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lkLogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHoadon = new System.Windows.Forms.Panel();
            this.btnXuatHD = new System.Windows.Forms.Button();
            this.lbThanhtien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgvHoadon = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNgayxuat = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNguoiban = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlHoadon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lkLogout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 68);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(269, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(793, 100);
            this.panel3.TabIndex = 2;
            // 
            // lkLogout
            // 
            this.lkLogout.AutoSize = true;
            this.lkLogout.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkLogout.ForeColor = System.Drawing.Color.Black;
            this.lkLogout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lkLogout.Location = new System.Drawing.Point(420, 39);
            this.lkLogout.Name = "lkLogout";
            this.lkLogout.Size = new System.Drawing.Size(111, 27);
            this.lkLogout.TabIndex = 2;
            this.lkLogout.TabStop = true;
            this.lkLogout.Text = "Đăng xuất";
            this.lkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkLogout_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harrington", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý hàng hóa";
            // 
            // pnlHoadon
            // 
            this.pnlHoadon.Controls.Add(this.btnXuatHD);
            this.pnlHoadon.Controls.Add(this.lbThanhtien);
            this.pnlHoadon.Controls.Add(this.label8);
            this.pnlHoadon.Controls.Add(this.dtgvHoadon);
            this.pnlHoadon.Controls.Add(this.label6);
            this.pnlHoadon.Controls.Add(this.lbNgayxuat);
            this.pnlHoadon.Controls.Add(this.label7);
            this.pnlHoadon.Controls.Add(this.lbNguoiban);
            this.pnlHoadon.Controls.Add(this.label5);
            this.pnlHoadon.Controls.Add(this.label4);
            this.pnlHoadon.Location = new System.Drawing.Point(6, 77);
            this.pnlHoadon.Name = "pnlHoadon";
            this.pnlHoadon.Size = new System.Drawing.Size(531, 520);
            this.pnlHoadon.TabIndex = 11;
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnXuatHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatHD.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHD.Location = new System.Drawing.Point(319, 464);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(197, 45);
            this.btnXuatHD.TabIndex = 9;
            this.btnXuatHD.Text = "Xuất hóa đơn";
            this.btnXuatHD.UseVisualStyleBackColor = false;
            this.btnXuatHD.Click += new System.EventHandler(this.btnXuatHD_Click);
            // 
            // lbThanhtien
            // 
            this.lbThanhtien.AutoSize = true;
            this.lbThanhtien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhtien.Location = new System.Drawing.Point(149, 474);
            this.lbThanhtien.Name = "lbThanhtien";
            this.lbThanhtien.Size = new System.Drawing.Size(70, 27);
            this.lbThanhtien.TabIndex = 8;
            this.lbThanhtien.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 474);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thành tiền";
            // 
            // dtgvHoadon
            // 
            this.dtgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHoadon.Location = new System.Drawing.Point(9, 184);
            this.dtgvHoadon.Name = "dtgvHoadon";
            this.dtgvHoadon.RowHeadersWidth = 51;
            this.dtgvHoadon.RowTemplate.Height = 24;
            this.dtgvHoadon.Size = new System.Drawing.Size(519, 265);
            this.dtgvHoadon.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chi tiết";
            // 
            // lbNgayxuat
            // 
            this.lbNgayxuat.AutoSize = true;
            this.lbNgayxuat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayxuat.Location = new System.Drawing.Point(149, 97);
            this.lbNgayxuat.Name = "lbNgayxuat";
            this.lbNgayxuat.Size = new System.Drawing.Size(67, 27);
            this.lbNgayxuat.TabIndex = 4;
            this.lbNgayxuat.Text = "labrl8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 27);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ngày xuất:";
            // 
            // lbNguoiban
            // 
            this.lbNguoiban.AutoSize = true;
            this.lbNguoiban.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoiban.Location = new System.Drawing.Point(149, 54);
            this.lbNguoiban.Name = "lbNguoiban";
            this.lbNguoiban.Size = new System.Drawing.Size(70, 27);
            this.lbNguoiban.TabIndex = 2;
            this.lbNguoiban.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 27);
            this.label5.TabIndex = 1;
            this.label5.Text = "Người bán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thông tin hóa đơn";
            // 
            // frmHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 598);
            this.Controls.Add(this.pnlHoadon);
            this.Controls.Add(this.panel1);
            this.Name = "frmHoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoadon";
            this.Load += new System.EventHandler(this.frmHoadon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHoadon.ResumeLayout(false);
            this.pnlHoadon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel lkLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHoadon;
        private System.Windows.Forms.Label lbNgayxuat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbNguoiban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbThanhtien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgvHoadon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXuatHD;
    }
}