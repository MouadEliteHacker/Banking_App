using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingProject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace WindowsFormsApp2
{
    
    public partial class Login : Form

    {
        SqlConnection cn;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader rde;

        usernam name;
        public Login()
        {
            InitializeComponent();
            label3.BackColor = System.Drawing.Color.Transparent;
            password.UseSystemPasswordChar = true;

        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { 
            if (checkBox1.Checked )
            {
                password.UseSystemPasswordChar = true;
            }
            else
            {
                password.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;

            // Set the username in the UserData class
            usernam.user = enteredUsername;

            if (password.Text != string.Empty && username.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from Customers where Username='" + username.Text + "' and Pass='" + password.Text + "'", cn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Mainpage home = new Mainpage();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();  // Close the first DataReader before opening the second one

                    cmd1 = new SqlCommand("select * from Staff where S_Username = '" + username.Text + "' and S_Pass = '" + password.Text + "'", cn);
                    rde = cmd1.ExecuteReader();

                    if (rde.Read())
                    {
                        rde.Close();
                        this.Hide();
                        Staffhome trial = new Staffhome();
                        trial.ShowDialog();
                    }
                    else
                    {
                        rde.Close();
                        MessageBox.Show("No account available with this username and password.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                }
               
            }
            


            
            else 
            {
                MessageBox.Show("Please enter value in all fields.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                 registartion f2 = new registartion();
            f2.Show();
            this.Hide();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            name = new usernam();
            linkLabel1.Parent = pictureBox2;
            linkLabel1.BackColor = Color.Transparent;
            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox2;
            label2.BackColor = Color.Transparent;
            label4.Parent = pictureBox2;
            label4.BackColor = Color.Transparent;
            checkBox1.Parent = pictureBox2;
            checkBox1.BackColor = Color.Transparent;
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Contact Customer service at emad.bank@gmail.com", "EMAD BANK");
        }
    }
    }

