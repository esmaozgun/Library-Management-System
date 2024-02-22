using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class buAyOkuduklarim : Form
    {
        public buAyOkuduklarim()
        {
            InitializeComponent();
        }

        private void encokodunc1CikisBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
