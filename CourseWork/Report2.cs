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
    public partial class Report2 : Form
    {

        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["DBCourse"].ConnectionString;

        private static string _Name_bioadditive;

        public Report2(string Name_bioadditive)
        {
            InitializeComponent();

            _Name_bioadditive = Name_bioadditive;
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CourseWorkDataSet.Bioadditive". При необходимости она может быть перемещена или удалена.
            this.BioadditiveTableAdapter.Fill(this.CourseWorkDataSet.Bioadditive);

            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            var cmdComm = $"Select * from Bioadditive Where Name_bioadditive = '{_Name_bioadditive}'";

            var sqlDataAdapter = new SqlDataAdapter(cmdComm, sqlConnection);

            var Db = new DataTable();

            sqlDataAdapter.Fill(Db);

            BioadditiveBindingSource.DataSource = Db;

            this.reportViewer1.RefreshReport();
        }
    }
}
