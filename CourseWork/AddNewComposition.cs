using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddNewComposition : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public AddNewComposition()
        {
            InitializeComponent();

            var cmd_text_bioadditive = "Select * from Bioadditive";

            var sqlConnection = new SqlConnection(_connectionString);

            var sqlCommandBioadditive = new SqlCommand(cmd_text_bioadditive, sqlConnection);

            var tableBioadditive = new DataTable();

            var adapterBioadditive = new SqlDataAdapter(sqlCommandBioadditive);

            adapterBioadditive.Fill(tableBioadditive);

            comboBox1.DataSource = tableBioadditive;
            comboBox1.DisplayMember = "Name_bioadditive";
            comboBox1.ValueMember = "Name_bioadditive";
            comboBox1.SelectedIndex = -1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            var cmd_text_illness = "Select * from Active_substance";

            var sqlCommandIllness = new SqlCommand(cmd_text_illness, sqlConnection);

            var tableIllness = new DataTable();

            var adapterIllness = new SqlDataAdapter(sqlCommandIllness);

            adapterIllness.Fill(tableIllness);

            comboBox4.DataSource = tableIllness;
            comboBox4.DisplayMember = "Name_active_substance";
            comboBox4.ValueMember = "Name_active_substance";
            comboBox4.SelectedIndex = -1;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd_text = $"INSERT Composition VALUES ('{Convert.ToInt32(textBox1.Text)}'," +
                               $"'{comboBox1.Text}', '{comboBox4.Text}')";

                var nB_nI_check = "SELECT * FROM Composition WHERE Name_bioadditive = @nB AND " +
                                "Name_active_substance = @nAS";

                if (comboBox1.Text == string.Empty || textBox1.Text == string.Empty || comboBox4.Text == string.Empty)
                {
                    MessageBox.Show("Enter correctly values");
                }
                else if (MessageBox.Show("Are you sure you want to add an active ingredient?", "Data add",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sqlConnection = new SqlConnection(_connectionString);

                    var NameBioaadditive = comboBox1.Text;

                    var nameActiveSubstance = comboBox4.Text;

                    var table = new DataTable();

                    var adapter = new SqlDataAdapter();

                    var sqlCommand = new SqlCommand(cmd_text, sqlConnection);

                    var sqlComm = new SqlCommand(nB_nI_check, sqlConnection);
                    sqlComm.Parameters.Add("@nB", SqlDbType.NChar).Value = NameBioaadditive;
                    sqlComm.Parameters.Add("@nAS", SqlDbType.NChar).Value = nameActiveSubstance;

                    adapter.SelectCommand = sqlComm;
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show(
                            @"An active substance with the same name already exists, replace it with another");
                    }
                    else
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        comboBox1.SelectedIndex = -1;
                        textBox1.Text = string.Empty;
                        comboBox4.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var admin_panel = new Admin_Panel();
            admin_panel.Show();
            Close();
        }
    }
}