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
    public partial class Report1 : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private static int _id_preorder;

        public Report1(int id_preorder)
        {
            InitializeComponent();
            _id_preorder = id_preorder;
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CourseWorkDataSet.Receipt". При необходимости она может быть перемещена или удалена.
            this.ReceiptTableAdapter.Fill(this.CourseWorkDataSet.Receipt);

            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmdComm = $"Select * from Receipt Where id_preorder = {_id_preorder}";

            var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

            var Db = new DataTable();

            sqlDataAdapter.Fill(Db);

            ReceiptBindingSource.DataSource = Db;

            this.reportViewer1.RefreshReport();
        }
    }
}
