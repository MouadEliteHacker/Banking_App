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
    public partial class Staffhome : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Staffhome()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            
        }

        private void Staffhome_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Username.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from Customers where Username='" + Username.Text +"'" , cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cmd = new SqlCommand("Delete From Customers Where Username='" + Username.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    MessageBox.Show("Customer is now deleted");
                }

            }
            else
            {
                MessageBox.Show("No Customer with this username");
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void newcustomer_Click(object sender, EventArgs e)
        {
            Addcustomer f11 = new Addcustomer();
            f11.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Update_Balance_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from Balance Where Username='" + name.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cmd = new SqlCommand("Update Balance set B_amount='" + newbalance.Text + "'where Username ='" + name.Text + "'", cn);
                dr = cmd.ExecuteReader();
                MessageBox.Show("Balance updated for'" + name.Text);
                name.Text = "";
                newbalance.Text = "";

            }
            else
            {
                MessageBox.Show("There is no user with this username");
            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name.Text != string.Empty)
            {
                cmd = new SqlCommand("SELECT B_amount FROM Balance WHERE Username='" + name.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int balance = Convert.ToInt32(dr["B_amount"]);
                    MessageBox.Show($"Balance for {name.Text}: {balance:C}");
                }
                else
                {
                    MessageBox.Show("No Customer with this username");
                }
                dr.Close(); // Close the data reader after usage
            }
            else
            {
                MessageBox.Show("Please enter a username");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stafftranshistory stafftranshistory = new stafftranshistory();
            stafftranshistory.Show();
            this.Close();
        }
    }
    }
