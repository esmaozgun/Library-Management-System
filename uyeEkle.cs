using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class uyeEkle : Form
    {

        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";



        public uyeEkle()
        {
            InitializeComponent();
        }

     

        private void uyeekleBtn_Click(object sender, EventArgs e)
        {

            try
            {
                //girilen değerleri aldım
                string uyeadi = txtuyeadi.Text;
                string uyesoyadi = txtuyesoyadi.Text;
                string kaydolmatarihi = txtkaydolmatarihi.Text;
                string ogrencino = txtogrencino.Text;
                string tcno = txttcno.Text;
                string email = txtemail.Text;
                string pasno = txtpasno.Text;
                string telno = txttelno.Text;
                string kadi = txtkadi.Text;
                string parola = txtparola.Text;
                string ktip = txtktip.Text;



                // SQL bağlantısını oluşturdum
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    int GirisID;
                    using (SqlCommand girisCommand = new SqlCommand("SELECT GirisId FROM Giris WHERE KullaniciAdi = @KullaniciAdi", sqlConnection))
                    {
                        girisCommand.Parameters.AddWithValue("@KullaniciAdi", kadi);
                        object result = girisCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Eğer giriş yoksa, yeni bir giriş oluştur
                            using (SqlCommand insertgirisCommand = new SqlCommand("INSERT INTO Giris (KullaniciAdi, Parola, KullaniciTipi) " +
                                "VALUES (@KullaniciAdi, @Parola, @KullaniciTipi); " +
                                "SELECT SCOPE_IDENTITY();", sqlConnection))
                            {
                                insertgirisCommand.Parameters.AddWithValue("@KullaniciAdi", kadi);
                                insertgirisCommand.Parameters.AddWithValue("@Parola", parola);
                                insertgirisCommand.Parameters.AddWithValue("@KullaniciTipi", ktip);

                                GirisID = Convert.ToInt32(insertgirisCommand.ExecuteScalar());
                            }
                        }
                        else
                        {
                            GirisID = Convert.ToInt32(result);
                        }
                    }




                    // üye bilgisi ekleme
                    using (SqlCommand bilgiCommand = new SqlCommand("INSERT INTO Uye (UyeAdi, UyeSoyadi, OgrenciNo, Tcno, Email, Telno, " +
                        "KaydolmaTarihi, Pasaportno, GirisID) " +
                        "VALUES (@UyeAdi, @UyeSoyadi, @OgrenciNo, @Tcno, @Email, @Telno, @KaydolmaTarihi, @Pasaportno, @GirisID)",
                        sqlConnection))
                    {
                        bilgiCommand.Parameters.AddWithValue("@UyeAdi", uyeadi);
                        bilgiCommand.Parameters.AddWithValue("@UyeSoyadi", uyesoyadi);
                        bilgiCommand.Parameters.AddWithValue("@OgrenciNo", ogrencino);
                        bilgiCommand.Parameters.AddWithValue("@Tcno", tcno);
                        bilgiCommand.Parameters.AddWithValue("@Email", email);
                        bilgiCommand.Parameters.AddWithValue("@Telno", telno);
                        //bilgiCommand.Parameters.AddWithValue("@KaydolmaTarihi", kaydolmatarihi);
                        bilgiCommand.Parameters.AddWithValue("@Pasaportno", pasno);
                        bilgiCommand.Parameters.AddWithValue("@GirisID", GirisID);
                        bilgiCommand.Parameters.Add("@KaydolmaTarihi", SqlDbType.DateTime).Value = kaydolmatarihi;

                        bilgiCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Üye ekleme işlemi başarıyla tamamlandı.");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

     

        private void formdanCikisBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
    }


