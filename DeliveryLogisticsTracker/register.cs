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

namespace DeliveryLogisticsTracker
{
    public partial class register: Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
   

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }   

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=deliverylogistictrackerlogin;User Id=root;Password=;";

            string email =emailog.Text.Trim();
            string pnumber = phone.Text.Trim();
            string password =Password.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pnumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Email, pnumber, Password) VALUES (@Email, @pnumber, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", pnumber);
                cmd.Parameters.AddWithValue("@Password", password); // In production, hash it!

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!");
                    new login().Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Duplicate email
                    {
                        MessageBox.Show("This email is already registered.");
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
