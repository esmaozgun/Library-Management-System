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
    public partial class kitapEkle : Form
    {
        private string connectionString ="Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";

        public kitapEkle()
        {
            InitializeComponent();
        }

        public SqlConnection sqlConnection { get; private set; }

        private void ekleBtn_Click(object sender, EventArgs e)
        {

            try
            {
                //girilen değerleri aldım
                string kitapadi = txtkitapadi.Text;
                string kitapyazari = txtkitapyazari.Text;
                string isbnno = txtisbnno.Text;
                string yayinlanmatarihi = txtyayinlanmatarihi.Text;
                string sayfasayisi = txtsayfasayisi.Text;
                string kategori = txtkategori.Text;
                string kopyasayisi = txtkopyasayisi.Text;
                string yayineviadi = txtyayineviadi.Text;
                string bina = txtbina.Text;
                string kat = txtkat.Text;
                string salon = txtsalon.Text;
                string kitaplik = txtkitaplik.Text;
                string raf = txtraf.Text;
                string ozetbilgi = txtozetbilgi.Text;
                string kapakgorseli = txtkapakgorseli.Text;


                // SQL bağlantısını oluşturdum
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    int KategoriID;
                    using (SqlCommand kategoriCommand = new SqlCommand("SELECT KategoriId FROM Kategori WHERE KategoriAdi = @KategoriAdi", sqlConnection))
                    {
                        kategoriCommand.Parameters.AddWithValue("@KategoriAdi", kategori);
                        object result = kategoriCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Eğer kategori yoksa, yeni bir kategori oluştur
                            using (SqlCommand insertkategoriCommand = new SqlCommand("INSERT INTO Kategori (KategoriAdi)" +
                                " VALUES (@KategoriAdi); " +
                                "SELECT SCOPE_IDENTITY();", sqlConnection))
                            {
                                insertkategoriCommand.Parameters.AddWithValue("@KategoriAdi", kategori);
                                KategoriID = Convert.ToInt32(insertkategoriCommand.ExecuteScalar());
                            }
                        }
                        else
                        {
                            KategoriID = Convert.ToInt32(result);
                        }
                    }

                    int YazarID;
                    using (SqlCommand yazarCommand = new SqlCommand("SELECT YazarID FROM Yazar WHERE YazarAdi = @YazarAdi", sqlConnection))
                    {
                        yazarCommand.Parameters.AddWithValue("@YazarAdi", kitapyazari);
                        object result = yazarCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Eğer yazar yoksa, yeni bir yazar oluştur.
                            using (SqlCommand insertyazarCommand = new SqlCommand("INSERT INTO Yazar (YazarAdi)" +
                                " VALUES (@YazarAdi); " +
                                "SELECT SCOPE_IDENTITY();", sqlConnection))
                            // Bağlantı ve scope(erişilebilirlik) bakmaksızın, parametre olarak verilen tabloda üretilen son identity değerini döndürür.
                            {
                                insertyazarCommand.Parameters.AddWithValue("@YazarAdi", kitapyazari);

                                YazarID = Convert.ToInt32(insertyazarCommand.ExecuteScalar());
                            }
                        }
                        else
                        {
                            YazarID = Convert.ToInt32(result);
                        }
                    }


                    int YayineviID;
                    using (SqlCommand yayineviCommand = new SqlCommand("SELECT YayineviID FROM Yayinevi WHERE YayineviAdi = @YayineviAdi", sqlConnection))
                    {
                        yayineviCommand.Parameters.AddWithValue("@YayineviAdi", yayineviadi);
                        object result = yayineviCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Eğer yayınevi yoksa, yeni bir yayınevi oluştur
                            using (SqlCommand insertyayineviCommand = new SqlCommand("INSERT INTO Yayinevi (YayineviAdi)" +
                                " VALUES (@YayineviAdi); " +
                                "SELECT SCOPE_IDENTITY();", sqlConnection))
                            {
                                insertyayineviCommand.Parameters.AddWithValue("@YayineviAdi", yayineviadi);

                                YayineviID = Convert.ToInt32(insertyayineviCommand.ExecuteScalar());
                            }
                        }
                        else
                        {
                            YayineviID = Convert.ToInt32(result);
                        }
                    }


                    int YerID;
                    using (SqlCommand yerCommand = new SqlCommand("SELECT YerID FROM Yer_Bilgisi WHERE Bina = @Bina", sqlConnection))
                    {
                        yerCommand.Parameters.AddWithValue("@Bina", bina);
                        yerCommand.Parameters.AddWithValue("@Kat", kat);
                        yerCommand.Parameters.AddWithValue("@Salon", salon);
                        yerCommand.Parameters.AddWithValue("@Kitaplık", kitaplik);
                        yerCommand.Parameters.AddWithValue("@Raf", raf);
                        object result = yerCommand.ExecuteScalar();

                        if (result == null)
                        {
                            // Eğer yazar yoksa, yeni bir yazar oluştur
                            using (SqlCommand insertyerCommand = new SqlCommand("INSERT INTO Yer_Bilgisi (Bina, Kat, Salon, Kitaplik, Raf)" +
                                " VALUES (@Bina, @Kat, @Salon, @Kitaplik, @Raf); " +
                                "SELECT SCOPE_IDENTITY();", sqlConnection))
                            {
                                insertyerCommand.Parameters.AddWithValue("@Bina", bina);
                                insertyerCommand.Parameters.AddWithValue("@Kat", kat);
                                insertyerCommand.Parameters.AddWithValue("@Salon", salon);
                                insertyerCommand.Parameters.AddWithValue("@Kitaplik", kitaplik);
                                insertyerCommand.Parameters.AddWithValue("@Raf", raf);

                                YerID = Convert.ToInt32(insertyerCommand.ExecuteScalar());
                            }
                        }
                        else
                        {
                            YerID = Convert.ToInt32(result);
                        }
                    }




                    // kalan bilgileri ekleme
                    using (SqlCommand kalanCommand = new SqlCommand("INSERT INTO Kitap (KitapAdi, ISBNno, SayfaSayisi, KategoriID, YazarID, YayineviID, KopyaSayisi, YerID, OzetBilgi, YayinlanmaTarihi, KapakGorseli) " +
                                                                    "VALUES (@KitapAdi, @ISBNno, @SayfaSayisi, @KategoriID, @YazarID, @YayineviID, @KopyaSayisi, @YerID, @OzetBilgi, @YayinlanmaTarihi, @KapakGorseli)", sqlConnection))
                    {
                        kalanCommand.Parameters.AddWithValue("@KitapAdi", kitapadi); 
                        kalanCommand.Parameters.AddWithValue("@ISBNno", isbnno); 
                        kalanCommand.Parameters.AddWithValue("@SayfaSayisi", sayfasayisi);
                        kalanCommand.Parameters.AddWithValue("@KategoriID", KategoriID);
                        kalanCommand.Parameters.AddWithValue("@YazarID", YazarID);
                        kalanCommand.Parameters.AddWithValue("@YayineviID", YayineviID);
                        kalanCommand.Parameters.AddWithValue("@KopyaSayisi", kopyasayisi);
                        kalanCommand.Parameters.AddWithValue("@YerID", YerID);
                        kalanCommand.Parameters.AddWithValue("@OzetBilgi", ozetbilgi);
                        kalanCommand.Parameters.AddWithValue("@KapakGorseli", kapakgorseli);
                        kalanCommand.Parameters.Add("@YayinlanmaTarihi", SqlDbType.DateTime).Value = yayinlanmatarihi;

                        kalanCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kitap ekleme işlemi başarıyla tamamlandı.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }


        }

        private void iptalBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }
 }
    

