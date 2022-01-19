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
    public partial class ChangeBioadditive : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private static string _Name_bioadditive;
        
        public ChangeBioadditive(string name)
        {
            InitializeComponent();

            _Name_bioadditive = name;

            // BD connection

            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var sqlDataAdapter = new SqlDataAdapter($"Select * from Bioadditive where Name_bioadditive = '{_Name_bioadditive}'", sqlConnection);

                var dataSet = new DataSet("CourseWork");
            sqlDataAdapter.Fill(dataSet, "Bioadditive");

            DataTable table;
            table = dataSet.Tables["Bioadditive"];

            DataRow row;
            row = table.Rows[0];

            //Filling

            textBox1.Text = _Name_bioadditive;
            textBox2.Text = row["Weight"].ToString();
            textBox3.Text = row["Price"].ToString();
            textBox3.Text = row["Price"].ToString();
            textBox4.Text = row["Type_of_application"].ToString();
            textBox5.Text = row["Manufacturer"].ToString();
            textBox6.Text = row["Contraindication"].ToString();
            textBox7.Text = row["Primary_packaging"].ToString();
          

            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to change?", "Attention",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var cmd_text = $"UPDATE Bioadditive SET Weight = '{textBox2.Text}', Price = '{Convert.ToInt32(textBox3.Text)}', " +
                               $"Type_of_application = '{textBox4.Text}', Manufacturer = '{textBox5.Text}', Contraindication = '{textBox6.Text}'," +
                               $"Primary_packaging = '{textBox7.Text}' where Name_bioadditive = '{_Name_bioadditive}'";

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
