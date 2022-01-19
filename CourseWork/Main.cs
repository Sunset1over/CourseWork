using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class Main : Form
    {

        private static string _connectionString = ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Main()
        {
            InitializeComponent();
        }

        private void Login_Enter(object sender, EventArgs e)
        {
            if (Login.Text == "Enter your login...")
            {
                Login.Text = "";

                Login.ForeColor = Color.Black;
            }
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "Enter your login...";

                Login.ForeColor = Color.Silver;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var register = new Register();
            register.Show();
        }

        private void Sign_in_Click(object sender, EventArgs e)
        {
            var log_pass_check = "SELECT * FROM Client WHERE Login = @uL AND Password = @uP";

            var sqlConnection = new SqlConnection(_connectionString);

            var loginUser = Login.Text;
            var passUser = Password.Text;

            var table = new DataTable();

            var adapter = new SqlDataAdapter();

            var sqlComm = new SqlCommand(log_pass_check, sqlConnection);
            sqlComm.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
            sqlComm.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = sqlComm;
            adapter.Fill(table);

            AllInfo.Text = Login.Text;

            if (table.Rows.Count > 0)
            {
                var phytocomplex = new Phytocomplex();
                phytocomplex.Show();

                Login.Text = string.Empty;
                Password.Text = string.Empty;
            }

            else if (Login.Text == "sergey" && Password.Text == "sergey")
            {
                var admin_panel = new Admin_Panel();
                admin_panel.Show();

                Login.Text = string.Empty;
                Password.Text = string.Empty;
            }

            else
            {
                MessageBox.Show(@"Check the username and password, possibly an incorrect value has been entered", 
                    "Error");
            }
        }
    }
}
