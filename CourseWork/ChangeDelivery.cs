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
    public partial class ChangeDelivery : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private static string _Name_delivery;

        public ChangeDelivery(string name)
        {
            InitializeComponent();

            _Name_delivery = name;

            // BD connection

            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var sqlDataAdapter = new SqlDataAdapter($"Select * from Delivery where Name_delivery = '{_Name_delivery}'", sqlConnection);

            var dataSet = new DataSet("CourseWork");
            sqlDataAdapter.Fill(dataSet, "Delivery");

            DataTable table;
            table = dataSet.Tables["Delivery"];

            DataRow row;
            row = table.Rows[0];

            //Filling

            textBox1.Text = _Name_delivery;
            textBox2.Text = row["Type_delivery"].ToString();
            textBox3.Text = row["Time_delivery"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to change?", "Attention",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var cmd_text = $"UPDATE Delivery SET Type_delivery = '{textBox2.Text}', Time_delivery = '{textBox3.Text}' where Name_delivery = '{_Name_delivery}'";

                var sqlConnection = new SqlConnection(_connectionString);

                var sqlCommand = new SqlCommand(cmd_text, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                var admin_panel = new Admin_Panel();
                admin_panel.Show();
                Close();
            }
        }
    }
}
