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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BankingProject
{
    public partial class Card_Details : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Card_Details()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Card_Details_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("Select * from Customers where Username = '"+ usernam.user + "'", cn );
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr["Account_Number"].ToString();
                label6.Text = dr["Card_Number"].ToString();
                label7.Text = dr["Sort_Code"].ToString();

            }
            
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainpage f9 = new Mainpage();
            f9.Show();
            this.Hide();
        }
    }
}
