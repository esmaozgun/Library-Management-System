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
    public partial class cezaYaz : Form
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";
        public cezaYaz()
        {
            InitializeComponent();
        }

        private void cezaYaz_Load(object sender, EventArgs e)
        {

        }

        private void formdanCikisBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();

            }
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı textbox'larından değerleri al
            string kullaniciAdi = txtkullaniciadi.Text;
            string miktar = txtmiktar.Text;

            // Kullanıcı adı boş olmamalı
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kullanıcı adına göre UyeID'yi al
                    int uyeID;
                    string uyeIDQuery = "SELECT U.* FROM UYE U INNER JOIN Giris G ON U.GirisID = G.GirisID WHERE G.KullaniciAdi LIKE @KullaniciAdi";
                    using (SqlCommand cmd = new SqlCommand(uyeIDQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        uyeID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    

                    // Ceza tablosuna yeni kayıt ekle
                    string cezaEkleQuery = "INSERT INTO Ceza (UyeID, BaslangicTarihi, CezaTutari, SonOdemeTarihi) " +
                        "VALUES (@UyeID, @BaslangicTarihi, @CezaTutari, @SonOdemeTarihi)";
                    using (SqlCommand cmd = new SqlCommand(cezaEkleQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UyeID", uyeID);
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CezaTutari", miktar);
                        cmd.Parameters.AddWithValue("@SonOdemeTarihi", DateTime.Now.AddDays(15));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ceza başarıyla eklendi.");

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
