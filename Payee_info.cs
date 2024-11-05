using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BankingProject
{
    public partial class Payee_info : Form

    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommand cmd1;
        SqlDataReader dr1;

        public Payee_info()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;

        }
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to proceed sending money to "+ Username.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {

                if (Username.Text != string.Empty && Sortcode.Text != string.Empty && Accountnumber.Text != string.Empty && Amount.Text != string.Empty)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Username = '" + Username.Text + "'AND Sort_Code ='" + Sortcode.Text + "'AND Account_number ='" + Accountnumber.Text + "'", cn))


                    using (SqlDataReader dr = cmd.ExecuteReader())

                        if (dr.Read() && usernam.user != Username.Text)
                        {
                            dr.Close();

                            int money_sent = Convert.ToInt16(Amount.Text);

                            cmd1 = new SqlCommand("Select B_amount from Balance where Username='" + usernam.user + "'", cn);
                            dr1 = cmd1.ExecuteReader();



                            if (dr1.Read() && money_sent > 0)
                            {
                                int B_amount = (int)dr1["B_amount"];
                                if (money_sent < B_amount)
                                {
                                    dr1.Close();
                                    cmd1 = new SqlCommand("update Balance set B_amount= B_amount + '" + Convert.ToDouble(Amount.Text) + "'where Username='" + Username.Text + "'", cn);
                                    dr1 = cmd1.ExecuteReader();
                                    dr1.Close();
                                    cmd1 = new SqlCommand("update Balance set B_amount = B_amount - '" + Convert.ToDouble(Amount.Text) + "'where Username='" + usernam.user + "'", cn);
                                    dr1 = cmd1.ExecuteReader();
                                    dr1.Close();
                                    Random random = new Random();

                                    int TID = random.Next(1, 675);
                                    string tid = "T" + TID.ToString();
                                    cmd1 = new SqlCommand("Insert into Transactions Values (@ID , @Payee, @Sender, @amount) ", cn);

                                    cmd1.Parameters.AddWithValue("ID", tid);
                                    cmd1.Parameters.AddWithValue("Payee", usernam.user);
                                    cmd1.Parameters.AddWithValue("Sender", Username.Text);
                                    cmd1.Parameters.AddWithValue("amount", money_sent);
                                    dr1 = cmd1.ExecuteReader();
                                    dr1.Close();

                                    MessageBox.Show("Payment Successful", "Money Sent");
                                    Mainpage home = new Mainpage();
                                    home.Show();
                                    this.Hide();
                                }


                                else
                                {
                                    dr1.Close();
                                    MessageBox.Show("You don't have enough Credit to make this transfer", "Credit failure");

                                }

                            }




                        }
                        else
                        {
                            MessageBox.Show("Username not available or wrong account details", "Try again");
                        }
                }
                else
                {
                    MessageBox.Show("Please Enter values in all fields", "No data inserted");

                }
            } 
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string Message = "You cannot insert anything other than a number";
            
            try
            {   
                Convert.ToDecimal(Amount.Text);
            }
            catch 
            {
                MessageBox.Show(Message);

            }
        }

        private void Payee_info_Load(object sender, EventArgs e)
        {
           
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainpage f8 = new Mainpage();
            f8.Show();
            this.Hide();
        }
    }
}
