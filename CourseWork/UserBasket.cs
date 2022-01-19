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
    public partial class UserBasket : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private DataTable _table = new DataTable();

        public UserBasket()
        {
            InitializeComponent();

            _table.Columns.Add("Barcode");
            _table.Columns.Add("Name bioadditive");
            _table.Columns.Add("Count");
            _table.Columns.Add("Price");

            var cmd_text = "Select * from Delivery";

            var sqlConnection = new SqlConnection(_connectionString);

            var sqlCommand = new SqlCommand(cmd_text, sqlConnection);

            var table = new DataTable();

            var adapterBioadditive = new SqlDataAdapter(sqlCommand);

            adapterBioadditive.Fill(table);

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Name_delivery";
            comboBox1.ValueMember = "Name_delivery";
            comboBox1.SelectedIndex = -1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var VARIABLE in Basket.ListBarcode)
            {
                _table.Rows.Add(VARIABLE);
            }

            for (var i = 0; i < _table.Rows.Count; i++)
            {
                _table.Rows[i][1] = Basket.ListName[i];
            }

            for (var i = 0; i < _table.Rows.Count; i++)
            {
                _table.Rows[i][2] = Basket.ListCount[i];
            }

            for (var i = 0; i < _table.Rows.Count; i++)
            {
                _table.Rows[i][3] = Basket.ListPrice[i];
            }

            dataGridView1.DataSource = _table;

            if (_table.Rows.Count > 0)
            {
                var sum = 0;

                foreach (DataRow VARIABLE in _table.Rows)
                {
                    sum += Convert.ToInt32(VARIABLE[3]) * Convert.ToInt32(VARIABLE[2]);
                }

                textBox2.Text = sum.ToString();
            }
            else
            {
                textBox2.Text = "0";
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
