namespace HospitalApp
{
    partial class FrmDlgAyar
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
            this.label1 = new System.Windows.Forms.Label();
            this.edtServer = new System.Windows.Forms.TextBox();
            this.edtDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbBaglanti = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.edtYetkiKod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edtIsYeriNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtFirmaNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtDonem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edtSayKodDeger = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbBaglanti.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sunucu";
            // 
            // edtServer
            // 
            this.edtServer.Location = new System.Drawing.Point(94, 12);
            this.edtServer.Name = "edtServer";
            this.edtServer.Size = new System.Drawing.Size(183, 20);
            this.edtServer.TabIndex = 3;
            // 
            // edtDB
            // 
            this.edtDB.Location = new System.Drawing.Point(94, 38);
            this.edtDB.Name = "edtDB";
            this.edtDB.Size = new System.Drawing.Size(183, 20);
            this.edtDB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Database";
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(94, 64);
            this.edtUser.Name = "edtUser";
            this.edtUser.Size = new System.Drawing.Size(183, 20);
            this.edtUser.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kullanıcı";
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(94, 90);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.PasswordChar = '♦';
            this.edtPassword.Size = new System.Drawing.Size(183, 20);
            this.edtPassword.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Şifre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Bağlantı Bilgilerini Sına";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbBaglanti);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 179);
            this.tabControl1.TabIndex = 11;
            // 
            // tbBaglanti
            // 
            this.tbBaglanti.Controls.Add(this.label1);
            this.tbBaglanti.Controls.Add(this.button1);
            this.tbBaglanti.Controls.Add(this.edtServer);
            this.tbBaglanti.Controls.Add(this.edtPassword);
            this.tbBaglanti.Controls.Add(this.label2);
            this.tbBaglanti.Controls.Add(this.label5);
            this.tbBaglanti.Controls.Add(this.label4);
            this.tbBaglanti.Controls.Add(this.edtDB);
            this.tbBaglanti.Controls.Add(this.edtUser);
            this.tbBaglanti.Controls.Add(this.label3);
            this.tbBaglanti.Location = new System.Drawing.Point(4, 22);
            this.tbBaglanti.Name = "tbBaglanti";
            this.tbBaglanti.Padding = new System.Windows.Forms.Padding(3);
            this.tbBaglanti.Size = new System.Drawing.Size(293, 153);
            this.tbBaglanti.TabIndex = 0;
            this.tbBaglanti.Text = "Bağlantı Bilgileri";
            this.tbBaglanti.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Firma No";
            this.label5.Visible = false;
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Image = global::HospitalApp.Properties.Resources.I24_Dur;
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(215, 184);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(79, 30);
            this.btnCikis.TabIndex = 13;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.Image = global::HospitalApp.Properties.Resources.I24_Onayla;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(122, 184);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(87, 30);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.edtYetkiKod);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.edtIsYeriNo);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.edtFirmaNo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.edtDonem);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.edtSayKodDeger);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 153);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Parametreler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // edtYetkiKod
            // 
            this.edtYetkiKod.Location = new System.Drawing.Point(118, 108);
            this.edtYetkiKod.Name = "edtYetkiKod";
            this.edtYetkiKod.Size = new System.Drawing.Size(71, 20);
            this.edtYetkiKod.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Yetki Kodu";
            // 
            // edtIsYeriNo
            // 
            this.edtIsYeriNo.Location = new System.Drawing.Point(118, 82);
            this.edtIsYeriNo.Name = "edtIsYeriNo";
            this.edtIsYeriNo.Size = new System.Drawing.Size(71, 20);
            this.edtIsYeriNo.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "İşYeri No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Firm.No";
            // 
            // edtFirmaNo
            // 
            this.edtFirmaNo.Location = new System.Drawing.Point(118, 43);
            this.edtFirmaNo.Name = "edtFirmaNo";
            this.edtFirmaNo.Size = new System.Drawing.Size(34, 20);
            this.edtFirmaNo.TabIndex = 27;
            this.edtFirmaNo.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Dönem";
            // 
            // edtDonem
            // 
            this.edtDonem.Location = new System.Drawing.Point(212, 43);
            this.edtDonem.Name = "edtDonem";
            this.edtDonem.Size = new System.Drawing.Size(39, 20);
            this.edtDonem.TabIndex = 25;
            this.edtDonem.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Sayısal Kod Değeri";
            // 
            // edtSayKodDeger
            // 
            this.edtSayKodDeger.Location = new System.Drawing.Point(118, 17);
            this.edtSayKodDeger.Name = "edtSayKodDeger";
            this.edtSayKodDeger.Size = new System.Drawing.Size(135, 20);
            this.edtSayKodDeger.TabIndex = 23;
            // 
            // FrmDlgAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.ControlBox = false;
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDlgAyar";
            this.Text = "Ayarlar";
            this.tabControl1.ResumeLayout(false);
            this.tbBaglanti.ResumeLayout(false);
            this.tbBaglanti.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtServer;
        private System.Windows.Forms.TextBox edtDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbBaglanti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox edtYetkiKod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edtIsYeriNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtFirmaNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtDonem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edtSayKodDeger;
    }
}