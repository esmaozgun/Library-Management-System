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
    public partial class personelAra : Form
    {

        private string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True";
        private EventHandler DataGridView1_SelectionChanged;
        public personelAra()
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


        private void personelAra_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void araBtn_Click(object sender, EventArgs e)
        {
            string personelkadi = txtkadi1.Text.Trim();

            if (string.IsNullOrEmpty(personelkadi))
            {
                MessageBox.Show("Lütfen üye adını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                   // "SELECT * FROM Personel WHERE GırısID IN (SELECT GırısID FROM Giris WHERE KullaniciAdi = @Personelkadi)";
                    string query = 
                    "SELECT P.* " +
                         "FROM Personel P " +
                         "INNER JOIN Giris G ON P.GirisID = G.GirisID " +
                         "WHERE G.KullaniciAdi LIKE @Personelkadi";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Personelkadi", "%" + personelkadi + "%");

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

                int PersonelID = Convert.ToInt32(selectedRow.Cells["PersonelID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    SELECT 
                        Personel.PersonelID,
                        Personel.PersonelAdi,
                        Personel.PersonelSoyadi,
                        Personel.Tcno,
                        Personel.Email,
                        Personel.Telno,
                        Personel.KaydolmaTarihi,
                        Personel.Pasaportno,
                        Giris.KullaniciAdi,
                        Giris.Parola,
                        Giris.KullaniciTipi
                    FROM Personel
                    INNER JOIN Giris ON Personel.GirisID = Giris.GirisID
                    WHERE Personel.PersonelID = @PersonelID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonelID", PersonelID);

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

                                    txtkadi2.Text = row["KullaniciAdi"].ToString();
                                    txtparola.Text = row["Parola"].ToString();
                                    txtpersoneladi.Text = row["PersonelAdi"].ToString();
                                    txtpersonelsoyadi.Text = row["PersonelSoyadi"].ToString();
                                    txttcno.Text = row["Tcno"].ToString();
                                    txtemail.Text = row["Email"].ToString();
                                    txttelno.Text = row["Telno"].ToString();
                                    txtkaydolmatarihi.Text = row["KaydolmaTarihi"].ToString();
                                    txtpasno.Text = row["Pasaportno"].ToString();
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
            DialogResult result = MessageBox.Show("Seçili personeli silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {



                if (!string.IsNullOrEmpty(txtpersoneladi.Text)) // Personel adı boş olamaz
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Personel WHERE PersonelID = @PersonelID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Silinecek personelin ID'sini aldım
                                int personelID = GetPersonelIDByPersonelAdi(txtpersoneladi.Text);

                                // Eğer personelID 0'dan büyükse, yani geçerli bir ID ise silme işlemi yap
                                if (personelID > 0)
                                {
                                    command.Parameters.AddWithValue("@PersonelID", personelID);
                                    int affectedRows = command.ExecuteNonQuery();

                                    if (affectedRows > 0)
                                    {
                                        MessageBox.Show("Personel başarıyla silindi.");

                                        // Silme işlemi gerçekleştikten sonra TextBox'ları temizle
                                        Temizle();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Personel silinirken bir hata oluştu.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Geçerli bir personel seçilmedi.");
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
                    MessageBox.Show("Silmek için bir personel seçmelisiniz.");
                }
            }
        }

        private int GetPersonelIDByPersonelAdi(string personelAdi)
        {
            int personelID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT PersonelID FROM Personel WHERE PersonelAdi = @PersonelAdi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonelAdi", personelAdi);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            personelID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            return personelID;
        }

        // TextBox'ları temizleme işlemi için yardımcı bir fonksiyon
        private void Temizle()
        {

            txtpersoneladi.Clear();
            txtkadi2.Clear();
            txtpersonelsoyadi.Clear();
            txtparola.Clear();
            txttcno.Clear();
            txtemail.Clear();
            txttelno.Clear();
            //txtkaydolmatarihi.Clear();
            txtpasno.Clear();
        }

        private void güncelleBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpersoneladi.Text))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                UPDATE Personel
                SET 
                    PersonelAdi = @PersonelAdi,
                    PersonelSoyadi = @PersonelSoyadi,
                    GirisID = (
                        SELECT GirisID
                        FROM Giris
                        WHERE
                        KullaniciAdi = @KullaniciAdi AND
                        Parola = @Parola
                                ),
                        Tcno = @Tcno,
                        Email = @Email,
                        Telno = @Telno,
                        KaydolmaTarihi = @KaydolmaTarihi,
                        Pasaportno = @Pasaportno
                WHERE PersonelID = @PersonelID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int personelID = GetPersonelIDByPersonelAdi(txtpersoneladi.Text);

                            if (personelID > 0)
                            {
                                command.Parameters.AddWithValue("@PersonelID", personelID);
                                command.Parameters.AddWithValue("@PersonelAdi", txtpersoneladi.Text);
                                command.Parameters.AddWithValue("@PersonelSoyadi", txtpersonelsoyadi.Text);
                                command.Parameters.AddWithValue("@KullaniciAdi", txtkadi2.Text);
                                command.Parameters.AddWithValue("@Parola", txtparola.Text);
                                command.Parameters.AddWithValue("@Tcno", txttcno.Text);
                                command.Parameters.AddWithValue("@Email", txtemail.Text);
                                command.Parameters.AddWithValue("@Telno", txttelno.Text);
                                command.Parameters.AddWithValue("@KaydolmaTarihi", Convert.ToDateTime(txtkaydolmatarihi.Value));
                                command.Parameters.AddWithValue("@Pasaportno", txtpasno.Text);

                                int affectedRows = command.ExecuteNonQuery();

                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Personel başarıyla güncellendi.");

                                    // Güncelleme işlemi başarılı olduğunda TextBox'ları temizle
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Personel güncellenirken bir hata oluştu.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Geçerli bir personel seçilmedi.");
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
                MessageBox.Show("Güncellemek için bir personel seçmelisiniz.");
            }
        }
    }
}
