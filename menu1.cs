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
    public partial class menu1 : Form
    {
        public menu1()
        {
            InitializeComponent();
        }

        private void formdanCikisBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
                //Eğer ekrana gelen soruya evet cevabı alırsan uygulamayı kapat, hayır cevabı alırsan messageboxu kapat
            }
        }


        private void encokokunangorBtn_Click(object sender, EventArgs e)
        {
           BuAyEnCokOkunan baeco = new BuAyEnCokOkunan();   
           baeco.Show();   
        }

        private void suresidolanicintiklaBtn_Click(object sender, EventArgs e)
        {
            SuresiDolan sd = new SuresiDolan(); //yeni forma geçiş yapması için nesne oluşturdum
            sd.Show(); // showdialog yerine show kullandım çünkü showdialog dediğimde birden fazla form yönetilmiyor
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeEkle ue = new uyeEkle();
            ue.Show();
        }

        private void uyearasilguncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyeAra ua = new uyeAra();
            ua.Show();
        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapEkle ke = new kitapEkle();
            ke.Show();
        }

        private void kitaparasilguncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapAra ka = new kitapAra();
            ka.Show();
        }


        private void dergiAraSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dergiAra da = new dergiAra();
            da.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            PersonelEkle pe = new PersonelEkle();
            pe.Show();
        }


        private void dergiEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dergiEkle2 de2 = new dergiEkle2();
            de2.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            personelAra pa = new personelAra();
            pa.Show();
        }

        private void cezayazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cezaYaz cy = new cezaYaz();
            cy.Show();
        }

        private void cezaaraSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cezaSil cs = new cezaSil();
            cs.Show();
        }

        private void süresiDolanVeTeslimEdilmeyenKitaplarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuresiDolan sd = new SuresiDolan();
            sd.Show();
        }

        private void ödünçAlınanKitaplarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oduncEserVerme oev = new oduncEserVerme();
            oev.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            kayipEserEkle kee = new kayipEserEkle();
            kee.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            kayipEserAra kea = new kayipEserAra();
            kea.Show();
        }
    }
    }
