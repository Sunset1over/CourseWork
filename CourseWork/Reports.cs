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
    public partial class Reports : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        public Reports()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmdComm = "WITH cte(Name_bioadditve, [Weight], Price, Type_of_application, Manufacturer, Contraindication, Primary_packaging, r_n) AS (" +
                              "select Name_bioadditive, [Weight], Price, Type_of_application, Manufacturer, Contraindication, Primary_packaging, " + 
                              "ROW_NUMBER() OVER(ORDER BY price DESC) as r_n from Bioadditive) " +
                              "SELECT Name_bioadditve, [Weight], Price, Type_of_application, Manufacturer, Contraindication, Primary_packaging FROM cte WHERE cte.r_n < 11";

                var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }   

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();
                var cmdComm = "with cte(Name_bioadditive, Price, All_Count, Money, r_n) as " + 
                              "(select r.Name_bioadditive, b.Price, Sum(Count) as All_Count, b.Price * Sum(Count) as Money, ROW_NUMBER() OVER(order by SUM(Count) desc) " + 
                              "from Receipt r " + 
                              "join Bioadditive b on b.Name_bioadditive = r.Name_bioadditive " + 
                              "group by r.Name_bioadditive, b.Price) " +
                              "SELECT Name_bioadditive, Price, All_Count, Money FROM cte WHERE cte.r_n < 11";

                var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                var date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmdComm = "select Data, COUNT(id_preorder) as Preorder_count " +
                "from Preorder " +
                $"where Data Between '{date1}' And '{date2}' " +
                "group by[Data]";

                var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                var date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                var sqlConnection = new SqlConnection(_connectionString);

                sqlConnection.Open();

                var cmdComm = "with cte(Primary_packaging, Name_bioadditive, Popular_type, r_n) as " + 
                              "(select b.Primary_packaging, b.Name_bioadditive, Count(b.Primary_packaging) as Popular_type, " +
                              "ROW_NUMBER() OVER(order by Count(b.Primary_packaging) desc) from Receipt r " + 
                              "join Bioadditive b on b.Name_bioadditive = r.Name_bioadditive " + 
                              $"join Preorder p on r.id_preorder = p.id_preorder where p.Data Between '{date1}' And '{date2}' " + 
                              "group by b.Primary_packaging, b.Name_bioadditive) " +
                              "SELECT Primary_packaging, Name_bioadditive, Popular_type FROM cte WHERE cte.r_n < 2";

                var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

                var DB = new DataSet();

                sqlDataAdapter.Fill(DB);

                dataGridView1.DataSource = DB.Tables[0];

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
    }
}
