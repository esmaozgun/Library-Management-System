using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class cezaSil : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        public cezaSil()
        {
            InitializeComponent();

        }


        private void formdanCikisBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sayfayı kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();

            }
        }

        private void tumcezabtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True"; // Veritabanı bağlantı dizesini buraya ekleyin
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            // Veritabanındaki Ceza tablosundan verileri çekme
            string selectQuery = "SELECT * FROM Ceza";
            dataAdapter.SelectCommand = new SqlCommand(selectQuery, connection);

            // Verileri çekip DataSet'e ekleyerek DataGridView'e bind etme
            connection.Open();
            dataAdapter.Fill(dataSet, "Ceza");
            connection.Close();

            dataGridView1.DataSource = dataSet.Tables["Ceza"];
        }

        private void silBtn_Click(object sender, EventArgs e)
        {
            // Seçilen hücrenin bilgisini al
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            int cezaID = Convert.ToInt32(selectedRow.Cells["CezaID"].Value);

            // Kullanıcıya silme işlemi için onay sor
            DialogResult result = MessageBox.Show("Seçili cezayı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Silme işlemi
                connection.Open();
                string deleteQuery = "DELETE FROM Ceza WHERE CezaID = @CezaID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@CezaID", cezaID);
                deleteCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ceza başarıyla silindi.");

                // Silinen veriyi DataSet'ten de kaldır
                dataSet.Tables["Ceza"].Rows[selectedRowIndex].Delete();
            }
        }
    }
}
