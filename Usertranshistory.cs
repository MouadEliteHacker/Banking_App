using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankingProject
{
    public partial class Usertranshistory : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Usertranshistory()
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

            cmd = new SqlCommand("SELECT * FROM Transactions where Payee_Username='" + usernam.user + "'or Sender_Username='" + usernam.user + "'", cn);
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

        private void Usertranshistory_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainpage mainpage = new Mainpage();
            mainpage.Show();
            this.Close();
        }
    }
}