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

    //private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";


    public partial class dergiEkle2 : Form
    {
        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";

        public dergiEkle2()
        {
            InitializeComponent();
        }


        public SqlConnection sqlConnection { get; private set; }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //girilen değerleri aldım
                string dergiadi = txtdergiadi.Text;
                string issnno = txtissnno.Text;
                string yayinlanmatarihi = txtyayinlanmatarihi.Text;
                string sayfasayisi = txtsayfasayisi.Text;
                string dergisayisi = txtdergisayisi.Text;
                string kategori = txtkategori.Text;
                string kopyasayisi = txtkopyasayisi.Text;
                string yayineviadi = txtyayinevi.Text;
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
                            // Eğer yer yoksa, yeni bir yer oluştur
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
                    using (SqlCommand kalanCommand = new SqlCommand("INSERT INTO Dergi (DergiAdi, ISSNno, DergiSayisi, SayfaSayisi, KategoriID, YayineviID, KopyaSayisi, YerID, OzetBilgi, YayinlanmaTarihi, KapakGorseli) " +
                                                                                "VALUES (@DergiAdi, @ISSNno, @DergiSayisi, @SayfaSayisi, @KategoriID, @YayineviID, @KopyaSayisi, @YerID, @OzetBilgi, @YayinlanmaTarihi, @KapakGorseli)", sqlConnection))
                    {
                        kalanCommand.Parameters.AddWithValue("@DergiAdi", dergiadi);
                        kalanCommand.Parameters.AddWithValue("@ISSNno", issnno);
                        kalanCommand.Parameters.AddWithValue("@DergiSayisi", dergisayisi);
                        kalanCommand.Parameters.AddWithValue("@SayfaSayisi", sayfasayisi);
                        kalanCommand.Parameters.AddWithValue("@KategoriID", KategoriID);
                        kalanCommand.Parameters.AddWithValue("@YayineviID", YayineviID);
                        kalanCommand.Parameters.AddWithValue("@KopyaSayisi", kopyasayisi);
                        kalanCommand.Parameters.AddWithValue("@YerID", YerID);
                        kalanCommand.Parameters.AddWithValue("@OzetBilgi", ozetbilgi);
                        kalanCommand.Parameters.AddWithValue("@KapakGorseli", kapakgorseli);
                        kalanCommand.Parameters.Add("@YayinlanmaTarihi", SqlDbType.DateTime).Value = yayinlanmatarihi;

                        kalanCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dergi ekleme işlemi başarıyla tamamlandı.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
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
