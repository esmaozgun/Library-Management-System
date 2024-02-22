namespace LibraryManagementSystem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.girisBtn = new System.Windows.Forms.Button();
            this.uyeolBtn = new System.Windows.Forms.Button();
            this.formdanCikisBtn1 = new System.Windows.Forms.Button();
            this.dildegistirmeBtn = new System.Windows.Forms.Button();
            this.dildegistirme2Btn = new System.Windows.Forms.Button();
            this.dildegistirme3Btn = new System.Windows.Forms.Button();
            this.dildegistirme4Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(414, 308);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(414, 421);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(508, 52);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(140, 121);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(282, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(618, 49);
            this.label1.TabIndex = 3;
            this.label1.Text = "Atatürk Kütüphanesine Hoş Geldiniz";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(495, 325);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(224, 29);
            this.txtKullaniciAdi.TabIndex = 4;
            this.txtKullaniciAdi.Text = "Kullanıcı Adı";
            this.txtKullaniciAdi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtKullaniciAdi_MouseClick);
            // 
            // txtParola
            // 
            this.txtParola.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtParola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParola.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtParola.ForeColor = System.Drawing.Color.Black;
            this.txtParola.Location = new System.Drawing.Point(495, 435);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(224, 29);
            this.txtParola.TabIndex = 5;
            this.txtParola.Text = "Parola";
            this.txtParola.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSifre_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(495, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 2);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(495, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 2);
            this.panel1.TabIndex = 8;
            // 
            // girisBtn
            // 
            this.girisBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.girisBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.girisBtn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisBtn.ForeColor = System.Drawing.Color.Black;
            this.girisBtn.Location = new System.Drawing.Point(340, 518);
            this.girisBtn.Name = "girisBtn";
            this.girisBtn.Size = new System.Drawing.Size(219, 48);
            this.girisBtn.TabIndex = 9;
            this.girisBtn.Text = "Giriş Yap";
            this.girisBtn.UseVisualStyleBackColor = false;
            this.girisBtn.Click += new System.EventHandler(this.girisBtn_Click);
            // 
            // uyeolBtn
            // 
            this.uyeolBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.uyeolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uyeolBtn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeolBtn.ForeColor = System.Drawing.Color.Black;
            this.uyeolBtn.Location = new System.Drawing.Point(592, 517);
            this.uyeolBtn.Name = "uyeolBtn";
            this.uyeolBtn.Size = new System.Drawing.Size(233, 49);
            this.uyeolBtn.TabIndex = 10;
            this.uyeolBtn.Text = "Üye Ol";
            this.uyeolBtn.UseVisualStyleBackColor = false;
            // 
            // formdanCikisBtn1
            // 
            this.formdanCikisBtn1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.formdanCikisBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.formdanCikisBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formdanCikisBtn1.ForeColor = System.Drawing.Color.Black;
            this.formdanCikisBtn1.Location = new System.Drawing.Point(1143, 20);
            this.formdanCikisBtn1.Name = "formdanCikisBtn1";
            this.formdanCikisBtn1.Size = new System.Drawing.Size(44, 40);
            this.formdanCikisBtn1.TabIndex = 11;
            this.formdanCikisBtn1.Text = "x";
            this.formdanCikisBtn1.UseVisualStyleBackColor = false;
            this.formdanCikisBtn1.Click += new System.EventHandler(this.formdanCikisBtn1_Click);
            // 
            // dildegistirmeBtn
            // 
            this.dildegistirmeBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dildegistirmeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dildegistirmeBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dildegistirmeBtn.ForeColor = System.Drawing.Color.Black;
            this.dildegistirmeBtn.Location = new System.Drawing.Point(999, 431);
            this.dildegistirmeBtn.Name = "dildegistirmeBtn";
            this.dildegistirmeBtn.Size = new System.Drawing.Size(176, 43);
            this.dildegistirmeBtn.TabIndex = 17;
            this.dildegistirmeBtn.Text = "English";
            this.dildegistirmeBtn.UseVisualStyleBackColor = false;
            // 
            // dildegistirme2Btn
            // 
            this.dildegistirme2Btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dildegistirme2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dildegistirme2Btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dildegistirme2Btn.ForeColor = System.Drawing.Color.Black;
            this.dildegistirme2Btn.Location = new System.Drawing.Point(999, 480);
            this.dildegistirme2Btn.Name = "dildegistirme2Btn";
            this.dildegistirme2Btn.Size = new System.Drawing.Size(176, 43);
            this.dildegistirme2Btn.TabIndex = 18;
            this.dildegistirme2Btn.Text = "German";
            this.dildegistirme2Btn.UseVisualStyleBackColor = false;
            // 
            // dildegistirme3Btn
            // 
            this.dildegistirme3Btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dildegistirme3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dildegistirme3Btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dildegistirme3Btn.ForeColor = System.Drawing.Color.Black;
            this.dildegistirme3Btn.Location = new System.Drawing.Point(999, 529);
            this.dildegistirme3Btn.Name = "dildegistirme3Btn";
            this.dildegistirme3Btn.Size = new System.Drawing.Size(176, 43);
            this.dildegistirme3Btn.TabIndex = 19;
            this.dildegistirme3Btn.Text = "Français";
            this.dildegistirme3Btn.UseVisualStyleBackColor = false;
            // 
            // dildegistirme4Btn
            // 
            this.dildegistirme4Btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dildegistirme4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dildegistirme4Btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dildegistirme4Btn.ForeColor = System.Drawing.Color.Black;
            this.dildegistirme4Btn.Location = new System.Drawing.Point(999, 578);
            this.dildegistirme4Btn.Name = "dildegistirme4Btn";
            this.dildegistirme4Btn.Size = new System.Drawing.Size(176, 43);
            this.dildegistirme4Btn.TabIndex = 20;
            this.dildegistirme4Btn.Text = "中国人";
            this.dildegistirme4Btn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1209, 655);
            this.ControlBox = false;
            this.Controls.Add(this.dildegistirme4Btn);
            this.Controls.Add(this.dildegistirme3Btn);
            this.Controls.Add(this.dildegistirme2Btn);
            this.Controls.Add(this.dildegistirmeBtn);
            this.Controls.Add(this.formdanCikisBtn1);
            this.Controls.Add(this.uyeolBtn);
            this.Controls.Add(this.girisBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Sayfası";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button girisBtn;
        private System.Windows.Forms.Button uyeolBtn;
        private System.Windows.Forms.Button formdanCikisBtn1;
        private System.Windows.Forms.Button dildegistirmeBtn;
        private System.Windows.Forms.Button dildegistirme2Btn;
        private System.Windows.Forms.Button dildegistirme3Btn;
        private System.Windows.Forms.Button dildegistirme4Btn;
    }
}

