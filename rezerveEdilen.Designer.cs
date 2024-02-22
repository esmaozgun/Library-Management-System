namespace LibraryManagementSystem
{
    partial class rezerveEdilen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rezerveEdilen));
            this.encokodunc1CikisBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.temizleBtn2 = new System.Windows.Forms.Button();
            this.DrgAdiAraBtn = new System.Windows.Forms.Button();
            this.txtDergiAdi = new System.Windows.Forms.TextBox();
            this.DergiAdiLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // encokodunc1CikisBtn
            // 
            this.encokodunc1CikisBtn.BackColor = System.Drawing.Color.Gray;
            this.encokodunc1CikisBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encokodunc1CikisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.encokodunc1CikisBtn.ForeColor = System.Drawing.Color.Black;
            this.encokodunc1CikisBtn.Location = new System.Drawing.Point(916, 12);
            this.encokodunc1CikisBtn.Name = "encokodunc1CikisBtn";
            this.encokodunc1CikisBtn.Size = new System.Drawing.Size(44, 40);
            this.encokodunc1CikisBtn.TabIndex = 30;
            this.encokodunc1CikisBtn.Text = "x";
            this.encokodunc1CikisBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(293, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 240);
            this.label1.TabIndex = 29;
            this.label1.Text = "Rezerve Edilen Eser Kayıtları\r\n\r\n\r\n\r\n\r\n\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(393, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(556, 233);
            this.dataGridView1.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.temizleBtn2);
            this.panel1.Controls.Add(this.DrgAdiAraBtn);
            this.panel1.Controls.Add(this.txtDergiAdi);
            this.panel1.Controls.Add(this.DergiAdiLabel);
            this.panel1.Location = new System.Drawing.Point(35, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 548);
            this.panel1.TabIndex = 31;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(200, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Temizle";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.IndianRed;
            this.button3.Location = new System.Drawing.Point(69, 475);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "Ara";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 22);
            this.textBox1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(15, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "Dergi Adı:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(69, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // temizleBtn2
            // 
            this.temizleBtn2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.temizleBtn2.ForeColor = System.Drawing.Color.IndianRed;
            this.temizleBtn2.Location = new System.Drawing.Point(200, 344);
            this.temizleBtn2.Name = "temizleBtn2";
            this.temizleBtn2.Size = new System.Drawing.Size(107, 36);
            this.temizleBtn2.TabIndex = 8;
            this.temizleBtn2.Text = "Temizle";
            this.temizleBtn2.UseVisualStyleBackColor = true;
            // 
            // DrgAdiAraBtn
            // 
            this.DrgAdiAraBtn.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DrgAdiAraBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.DrgAdiAraBtn.Location = new System.Drawing.Point(69, 344);
            this.DrgAdiAraBtn.Name = "DrgAdiAraBtn";
            this.DrgAdiAraBtn.Size = new System.Drawing.Size(100, 36);
            this.DrgAdiAraBtn.TabIndex = 5;
            this.DrgAdiAraBtn.Text = "Ara";
            this.DrgAdiAraBtn.UseVisualStyleBackColor = true;
            // 
            // txtDergiAdi
            // 
            this.txtDergiAdi.Location = new System.Drawing.Point(154, 296);
            this.txtDergiAdi.Name = "txtDergiAdi";
            this.txtDergiAdi.Size = new System.Drawing.Size(181, 22);
            this.txtDergiAdi.TabIndex = 1;
            // 
            // DergiAdiLabel
            // 
            this.DergiAdiLabel.AutoSize = true;
            this.DergiAdiLabel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DergiAdiLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.DergiAdiLabel.Location = new System.Drawing.Point(17, 290);
            this.DergiAdiLabel.Name = "DergiAdiLabel";
            this.DergiAdiLabel.Size = new System.Drawing.Size(105, 28);
            this.DergiAdiLabel.TabIndex = 1;
            this.DergiAdiLabel.Text = "Kitap Adı:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(393, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 73);
            this.panel2.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.IndianRed;
            this.button2.Location = new System.Drawing.Point(173, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Kayıt Sil";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(393, 314);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(556, 230);
            this.dataGridView2.TabIndex = 35;
            // 
            // rezerveEdilen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(979, 649);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.encokodunc1CikisBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "rezerveEdilen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rezerveEdilen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button encokodunc1CikisBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button temizleBtn2;
        private System.Windows.Forms.Button DrgAdiAraBtn;
        private System.Windows.Forms.TextBox txtDergiAdi;
        private System.Windows.Forms.Label DergiAdiLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}