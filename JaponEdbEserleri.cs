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
    public partial class JaponEdbEserleri : Form
    {
        public JaponEdbEserleri()
        {
            InitializeComponent();
        }
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
       

        private void InitializeDatabase()
        {
            string connectionString = "Data Source=Ozgun\\OZGUNSQL;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True"; // Veritabanı bağlantı dizesini buraya ekleyin
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            // Veritabanındaki kitap tablosundan verileri çekme
            string selectQuery = "SELECT * FROM Kategori Where KategoriAdi LIKE '%Japon%'";
            dataAdapter.SelectCommand = new SqlCommand(selectQuery, connection);

            // Verileri çekip DataSet'e ekleyerek DataGridView'e bind etme
            connection.Open();
            dataAdapter.Fill(dataSet, "Kategori");
            connection.Close();

            dataGridView1.DataSource = dataSet.Tables["Kategori"];
        }

    }
}
