using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace BankingProject
{
    public partial class Savings_account : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Savings_account()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Savings_account_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("Select * from Balance where username ='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label3.Text = dr["Savings_name"].ToString();

                label4.Text = dr["Savings_amount"].ToString();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainpage mainpage = new Mainpage();
            mainpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int money_added = Convert.ToInt16(textBox1.Text);
            dr.Close();

            cmd = new SqlCommand("Select * from Balance where Username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();


            string stringValue = textBox1.Text;
            int intValue;

            if (int.TryParse(stringValue, out intValue))
            {
                if (dr.Read() && money_added > 0)
                {
                    int B_amount = (int)dr["B_amount"];
                    if (money_added < B_amount)
                    {
                        dr.Close();
                        cmd = new SqlCommand("Update Balance set Savings_amount = Savings_amount +'" + Convert.ToInt32(textBox1.Text) + "',B_amount = B_amount -'" + Convert.ToInt32(textBox1.Text) + "'where Username='" + usernam.user + "'", cn);
                        dr = cmd.ExecuteReader();
                        MessageBox.Show(" Refresh to check the actual Balance", "Money added");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You do no have enough Balance to increase your savings");
                    }
                }
            }
            else
            {
                MessageBox.Show("You can only insert numbers", "EMAD BANK");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Savings_account savings_Account = new Savings_account();
            savings_Account.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int money_retrieved = Convert.ToInt16(textBox2.Text);
            dr.Close();
            cmd = new SqlCommand("Select * from Balance where Username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();

            string stringValue = textBox2.Text;
            int intValue;

            if (int.TryParse(stringValue, out intValue))
            {
                if (dr.Read() && money_retrieved > 0)
                {
                    int Savings = (int)dr["Savings_amount"];
                    if (money_retrieved < Savings)
                    {
                        dr.Close();
                        cmd = new SqlCommand("update Balance set Savings_amount= Savings_amount - '" + Convert.ToInt32(textBox2.Text) + "', B_amount = B_amount + '" + Convert.ToInt32(textBox2.Text) + "'where Username ='" + usernam.user + "'", cn);
                        dr = cmd.ExecuteReader();
                        MessageBox.Show(" Refresh to check the actual Balance", "Money retrieved");
                        textBox2.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("You do not have that amount in your savings");
                }
            }
            else
            {
                MessageBox.Show("You can only insert numbers");
                textBox2.Text = string.Empty;

            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                dr.Close();
                cmd = new SqlCommand("Update Balance set Savings_name = NULL ,Savings_amount = NULL where Username ='" + usernam.user + "'", cn);
                dr = cmd.ExecuteReader();
                Mainpage mainpage = new Mainpage();
                mainpage.Show();
                this.Close();
                MessageBox.Show("Your savings account was succesfully deleted", "EMAD BANK");



            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
