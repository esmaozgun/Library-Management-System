namespace LibraryManagementSystem
{
    partial class SuresiDolan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.encokodunc1CikisBtn = new System.Windows.Forms.Button();
            this.cezabtn1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(76, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(108, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(786, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eser Teslim Etme Süresi Dolan ve Teslim Etmeyen Üyeler\r\n";
            // 
            // encokodunc1CikisBtn
            // 
            this.encokodunc1CikisBtn.BackColor = System.Drawing.Color.DarkGray;
            this.encokodunc1CikisBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encokodunc1CikisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.encokodunc1CikisBtn.ForeColor = System.Drawing.Color.Black;
            this.encokodunc1CikisBtn.Location = new System.Drawing.Point(972, 12);
            this.encokodunc1CikisBtn.Name = "encokodunc1CikisBtn";
            this.encokodunc1CikisBtn.Size = new System.Drawing.Size(44, 40);
            this.encokodunc1CikisBtn.TabIndex = 12;
            this.encokodunc1CikisBtn.Text = "x";
            this.encokodunc1CikisBtn.UseVisualStyleBackColor = false;
            this.encokodunc1CikisBtn.Click += new System.EventHandler(this.encokodunc1CikisBtn_Click);
            // 
            // cezabtn1
            // 
            this.cezabtn1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cezabtn1.Location = new System.Drawing.Point(334, 499);
            this.cezabtn1.Name = "cezabtn1";
            this.cezabtn1.Size = new System.Drawing.Size(338, 63);
            this.cezabtn1.TabIndex = 13;
            this.cezabtn1.Text = "Ceza Yaz";
            this.cezabtn1.UseVisualStyleBackColor = true;
            this.cezabtn1.Click += new System.EventHandler(this.cezabtn1_Click);
            // 
            // SuresiDolan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1040, 600);
            this.Controls.Add(this.cezabtn1);
            this.Controls.Add(this.encokodunc1CikisBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuresiDolan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hizliislemSuresiDolan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button encokodunc1CikisBtn;
        private System.Windows.Forms.Button cezabtn1;
    }
}