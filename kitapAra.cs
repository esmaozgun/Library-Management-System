using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class kitapAra : Form

    {

        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";


        public kitapAra()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            // DataGridView'de bir satır seçildiğinde olayı ekleyin.
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        public EventHandler DataGridView1_SelectionChanged { get; private set; }

        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // DataGridView'de bir satır seçildiğinde, seçilen satırdaki verileri TextBox'lara doldurun.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Örneğin, KitapAdi ve YazarAdi kolonlarını aldım.
                string kitapAdi = selectedRow.Cells["KitapAdi"].Value.ToString();
                string yazarAdi = selectedRow.Cells["YazarAdi"].Value.ToString();

                // TextBox'lara verileri yerleştirme
                txtkitapadi2.Text = kitapAdi;
                txtyazaradi2.Text = yazarAdi;
            }
        }


        private void KtpAdiAraBtn_Click(object sender, EventArgs e)
        {
            string kitapAdi = txtkitapadi.Text.Trim();

            if (string.IsNullOrEmpty(kitapAdi))
            {
                MessageBox.Show("Lütfen kitap adını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Kitap WHERE KitapAdi LIKE @KitapAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KitapAdi", "%" + kitapAdi + "%");

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

        private void yazararaBtn_Click(object sender, EventArgs e)
        {
            string yazarAdi = txtyazaradi.Text.Trim();

            if (string.IsNullOrEmpty(yazarAdi))
            {
                MessageBox.Show("Lütfen yazar adını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Yazar WHERE YazarAdi LIKE @YazarAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@YazarAdi", "%" + yazarAdi + "%");

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

        private void kitapAra_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                int kitapID = Convert.ToInt32(selectedRow.Cells["KitapID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    SELECT 
                        Kitap.KitapID,
                        Kitap.KitapAdi,
                        Kitap.YayinlanmaTarihi,
                        Yazar.YazarAdi,
                        Kategori.KategoriAdi,
                        Yayinevi.YayineviAdi,
                        Yer_Bilgisi.Bina,
                        Yer_Bilgisi.Kat,
                        Yer_Bilgisi.Salon,
                        Yer_Bilgisi.Kitaplik,
                        Yer_Bilgisi.Raf,
                        Kitap.ISBNNo,
                        Kitap.SayfaSayisi,
                        Kitap.KopyaSayisi,
                        Kitap.OzetBilgi,
                        Kitap.OduncAlinabilirMi,
                        Kitap.RezerveEdilebilirMi,
                        Kitap.KapakGorseli,
                        Kitap.Durum
                    FROM Kitap
                    INNER JOIN Yazar ON Kitap.YazarID = Yazar.YazarID
                    INNER JOIN Kategori ON Kitap.KategoriID = Kategori.KategoriID
                    INNER JOIN Yayinevi ON Kitap.YayineviID = Yayinevi.YayineviID
                    INNER JOIN Yer_Bilgisi ON Kitap.YerID = Yer_Bilgisi.YerID
                    WHERE Kitap.KitapID = @KitapID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@KitapID", kitapID);

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

                                    txtkitapadi2.Text = row["KitapAdi"].ToString();
                                    txtyazaradi2.Text = row["YazarAdi"].ToString();
                                    txtkategori.Text = row["KategoriAdi"].ToString();
                                    txtyayinevi.Text = row["YayineviAdi"].ToString();
                                    txtyayinlanmatarihi.Text = row["YayinlanmaTarihi"].ToString();
                                    txtbina.Text = row["Bina"].ToString();
                                    txtkat.Text = row["Kat"].ToString();
                                    txtsalon.Text = row["Salon"].ToString();
                                    txtkitaplik.Text = row["Kitaplik"].ToString();
                                    txtraf.Text = row["Raf"].ToString();
                                    txtisbnno.Text = row["ISBNNo"].ToString();
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
            // Kullanıcıya silme işlemi için onay sor
            DialogResult result = MessageBox.Show("Seçili kitabı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                if (!string.IsNullOrEmpty(txtkitapadi2.Text)) // Kitap adı boş olamaz
                {

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Kitap WHERE KitapID = @KitapID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Silinecek kitabın ID'sini al
                                int kitapID = GetKitapIDByKitapAdi(txtkitapadi2.Text);

                                // Eğer kitapID 0'dan büyükse, yani geçerli bir ID ise silme işlemi yap
                                if (kitapID > 0)
                                {
                                    command.Parameters.AddWithValue("@KitapID", kitapID);
                                    int affectedRows = command.ExecuteNonQuery();

                                    if (affectedRows > 0)
                                    {
                                        MessageBox.Show("Kitap başarıyla silindi.");

                                        // Silme işlemi gerçekleştikten sonra TextBox'ları temizle
                                        Temizle();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Kitap silinirken bir hata oluştu.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Geçerli bir kitap seçilmedi.");
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
                    MessageBox.Show("Silmek için bir kitap seçmelisiniz.");
                }


            }

        }

            // Kitap adına göre KitapID'yi almak için yardımcı bir fonksiyon
            private int GetKitapIDByKitapAdi(string kitapAdi)
            {
                int kitapID = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT KitapID FROM Kitap WHERE KitapAdi = @KitapAdi";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@KitapAdi", kitapAdi);

                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                kitapID = Convert.ToInt32(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                return kitapID;
            }

            // TextBox'ları temizleme işlemi için yardımcı bir fonksiyon
            private void Temizle()
            {
                // TextBox'ları temizle
                txtkitapadi2.Clear();
                txtyazaradi2.Clear();
                txtkategori.Clear();
                txtyayinevi.Clear();
                txtbina.Clear();
                txtkat.Clear();
                txtsalon.Clear();
                txtkitaplik.Clear();
                txtraf.Clear();
                txtisbnno.Clear();
                txtsayfasayisi.Clear();
                txtkopyasayisi.Clear();
                txtozetbilgi.Clear();
                txtdurum.Clear();
                txtodunc.Clear();
                txtrezerve.Clear();
            }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtkitapadi2.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                UPDATE Kitap
                SET 
                    KitapAdi = @KitapAdi,
                    YazarID = (SELECT YazarID FROM Yazar WHERE YazarAdi = @YazarAdi),
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
                    ISBNno = @ISBNno,
                    SayfaSayisi = @SayfaSayisi,
                    KopyaSayisi = @KopyaSayisi,
                    OzetBilgi = @OzetBilgi,
                    Durum = @Durum,
                    OduncAlinabilirMi = @OduncAlinabilirMi,
                    RezerveEdilebilirMi = @RezerveEdilebilirMi
                WHERE KitapID = @KitapID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int kitapID = GetKitapIDByKitapAdi(txtkitapadi2.Text);
                            MessageBox.Show("kitap id =" +kitapID);

                            if (kitapID > 0)
                            {
                                command.Parameters.AddWithValue("@KitapID", kitapID);
                                command.Parameters.AddWithValue("@KitapAdi", txtkitapadi2.Text);
                                command.Parameters.AddWithValue("@YazarAdi", txtyazaradi2.Text);
                                command.Parameters.AddWithValue("@KategoriAdi", txtkategori.Text);
                                command.Parameters.AddWithValue("@YayineviAdi", txtyayinevi.Text);
                                command.Parameters.AddWithValue("@Bina", txtbina.Text);
                                command.Parameters.AddWithValue("@Kat", txtkat.Text);
                                command.Parameters.AddWithValue("@Salon", txtsalon.Text);
                                command.Parameters.AddWithValue("@Kitaplik", txtkitaplik.Text);
                                command.Parameters.AddWithValue("@Raf", txtraf.Text);
                                command.Parameters.AddWithValue("@ISBNNo", txtisbnno.Text);
                                command.Parameters.AddWithValue("@SayfaSayisi", Convert.ToInt32(txtsayfasayisi.Text));
                                command.Parameters.AddWithValue("@KopyaSayisi", Convert.ToInt32(txtkopyasayisi.Text));
                                command.Parameters.AddWithValue("@OzetBilgi", txtozetbilgi.Text);
                                command.Parameters.AddWithValue("@OduncAlinabilirMi", txtodunc.Text);
                                command.Parameters.AddWithValue("@RezerveEdilebilirMi", txtrezerve.Text);
                                command.Parameters.AddWithValue("@Durum", txtdurum.Text);

                                int affectedRows = command.ExecuteNonQuery();

                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Kitap başarıyla güncellendi.");

                                    // Güncelleme işlemi başarılı olduğunda TextBox'ları temizle
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Kitap güncellenirken bir hata oluştu.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir kitap seçilmedi.");
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
                MessageBox.Show("Güncellemek için bir kitap seçmelisiniz.");
            }
        }

    }
    }
    



      
 


