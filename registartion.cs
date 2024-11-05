using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class registartion : Form
    {
        SqlConnection cn;
        SqlDataReader dr;
        SqlCommand cmd;

        
        public registartion()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            

        }
      

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void registartion_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();

        }

        private void Firstname_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtconfirmpassword.Text != string.Empty || txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                if (txtpassword.Text == txtconfirmpassword.Text)
                {
                    
                    cmd = new SqlCommand("select * from Customers where username='" +
                    txtusername.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        string stringValue = Age.Text;
                        int intValue;

                        if (int.TryParse(stringValue, out intValue) && intValue < 100 && intValue >= 18)
                        {


                            dr.Close();
                            Random random = new Random();
                            string Acc_number = Convert.ToString(random.Next(10000000, 99999999));
                            string S_code = Convert.ToString(random.Next(100000, 999999));
                            string card_number1 = Convert.ToString(random.Next(1000, 9999));
                            string card_number2 = Convert.ToString(random.Next(1000, 9999));
                            string card_number3 = Convert.ToString(random.Next(1000, 9999));
                            string card_number4 = Convert.ToString(random.Next(1000, 9999));
                            string card_number = card_number1 + " " + card_number2 + " " + card_number3 + " " + card_number4;

                            cmd = new SqlCommand("insert into Customers(Username, Firstname, MiddleName, Secondname,  Pass, Phone_Number, Account_number, Sort_Code, Card_number, Age) values(@username, @Firstname, @Middlename, @Lastname, @password, @number, @Account_number, @Sort_Code, @Card_number, @Age)", cn);
                            cmd.Parameters.AddWithValue("username", txtusername.Text);
                            cmd.Parameters.AddWithValue("password", txtpassword.Text);
                            cmd.Parameters.AddWithValue("Firstname", Firstname.Text);
                            cmd.Parameters.AddWithValue("Middlename", MiddleName.Text);
                            cmd.Parameters.AddWithValue("Lastname", Lastname.Text);
                            cmd.Parameters.AddWithValue("number", Phone_number.Text);
                            cmd.Parameters.AddWithValue("Account_number", Acc_number);
                            cmd.Parameters.AddWithValue("Sort_Code", S_code);
                            cmd.Parameters.AddWithValue("Card_number", card_number);
                            cmd.Parameters.AddWithValue("Age", Age.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your Account is created. Please login now.", "Done",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login login = new Login();
                            login.Show();

                            int random_ID = random.Next(3, 750);
                            int random_amount = random.Next(100, 2000);

                            cmd = new SqlCommand("insert into Balance(B_ID,Username, B_amount) Values(@ID, @username, @amount) ", cn);
                            cmd.Parameters.AddWithValue("ID", random_ID);
                            cmd.Parameters.AddWithValue("username", txtusername.Text);
                            cmd.Parameters.AddWithValue("amount", random_amount);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            dr.Close();
                            MessageBox.Show("Your age can only be a number between 18 and 100 years", "Age not valid" );
                            

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            else
                {
                    MessageBox.Show("Please enter value in all fields.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f10 = new Login();
            f10.Show();
            this.Hide();
        }
    }
    }

