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
    public partial class dergiAra : Form
    {


        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";
        private EventHandler DataGridView1_SelectionChanged;

        public dergiAra()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            // DataGridView'de bir satır seçildiğinde olayı ekle.
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }



        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void dergiAra_Load(object sender, EventArgs e)
        {

            panel4.Visible = false;

        }

        private void araBtn_Click(object sender, EventArgs e)
        {
            string dergiAdi = txtdergiadi.Text.Trim();

            if (string.IsNullOrEmpty(dergiAdi))
            {
                MessageBox.Show("Lütfen dergi adını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Dergi WHERE DergiAdi LIKE @DergiAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DergiAdi", "%" + dergiAdi + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                int DergiID = Convert.ToInt32(selectedRow.Cells["DergiID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    SELECT 
                        Dergi.DergiID,
                        Dergi.DergiAdi,
                        Dergi.DergiSayisi,
                        Dergi.YayinlanmaTarihi,
                        Kategori.KategoriAdi,
                        Yayinevi.YayineviAdi,
                        Yer_Bilgisi.Bina,
                        Yer_Bilgisi.Kat,
                        Yer_Bilgisi.Salon,
                        Yer_Bilgisi.Kitaplik,
                        Yer_Bilgisi.Raf,
                        Dergi.ISSNNo,
                        Dergi.SayfaSayisi,
                        Dergi.KopyaSayisi,
                        Dergi.OzetBilgi,
                        Dergi.OduncAlinabilirMi,
                        Dergi.RezerveEdilebilirMi,
                        Dergi.Durum,
                        Dergi.KapakGorseli
                    FROM Dergi
                    INNER JOIN Kategori ON Dergi.KategoriID = Kategori.KategoriID
                    INNER JOIN Yayinevi ON Dergi.YayineviID = Yayinevi.YayineviID
                    INNER JOIN Yer_Bilgisi ON Dergi.YerID = Yer_Bilgisi.YerID
                    WHERE Dergi.DergiID = @DergiID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DergiID", DergiID);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // DataGridView'a verileri yükleme
                                dataGridView1.DataSource = dataTable;

                                // TextBox'lara verileri yerleştirme
                                if (dataTable.Rows.Count > 0)
                                {
                                    DataRow row = dataTable.Rows[0];

                                    txtdergiadi2.Text = row["DergiAdi"].ToString();
                                    txtkategori.Text = row["KategoriAdi"].ToString();
                                    txtyayinevi.Text = row["YayineviAdi"].ToString();
                                    txtdergisayisi.Text = row["DergiSayisi"].ToString();
                                    txtyayinlanmatarihi.Text = row["YayinlanmaTarihi"].ToString();
                                    txtbina.Text = row["Bina"].ToString();
                                    txtkat.Text = row["Kat"].ToString();
                                    txtsalon.Text = row["Salon"].ToString();
                                    txtkitaplik.Text = row["Kitaplik"].ToString();
                                    txtraf.Text = row["Raf"].ToString();
                                    txtissnno.Text = row["ISSNNo"].ToString();
                                    txtsayfasayisi.Text = row["SayfaSayisi"].ToString();
                                    txtkopyasayisi.Text = row["KopyaSayisi"].ToString();
                                    txtozetbilgi.Text = row["OzetBilgi"].ToString();
                                    txtdurum.Text = row["Durum"].ToString();
                                    txtodunc.Text = row["OduncAlinabilirMi"].ToString();
                                    txtrezerve.Text = row["RezerveEdilebilirMi"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçili kitabı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (!string.IsNullOrEmpty(txtdergiadi2.Text)) // Dergi adı boş olamaz
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Dergi WHERE DergiID = @DergiID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Silinecek kitabın ID'sini alın
                                int dergiID = GetDergiIDByDergiAdi(txtdergiadi2.Text);

                                // Eğer kitapID 0'dan büyükse, yani geçerli bir ID ise silme işlemi yap
                                if (dergiID > 0)
                                {
                                    command.Parameters.AddWithValue("@DergiID", dergiID);
                                    int affectedRows = command.ExecuteNonQuery();

                                    if (affectedRows > 0)
                                    {
                                        MessageBox.Show("Dergi başarıyla silindi.");

                                        // Silme işlemi gerçekleştikten sonra TextBox'ları temizle
                                        Temizle();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Dergi silinirken bir hata oluştu.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Geçerli bir dergi seçilmedi.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir dergi seçmelisiniz.");
                }
            }
        }

        // Dergi adına göre DergiID'yi almak için yardımcı bir fonksiyon
        private int GetDergiIDByDergiAdi(string dergiAdi)
        {
            int dergiID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DergiID FROM Dergi WHERE DergiAdi = @DergiAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DergiAdi", dergiAdi);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            dergiID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            return dergiID;
        }

        // TextBox'ları temizleme işlemi için yardımcı bir fonksiyon
        private void Temizle()
        {
            // TextBox'ları temizle
            txtdergiadi2.Clear();
            txtdergisayisi.Clear();
            txtkategori.Clear();
            txtyayinevi.Clear();
            txtbina.Clear();
            txtkat.Clear();
            txtsalon.Clear();
            txtkitaplik.Clear();
            txtraf.Clear();
            txtissnno.Clear();
            txtsayfasayisi.Clear();
            txtkopyasayisi.Clear();
            txtozetbilgi.Clear();
            txtodunc.Clear();
            txtrezerve.Clear();
            txtdurum.Clear();
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtdergiadi2.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                UPDATE Dergi
                SET 
                    DergiAdi = @DergiAdi,
                    KategoriID = (SELECT KategoriID FROM Kategori WHERE KategoriAdi = @KategoriAdi),
                    YayineviID = (SELECT YayineviID FROM Yayinevi WHERE YayineviAdi = @YayineviAdi), 
                    YerID = (
                        SELECT YerID
                        FROM Yer_Bilgisi 
                        WHERE 
                        Bina = @Bina AND 
                        Kat = @Kat AND 
                        Salon = @Salon AND 
                        Kitaplik = @Kitaplik AND 
                        Raf = @Raf
                                ),
                    ISSNno = @ISSNno,
                    SayfaSayisi = @SayfaSayisi,
                    KopyaSayisi = @KopyaSayisi,
                    OzetBilgi = @OzetBilgi,
                    Durum = @Durum,
                    OduncAlinabilirMi = @OduncAlinabilirMi,
                    RezerveEdilebilirMi = @RezerveEdilebilirMi
                WHERE DergiID = @DergiID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int dergiID = GetDergiIDByDergiAdi(txtdergiadi2.Text);

                            if (dergiID > 0)
                            {
                                command.Parameters.AddWithValue("@DergiID", dergiID);
                                command.Parameters.AddWithValue("@DergiAdi", txtdergiadi2.Text);
                                command.Parameters.AddWithValue("@DergiSayisi", txtdergisayisi.Text);
                                command.Parameters.AddWithValue("@KategoriAdi", txtkategori.Text);
                                command.Parameters.AddWithValue("@YayineviAdi", txtyayinevi.Text);
                                command.Parameters.AddWithValue("@Bina", txtbina.Text);
                                command.Parameters.AddWithValue("@Kat", txtkat.Text);
                                command.Parameters.AddWithValue("@Salon", txtsalon.Text);
                                command.Parameters.AddWithValue("@Kitaplik", txtkitaplik.Text);
                                command.Parameters.AddWithValue("@Raf", txtraf.Text);
                                command.Parameters.AddWithValue("@ISSNNo", txtissnno.Text);
                                command.Parameters.AddWithValue("@SayfaSayisi", Convert.ToInt32(txtsayfasayisi.Text));
                                command.Parameters.AddWithValue("@KopyaSayisi", Convert.ToInt32(txtkopyasayisi.Text));
                                command.Parameters.AddWithValue("@OzetBilgi", txtozetbilgi.Text);
                                command.Parameters.AddWithValue("@OduncAlinabilirMi", txtodunc.Text);
                                command.Parameters.AddWithValue("@RezerveEdilebilirMi", txtrezerve.Text);
                                command.Parameters.AddWithValue("@Durum", txtdurum.Text);

                                int affectedRows = command.ExecuteNonQuery();

                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Dergi başarıyla güncellendi.");

                                    // Güncelleme işlemi başarılı olduğunda TextBox'ları temizle
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Dergi güncellenirken bir hata oluştu.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir dergi seçilmedi.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Güncellemek için bir dergi seçmelisiniz.");
            }
        }
    }
}
