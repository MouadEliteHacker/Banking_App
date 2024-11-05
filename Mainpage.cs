using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankingProject
{
    public partial class Mainpage : Form
    {
        SqlConnection cn;
        SqlDataReader dr;
        SqlCommand cmd;

        public Mainpage()
        {

            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            lblBalance.BackColor = Color.Transparent;
            lblname.BackColor = Color.Transparent;

            linkLabel1.BackColor = Color.Transparent;
            linkLabel2.BackColor = Color.Transparent;
            lblname.Text = usernam.user;

            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("select B_amount from Balance where Username='" + lblname.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                lblBalance.Text = dr["B_amount"].ToString();

            }
            dr.Close();
            cmd = new SqlCommand("Select * from Balance where Username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string save = dr["Savings_name"].ToString();
                if (!dr.IsDBNull(dr.GetOrdinal("Savings_amount")) && save != null)
                {
                    linkLabel1.Text = "Open Savings account";

                }
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payee_info f4 = new Payee_info();
            f4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Card_Details f4 = new Card_Details();
            f4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                Login f7 = new Login();
                f7.Show();
                this.Hide();
                MessageBox.Show("You have logged out successfully");

            }

        }




        private void MainPage_Load(object sender, EventArgs e)
        {



        }

        public void Balance_Click(object sender, EventArgs e)
        {


        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dr.Close();
            cmd = new SqlCommand("Select * from Balance where Username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string save = dr["Savings_name"].ToString();
                if (!dr.IsDBNull(dr.GetOrdinal("Savings_amount")) && save != null)
                {
                    Savings_account savings_Account = new Savings_account();
                    savings_Account.Show();
                    this.Hide();

                }
                else
                {
                    S_account_creation s_Account_Creation = new S_account_creation();
                    s_Account_Creation.Show();
                    this.Hide();
                }

            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account_details account_Details = new Account_details();
            account_Details.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to proceed deleting your account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                dr.Close();
                cmd = new SqlCommand("Delete From Customers Where Username='" + usernam.user + "'", cn);
                cmd.ExecuteNonQuery();

                Login f7 = new Login();
                f7.Show();
                this.Close();
                MessageBox.Show("Account deleted successfully", "EMAD BANK");


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usertranshistory usertranshistory = new Usertranshistory();
            usertranshistory.Show();
            this.Close();

        }
    }
}
