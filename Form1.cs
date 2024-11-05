using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace BankingProject
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staffhome f6 = new Staffhome();
            f6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            cmd = new SqlCommand("Update Customers Set Account_number ='" + "11111111" + "',Sort_Code ='" + "111111" + "',Card_number='"+ "1111111111111111" + "'", cn);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Numbers updated, Go check the customers table a zbi", "Rak M9wed fl code alm3lem");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\DMUIC VWD\\Banking_Project\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
        }
    }
}
