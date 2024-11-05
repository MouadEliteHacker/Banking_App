using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankingProject
{
    public partial class stafftranshistory : Form
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public stafftranshistory()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Set up DataGridView properties
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;

            // Load data into DataGridView
            LoadTransactionData();
        }

        private void LoadTransactionData()
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();

            string query = "SELECT * FROM Transactions";
            cmd = new SqlCommand(query, cn);
            dr = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dr);

            dataGridView1.DataSource = dataTable;

            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }

        private void stafftranshistory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staffhome staffhome = new Staffhome();
            staffhome.Show();
            this.Close();
        }
    }
}