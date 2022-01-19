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
    public partial class Phytocomplex : Form
    {

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Phytocomplex()
        {
            InitializeComponent();

            // BD connection

            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var uL = AllInfo.Text;

            var sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Client WHERE Login = '" + uL + "'", sqlConnection);

            var dataSet = new DataSet("CourseWork");
            sqlDataAdapter.Fill(dataSet, "Client");

            DataTable table;
            table = dataSet.Tables["Client"];

            DataRow row;
            row = table.Rows[0];



            //Filling

            textBox1.Text = row["Name"].ToString();
            textBox2.Text = row["SurName"].ToString();           
            textBox3.Text = row["MidName"].ToString();
            textBox4.Text = row["Telephone"].ToString();
            textBox5.Text = row["Login"].ToString();
            textBox6.Text = row["Password"].ToString();
            textBox7.Text = row["Address"].ToString();
            textBox8.Text = row["Email"].ToString();
            textBox9.Text = row["id_client"].ToString();
            

            sqlConnection.Close();
        }

        private void Change_Password_Click(object sender, EventArgs e)
        {
            var cmd_text = "UPDATE Client SET Name = '" + textBox1.Text + "', " +
                           "SurName = '" + textBox2.Text + "', " +
                           "MidName = '" + textBox3.Text + "', " +
                           "Telephone = '" + textBox4.Text + "', " +
                           "Login = '" + textBox5.Text + "', " +
                           "Password = '" + textBox6.Text + "', " +
                           "Address = '" + textBox7.Text + "', " +
                           "Email = '" + textBox8.Text +  "' WHERE id_client = " + Convert.ToInt32(textBox9.Text);

            var sqlConnection = new SqlConnection(_connectionString);

            var sqlCommand = new SqlCommand(cmd_text, sqlConnection);
           
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void Shop_Click(object sender, EventArgs e)
        {
            var shop = new Shop();
            shop.Show();
            Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var uL = AllInfo.Text;

                var cmd_text = "DELETE FROM Client WHERE Login = '" + uL + "'";

                var sqlConnection = new SqlConnection(_connectionString);

                var sqlCommand = new SqlCommand(cmd_text, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Close();
            }
            catch (Exception)
            {

            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Phytocomplex_FormClosing(object sender, FormClosingEventArgs e)
        {
            Basket.ListBarcode.Clear();
            Basket.ListCount.Clear();
            Basket.ListName.Clear();
            Basket.ListPrice.Clear();
        }
    }
}
