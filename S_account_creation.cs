using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankingProject
{
    public partial class S_account_creation : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public S_account_creation()
        {
            InitializeComponent();
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void S_account_creation_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pc\\Desktop\\First_year\\DMUIC VWD\\VWD P2837105, Emmanuel Ayomide Akinwumi and P2836959 Mouad Benmansour\\Bank_DB.mdf\";Integrated Security=True");
            cn.Open();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select B_amount from Balance where Username='" + usernam.user + "'", cn);
            dr = cmd.ExecuteReader();
           
            
            if (dr.Read())
            {
                int B_amount = (int)dr["B_amount"];
                dr.Close();
                double savings_credit = Convert.ToDouble(textBox1.Text);
                
                if (B_amount > savings_credit)
                {
                    cmd = new SqlCommand("Update Balance set Savings_name ='" + textBox2.Text + "',Savings_amount=' " + textBox1.Text + "', B_amount = B_amount - '"+ savings_credit + "'Where Username ='"+ usernam.user + "'", cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Savings account is created succesfully", "EMAD BANK");
                    Mainpage mainpage = new Mainpage();
                    mainpage.Show();

                }
                else
                {
                    MessageBox.Show("You only have" + B_amount, " You do not have enough credit ");
                }
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainpage mainpage = new Mainpage();
            mainpage.Show();
            this.Hide();
        }
    }
}
