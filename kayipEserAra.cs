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
    public partial class kayipEserAra : Form
    {
        public kayipEserAra()
        {
            InitializeComponent();
        }

        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();

            }
        }
    }
}
