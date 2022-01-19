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
    public partial class Register : Form
    {

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Register()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var cmd_text = "INSERT INTO Client VALUES (" +
                               "'" + textBox1.Text + "' , '" +
                               textBox2.Text + "' , '" +
                               textBox3.Text + "' , '" +
                               textBox4.Text + "' , '" +
                               textBox5.Text + "' , '" +
                               textBox6.Text + "' , '" +
                               textBox7.Text + "' , '" +
                               textBox8.Text + "')";

                var log_pass_check = "SELECT * FROM Client WHERE Login = @uL";

                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty ||
                    textBox3.Text == string.Empty || textBox4.Text == string.Empty ||
                    textBox5.Text == string.Empty || textBox6.Text == string.Empty ||
                    textBox7.Text == string.Empty || textBox8.Text == string.Empty)
                {
                    if (textBox1.Text == "Enter name")
                    {
                        textBox1.ForeColor = Color.Red;
                    }

                    if (textBox2.Text == "Enter surName")
                    {
                        textBox2.ForeColor = Color.Red;
                    }

                    if (textBox3.Text == "Enter midName")
                    {
                        textBox3.ForeColor = Color.Red;
                    }

                    if (textBox4.Text == string.Empty)
                    {
                        textBox4.Text = "Enter number phone";

                        textBox4.ForeColor = Color.Red;
                    }

                    if (textBox5.Text == string.Empty)
                    {
                        textBox5.Text = "Enter login";

                        textBox5.ForeColor = Color.Red;
                    }

                    if (textBox6.Text == string.Empty)
                    {
                        textBox6.Text = "Enter password";

                        textBox6.ForeColor = Color.Red;
                    }

                    if (textBox7.Text == string.Empty)
                    {
                        textBox7.Text = "Enter address";

                        textBox7.ForeColor = Color.Red;
                    }

                    if (textBox8.Text == "someone@gmail.com")
                    {
                        textBox8.Text = "Enter email for ex someone@gmail.com";

                        textBox8.ForeColor = Color.Red;
                    }
                }

                else if (textBox6.Text != textBox9.Text)
                {
                    MessageBox.Show(@"Password mismatch", "Error");
                }

                else if (textBox5.Text == "admin")
                {
                    MessageBox.Show("This login is reserved by the site administration", "Warning");
                }

                else if (MessageBox.Show("Are you sure you want to register?", "Date change", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sqlConnection = new SqlConnection(_connectionString);

                    var loginUser = textBox5.Text;

                    var table = new DataTable();

                    var adapter = new SqlDataAdapter();

                    var sqlCommand = new SqlCommand(cmd_text, sqlConnection);

                    var sqlComm = new SqlCommand(log_pass_check, sqlConnection);
                    sqlComm.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;

                    adapter.SelectCommand = sqlComm;
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show(@"A user with this login already exists, replace it with another one");
                    }
                    else
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Data entered incorrectly", "Exception");
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter name")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter name";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter surName")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter surName";

                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter midName")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter midName";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "someone@gmail.com" || textBox8.Text == "Enter email for ex someone@gmail.com")
            {
                textBox8.Text = "";

                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "someone@gmail.com";

                textBox8.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter number phone")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter login")
            {
                textBox5.Text = "";

                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Enter password")
            {
                textBox6.Text = "";

                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Enter address")
            {
                textBox7.Text = "";

                textBox7.ForeColor = Color.Black;
            }
        }
    }
}
