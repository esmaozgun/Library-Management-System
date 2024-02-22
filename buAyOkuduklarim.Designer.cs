namespace LibraryManagementSystem
{
    partial class buAyOkuduklarim
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
            this.encokodunc1CikisBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(847, 446);
            this.dataGridView1.TabIndex = 25;
            // 
            // encokodunc1CikisBtn
            // 
            this.encokodunc1CikisBtn.BackColor = System.Drawing.Color.Gray;
            this.encokodunc1CikisBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encokodunc1CikisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.encokodunc1CikisBtn.ForeColor = System.Drawing.Color.Black;
            this.encokodunc1CikisBtn.Location = new System.Drawing.Point(900, 12);
            this.encokodunc1CikisBtn.Name = "encokodunc1CikisBtn";
            this.encokodunc1CikisBtn.Size = new System.Drawing.Size(44, 40);
            this.encokodunc1CikisBtn.TabIndex = 27;
            this.encokodunc1CikisBtn.Text = "x";
            this.encokodunc1CikisBtn.UseVisualStyleBackColor = false;
            this.encokodunc1CikisBtn.Click += new System.EventHandler(this.encokodunc1CikisBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(300, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 240);
            this.label1.TabIndex = 26;
            this.label1.Text = "Bu Ay Okuduğum Eserler\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // buAyOkuduklarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(956, 582);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.encokodunc1CikisBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "buAyOkuduklarim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "buAyOkuduklarim";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button encokodunc1CikisBtn;
        private System.Windows.Forms.Label label1;
    }
}