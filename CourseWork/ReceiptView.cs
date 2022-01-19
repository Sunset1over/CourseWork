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
    public partial class ReceiptView : Form
    {

        private static readonly string _connectionString =
                ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;
        
        public ReceiptView()
        {
            InitializeComponent();

            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmdComm = "Select * from Receipt";

            var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

            var dB = new DataSet();

            sqlDataAdapter.Fill(dB);

            dataGridView1.DataSource = dB.Tables[0];
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           var report1 = new Report1(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value));
           report1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmd_comm = "select * from Receipt";

            var sqlDataAdapter = new SqlDataAdapter(cmd_comm, sqlConnection);

            var DB = new DataSet();

            sqlDataAdapter.Fill(DB);

            dataGridView1.DataSource = DB.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                    $"id_preorder = {Convert.ToInt32(textBox1.Text)} or id_receipt = {Convert.ToInt32(textBox1.Text)}";
            }
        }
    }
}
