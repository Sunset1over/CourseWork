using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class Admin_Panel : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Admin_Panel()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search...")
            {
                textBox1.Text = string.Empty;

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Search...";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmd_comm = "Select * from Bioadditive";

            var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

            var DB = new DataSet();

            sqlDataAdapter.Fill(DB);

            dataGridView1.DataSource = DB.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (checkBox1.Checked)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_active_substance LIKE '{textBox1.Text}%'";
                }

                else if (checkBox2.Checked)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_bioadditive LIKE '{textBox1.Text}%'";
                }

                else if (checkBox3.Checked)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_bioadditive LIKE '{textBox1.Text}%'";
                }

                else if (checkBox4.Checked)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_illness LIKE '{textBox1.Text}%'";
                }

                else if (checkBox5.Checked)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_bioadditive LIKE '{textBox1.Text}%'";
                }
                else
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_delivery LIKE '{textBox1.Text}%'";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select * from Active_substance";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select * from Bioadditive";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select t.*, b.Price, b.Manufacturer from Treatment t " +
                               "JOIN Bioadditive b ON t.Name_bioadditive = b.Name_bioadditive";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select * from Illness";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "select c.id_composition, c.Count, c.Name_bioadditive, c.Name_active_substance, b.Price, b.Manufacturer from Composition c " +
                               "JOIN Bioadditive b ON c.Name_bioadditive = b.Name_bioadditive";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = true;
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select * from Delivery";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = true;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var addNewActive_substance = new AddNewActive_substance();
                addNewActive_substance.Show();
                Close();
            }

            else if (checkBox2.Checked)
            {
                var bioadditive = new AddNewBioadditive();
                bioadditive.Show();
                Close();
            }

            else if (checkBox3.Checked)
            {
                var treatment = new AddNewTreatment();
                treatment.Show();
                Close();
            }

            else if (checkBox4.Checked)
            {
                var illnes = new AddNewIllnes();
                illnes.Show();
                Close();
            }

            else if (checkBox5.Checked)
            {
                var composition = new AddNewComposition();
                composition.Show();
                Close();
            }

            else if (checkBox6.Checked)
            {
                var delivery = new AddNewDelivety();
                delivery.Show();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Search...";

            textBox1.ForeColor = Color.Silver;

            checkBox2.Checked = true;
        }

        private void lookallpreorderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var preorder = new Preorder();
            preorder.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reports = new Reports();
            reports.Show();
        }

        private void lookallreceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var receiptView = new ReceiptView();
            receiptView.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                    var sqlConnection = new SqlConnection(_connectionString);

                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                        $"DELETE FROM Active_substance WHERE Name_active_substance = '{index}'", sqlConnection);

                    DataSet _dataSet = new DataSet();

                    sqlDataAdapter.Fill(_dataSet, _connectionString);

                    checkBox1.Checked = false;
                    checkBox1.Checked = true;
                }
            }

            else if (checkBox2.Checked)
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value).ToString();

                    var sqlConnection = new SqlConnection(_connectionString);

                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                        $"DELETE FROM Bioadditive WHERE Name_bioadditive = '{index}'", sqlConnection);

                    DataSet _dataSet = new DataSet();

                    sqlDataAdapter.Fill(_dataSet, _connectionString);

                    checkBox2.Checked = false;
                    checkBox2.Checked = true;
                }
            }
            else if (checkBox3.Checked)
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);

                    var sqlConnection = new SqlConnection(_connectionString);

                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM Treatment WHERE id_treatment = {index}", sqlConnection);

                    DataSet _dataSet = new DataSet();

                    sqlDataAdapter.Fill(_dataSet, _connectionString);

                    checkBox3.Checked = false;
                    checkBox3.Checked = true;
                }
            }

            else if (checkBox4.Checked) 
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                    var sqlConnection = new SqlConnection(_connectionString);

                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                        $"DELETE FROM Illness WHERE Name_illness = '{index}'", sqlConnection);

                    DataSet _dataSet = new DataSet();

                    sqlDataAdapter.Fill(_dataSet, _connectionString);

                    checkBox4.Checked = false;
                    checkBox4.Checked = true;
                }
            }

            else if (checkBox5.Checked) 
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);

                    var sqlConnection = new SqlConnection(_connectionString);
                    
                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM Composition WHERE id_composition = {index}", sqlConnection);
                    
                    DataSet _dataSet = new DataSet();
                    
                    sqlDataAdapter.Fill(_dataSet, _connectionString);
                    
                    checkBox5.Checked = false; 
                    checkBox5.Checked = true;
                }
            }
            else if (checkBox6.Checked) 
            {
                if (MessageBox.Show("Do you really want to delete?", "Attention",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var index = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                    var sqlConnection = new SqlConnection(_connectionString);

                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(
                        $"DELETE FROM Delivery WHERE Name_delivery = '{index}'", sqlConnection);

                    DataSet _dataSet = new DataSet();

                    sqlDataAdapter.Fill(_dataSet, _connectionString);

                    checkBox6.Checked = false;
                    checkBox6.Checked = true;
                }
            }
        }

        private void updataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                var changeBioadditive = new ChangeBioadditive(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());

                changeBioadditive.Show();
                Close();
            }

            else if (checkBox6.Checked)
            {
                var changeDelivery = new ChangeDelivery(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());

                changeDelivery.Show();
                Close();
            }
        }
    }
}