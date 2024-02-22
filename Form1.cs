using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // mssql'den veri çekmek için kullandığım kütüphane
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void formdanCikisBtn1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
                //Eğer ekrana gelen soruya evet cevabı alırsan uygulamayı kapat, hayır cevabı alırsan messageboxu kapat
            }

        }


        private void txtKullaniciAdi_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                txtKullaniciAdi.Clear(); // Eğer bu textboxın içinde "Kullanıcı Adı" yazıyorsa textboxa tıklandığında içeriyi temizle
            }
        }
        private void txtSifre_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtParola.Text == "Parola")
            {
                txtParola.Clear();
                txtParola.PasswordChar = '*'; //şifre girilmeye başlandıktan sonra karakterlerin yıldız şeklinde gözükmesini sağla
            }
        
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "data source = OZGUN\\OZGUNSQL ; Initial Catalog =KutuphaneOtomasyonu ;integrated security=True";
            ;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT KullaniciTipi FROM Giris WHERE KullaniciAdi = @KullaniciAdi AND Parola = @Parola";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                    command.Parameters.AddWithValue("@Parola", txtParola.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string kullanicitipi = reader["KullaniciTipi"].ToString();

                            if (kullanicitipi == "Uye")
                            {
                                // Üye formunu aç
                                menu2 m2 = new menu2();
                                m2.Show();
                                MessageBox.Show("Giriş Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (kullanicitipi == "Personel")
                            {
                                // Personel formunu aç
                                menu1 m1 = new menu1();
                                m1.Show();
                                MessageBox.Show("Giriş Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

        

      

        
    }
 
