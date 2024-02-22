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
    public partial class menu2 : Form
    {
        public menu2()
        {
            InitializeComponent();
        }

        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
                //Eğer ekrana gelen soruya evet cevabı alırsan uygulamayı kapat, hayır cevabı alırsan messageboxu kapat
            }
        }

        private void kitapAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapAra ka = new kitapAra();
            ka.Show();
        }

        private void dergiAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dergiAra da = new dergiAra();
            da.Show();
        }

        private void kitapRezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapAra ka = new kitapAra();
            ka.Show();
        }

        private void dergiRezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dergiAra da = new dergiAra();
            da.Show();
        }

        private void odunKitapAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapAra ka = new kitapAra();
            ka.Show();
        }


        private void ödünçDergiAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dergiAra da = new dergiAra();
            da.Show();
        }

        private void teslimEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen personelden yardım isteyiniz.", "Yardım", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        }


        private void cezaOdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen personelden yardım isteyiniz.", "Yardım", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void okudugumTumEserlertoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            okudugumTumEserler ote = new okudugumTumEserler();
            ote.Show();
        }

        private void buAyOkuduklarimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buAyOkuduklarim bao = new buAyOkuduklarim();
            bao.Show();
        }

        private void buSeneOkuduklarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buSeneOkuduklarim bso = new buSeneOkuduklarim();
            bso.Show();
        }

        private void buayencokokunangorBtn_Click(object sender, EventArgs e)
        {
            BuAyEnCokOkunan baeco = new BuAyEnCokOkunan();
            baeco.Show();

        }

        private void tumzmnencokBtn_Click(object sender, EventArgs e)
        {
            TumZamanlarECO tzeco = new TumZamanlarECO();
            tzeco.Show();
        }

        private void turkedbgorBtn_Click(object sender, EventArgs e)
        {
            TurkEdbEserleri tee = new TurkEdbEserleri();
            tee.Show();
        }

        private void jpnedbeserBtn_Click(object sender, EventArgs e)
        {
            JaponEdbEserleri jee = new JaponEdbEserleri(); 
            jee.Show();
        }

       
    }
}
