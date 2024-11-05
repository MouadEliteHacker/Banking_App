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

namespace BankingProject
{
    public partial class Account_details : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Account_details()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("select * from Customers where username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label1.Text = usernam.user;
                label2.Text = dr["Firstname"].ToString();
                label3.Text = dr["Middlename"].ToString();
                label4.Text = dr["Secondname"].ToString();
                if (!dr.IsDBNull(dr.GetOrdinal("Phone_number")))
                {
                    label5.Text = dr["Phone_number"].ToString();

                }
                else
                {
                    label5.Text = "No phone number linked to this account";
                }
               

            }
        }

        private void Account_details_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainpage mainpage = new Mainpage();
            mainpage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
