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
    public partial class Shop : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Shop()
        {
            InitializeComponent();
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmd_comm = "Select t.*, b.Price, b.Manufacturer from Treatment t " +
                           "JOIN Bioadditive b ON t.Name_bioadditive = b.Name_bioadditive";

            var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

            var DB = new DataSet();

            sqlDataAdapter.Fill(DB);

            dataGridView1.DataSource = DB.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Search...";

            textBox1.ForeColor = Color.Silver;

            comboBox3.SelectedIndex = -1;

            checkBox1.Checked = true;

            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmd_comm = "Select t.*, b.Price, b.Manufacturer from Treatment t " +
                           "JOIN Bioadditive b ON t.Name_bioadditive = b.Name_bioadditive";

            var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

            var DB = new DataSet();

            sqlDataAdapter.Fill(DB);

            dataGridView1.DataSource = DB.Tables[0];
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search...";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search...")
            {
                textBox1.Text = string.Empty;

                textBox1.ForeColor = Color.Black;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select t.*, b.Price, b.Manufacturer from Treatment t " +
                               "JOIN Bioadditive b ON t.Name_bioadditive = b.Name_bioadditive";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmd_comm = "Select c.*, b.Price, b.Manufacturer from Composition c " +
                                "JOIN Bioadditive b ON c.Name_bioadditive = b.Name_bioadditive";

                var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox3.SelectedIndex == -1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}'";
                }

                else if (comboBox3.SelectedIndex == 0)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price <= 100";
                }

                else if (comboBox3.SelectedIndex == 1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 101 AND Price <= 500";
                }

                else if (comboBox3.SelectedIndex == 2)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 501 AND Price <= 1000";
                }

                else if (comboBox3.SelectedIndex == 3)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 1001";
                }
            }
            else
            {
                if (comboBox3.SelectedIndex == -1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}'";
                }

                else if (comboBox3.SelectedIndex == 0)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price <= 100";
                }

                else if (comboBox3.SelectedIndex == 1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price >= 101 AND Price <= 500";
                }

                else if (comboBox3.SelectedIndex == 2)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price >= 501 AND Price <= 1000";
                }

                else if (comboBox3.SelectedIndex == 3)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price >= 1001";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                switch (comboBox3.SelectedIndex)
                {
                    case 0:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price <= 100";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price <= 100";

                        break;

                    case 1:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 101 AND Price <= 500";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 101 AND Price <= 500";

                        break;

                    case 2:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 501 AND Price <= 1000";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 501 AND Price <= 1000";

                        break;

                    case 3:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 1001";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_illness LIKE '{textBox1.Text}') AND Price >= 1001";

                        break;
                }
            }
            else
            {
                switch (comboBox3.SelectedIndex)
                {
                    case 0:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price <= 100";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price <= 100";

                        break;

                    case 1:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 101 AND Price <= 500";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance '{textBox1.Text}') AND Price >= 101 AND Price <= 500";

                        break;

                    case 2:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 501 AND Price <= 1000";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance '{textBox1.Text}') AND Price >= 501 AND Price <= 1000";

                        break;

                    case 3:

                        if (textBox1.Text == "Search...")
                        {
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "Price >= 1001";
                        }
                        else (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                            $"(Name_bioadditive LIKE '{textBox1.Text}' OR Name_active_substance LIKE '{textBox1.Text}') AND Price >= 1001";

                        break;
                }
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var phytocomplex = new Phytocomplex();
            phytocomplex.Show();
            Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                var buy_product = new Buy_Product(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                buy_product.ShowDialog();
            }
            else
            {
                var buy_bad = new Buy_bad(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
                buy_bad.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var userBasket = new UserBasket();
            userBasket.Show();
        }
    }
}
