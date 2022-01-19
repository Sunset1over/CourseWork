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
    public partial class AddNewDelivety : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public AddNewDelivety()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var cmd_text = $"INSERT INTO Delivery VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";

                if (textBox1.Text == string.Empty)   //доработать
                {
                    textBox1.Text = "Enter delivery";

                    textBox1.ForeColor = Color.Red;
                }
                else if (MessageBox.Show("Are you sure you want to add an active ingredient?", "Data add",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sqlConnection = new SqlConnection(_connectionString);

                    var sqlCommand = new SqlCommand(cmd_text, sqlConnection);   //Дописать проверку

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Data entered incorrectly", "Exception");
            }
        }
    }
}
