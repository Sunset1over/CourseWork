using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Buy_Product : Form
    {
        private static int _id;
        private static string _Name_bioadditive;
        private static string _Name_illness;
        private static string _Manufacturer;

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Buy_Product(int id, string name_bioadditive, string name_illness, 
            string manufacturer)
        {
            _id = id;
            _Name_bioadditive = name_bioadditive;
            _Name_illness = name_illness;
            _Manufacturer = manufacturer;

            InitializeComponent();

            // BD connection

            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var sqlDataAdapter = new SqlDataAdapter(
                "Select b.Price, b.Type_of_application, b.Contraindication from Treatment t " +
                "JOIN Bioadditive b ON t.Name_bioadditive = b.Name_bioadditive " +
                $"WHERE id_treatment = {_id}", sqlConnection);

            var dataSet = new DataSet("CourseWork");
            sqlDataAdapter.Fill(dataSet, "Bioadditive");

            DataTable table;
            table = dataSet.Tables["Bioadditive"];

            DataRow row;
            row = table.Rows[0];

            //Filling

            textBox1.Text = _id.ToString();
            textBox2.Text = _Name_bioadditive;
            textBox3.Text = _Name_illness;
            textBox4.Text = _Manufacturer;
            textBox5.Text = row["Type_of_application"].ToString();
            textBox6.Text = row["Contraindication"].ToString();
            textBox7.Text = row["Price"].ToString();

            sqlConnection.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report2 = new Report2(textBox2.Text);
            report2.Show();
        }

        private void Buy_Product_Load(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmd_comm = $"Select Name_bioadditive from Treatment where Name_illness = '{_Name_illness}'";

            var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

            var DB = new DataSet();

            sqlDataAdapter.Fill(DB);

            dataGridView1.DataSource = DB.Tables[0];
        }
    }
}
