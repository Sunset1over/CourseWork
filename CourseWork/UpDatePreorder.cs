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
    public partial class UpDatePreorder : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private static int _id;

        public UpDatePreorder(int id)
        {
            InitializeComponent();

            _id = id;

            // BD connection

            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var sqlDataAdapter = new SqlDataAdapter(
                "Select * from Preorder " +
                $"WHERE id_preorder = {_id}", sqlConnection);

            var dataSet = new DataSet("CourseWork");
            sqlDataAdapter.Fill(dataSet, "Preorder");

            DataTable table;
            table = dataSet.Tables["Preorder"];

            DataRow row;
            row = table.Rows[0];

            //Filling

            textBox1.Text = row["Data"].ToString();
            comboBox1.Text = row["Status"].ToString();
            textBox2.Text = row["id_cleint"].ToString();
            textBox3.Text = row["Name_delivery"].ToString();
            textBox4.Text = row["Address"].ToString();

            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cmdComm = $"Update Preorder Set Status = '{comboBox1.Text}'" +
                          $"Where id_preorder = {_id}";

            var sqlConnection = new SqlConnection(_connectionString);

            var sqlCommand = new SqlCommand(cmdComm, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            var preorder = new Preorder();
            preorder.Show();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var preorder = new Preorder();
            preorder.Show();
            Close();
        }
    }
}
