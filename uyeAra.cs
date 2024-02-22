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
    public partial class uyeAra : Form
    {

        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";
        private EventHandler DataGridView1_SelectionChanged;
        public uyeAra()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            // DataGridView'de bir satır seçildiğinde olayı ekle.
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void uyeAra_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void formdanCikisBtn3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void araBtn_Click(object sender, EventArgs e)
        {
            string Uyekadi = txtuyekadi.Text.Trim();

            if (string.IsNullOrEmpty(Uyekadi))
            {
                MessageBox.Show("Lütfen üye adını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT U.* " +
                         "FROM UYE U " +
                         "INNER JOIN Giris G ON U.GirisID = G.GirisID " +
                         "WHERE G.KullaniciAdi LIKE @Uyekadi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Uyekadi", "%" + Uyekadi + "%");

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

                int UyeID = Convert.ToInt32(selectedRow.Cells["UyeID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    SELECT 
                        Uye.UyeID,
                        Uye.UyeAdi,
                        Uye.UyeSoyadi,
                        Uye.Ogrencino,
                        Uye.Tcno,
                        Uye.Email,
                        Uye.Telno,
                        Uye.KaydolmaTarihi,
                        Uye.Pasaportno,
                        Uye.Durum,
                        Giris.KullaniciAdi,
                        Giris.Parola,
                        Giris.KullaniciTipi
                    FROM Uye
                    INNER JOIN Giris ON Uye.GirisID = Giris.GirisID
                    WHERE Uye.UyeID = @UyeID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UyeID", UyeID);

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

                                    txtuyekadi2.Text = row["KullaniciAdi"].ToString();
                                    txtparola.Text = row["Parola"].ToString();
                                    txtktip.Text = row["KullaniciTipi"].ToString();
                                    txtuyeadi.Text = row["UyeAdi"].ToString();
                                    txtuyesoyadi.Text = row["UyeSoyadi"].ToString();
                                    txtogrencino.Text = row["OgrenciNo"].ToString();
                                    txttcno.Text = row["Tcno"].ToString();
                                    txtemail.Text = row["Email"].ToString();
                                    txttelno.Text = row["Telno"].ToString();
                                    txtkaydolmatarihi.Text = row["KaydolmaTarihi"].ToString();
                                    txtpassno.Text = row["Pasaportno"].ToString();
                                    txtdurum.Text = row["Durum"].ToString();
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
            DialogResult result = MessageBox.Show("Seçili üyeyi silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                if (!string.IsNullOrEmpty(txtuyeadi.Text)) // Uye adı boş olamaz
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Uye WHERE UyeID = @UyeID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Silinecek uyenin ID'sini aldım
                                int uyeID = GetUyeIDByUyeAdi(txtuyeadi.Text);

                                // Eğer uyeID 0'dan büyükse, yani geçerli bir ID ise silme işlemi yap
                                if (uyeID > 0)
                                {
                                    command.Parameters.AddWithValue("@UyeID", uyeID);
                                    int affectedRows = command.ExecuteNonQuery();

                                    if (affectedRows > 0)
                                    {
                                        MessageBox.Show("Üye başarıyla silindi.");

                                        // Silme işlemi gerçekleştikten sonra TextBox'ları temizle
                                        Temizle();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Üye silinirken bir hata oluştu.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Geçerli bir üye seçilmedi.");
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
                    MessageBox.Show("Silmek için bir üye seçmelisiniz.");
                }
            }
        }
        // Uye adına göre UyeID'yi almak için yardımcı bir fonksiyon
        private int GetUyeIDByUyeAdi(string uyeAdi)
        {
            int uyeID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UyeID FROM Uye WHERE UyeAdi = @UyeAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UyeAdi", uyeAdi);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            uyeID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            return uyeID;
        }

        // TextBox'ları temizleme işlemi için yardımcı bir fonksiyon
        private void Temizle()
        {

            txtuyeadi.Clear();
            txtuyekadi2.Clear();
            txtuyesoyadi.Clear();
            txtktip.Clear();
            txtparola.Clear();
            txtogrencino.Clear();
            txttcno.Clear();
            txtemail.Clear();
            txttelno.Clear();
           // txtkaydolmatarihi.Clear();
            txtpassno.Clear();
            txtdurum.Clear();
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtuyeadi.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                UPDATE Uye
                SET 
                    UyeAdi = @UyeAdi,
                    UyeSoyadi = @UyeSoyadi,
                    GirisID = (
                        SELECT GirisID
                        FROM Giris
                        WHERE
                        KullaniciAdi = @KullaniciAdi AND
                        Parola = @Parola
                                ),
                        Ogrencino = @Ogrencino,
                        Tcno = @Tcno,
                        Email = @Email,
                        Telno = @Telno,
                        KaydolmaTarihi = @KaydolmaTarihi,
                        Pasaportno = @Pasaportno,
                        Durum = @Durum
                WHERE UyeID = @UyeID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int uyeID = GetUyeIDByUyeAdi(txtuyeadi.Text);

                            if (uyeID > 0)
                            {
                                command.Parameters.AddWithValue("@UyeID", uyeID);
                                command.Parameters.AddWithValue("@UyeAdi", txtuyeadi.Text);
                                command.Parameters.AddWithValue("@UyeSoyadi", txtuyesoyadi.Text);
                                command.Parameters.AddWithValue("@KullaniciAdi", txtuyekadi2.Text);
                                command.Parameters.AddWithValue("@Parola", txtparola.Text);
                                command.Parameters.AddWithValue("@Ogrencino", txtogrencino.Text);
                                command.Parameters.AddWithValue("@Tcno", txttcno.Text);
                                command.Parameters.AddWithValue("@Email", txtemail.Text);
                                command.Parameters.AddWithValue("@Telno", txttelno.Text);
                                command.Parameters.AddWithValue("@KaydolmaTarihi", Convert.ToDateTime(txtkaydolmatarihi.Value));
                                command.Parameters.AddWithValue("@Pasaportno", txtpassno.Text);
                                command.Parameters.AddWithValue("@Durum", txtdurum.Text);

                                int affectedRows = command.ExecuteNonQuery();

                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Üye başarıyla güncellendi.");

                                    // Güncelleme işlemi başarılı olduğunda TextBox'ları temizle
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Üye güncellenirken bir hata oluştu.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir üye seçilmedi.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Güncellemek için bir üye seçmelisiniz.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }




}
