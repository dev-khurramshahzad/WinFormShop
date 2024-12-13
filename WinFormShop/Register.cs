using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormShop
{

    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login h = new Login();
            h.ShowDialog();
            this.Close();
            

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //Empty Field Validation
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPass.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Please Fill all fields Properly", "Empty Fields");
                    return;

                }

                //Password Matching Validation
                if (txtConfirmPass.Text != txtPassword.Text)
                {
                    MessageBox.Show("Passwords do not match", "Error");
                    return;
                }

                //Regular Expression Validation
                if (!Regex.IsMatch(txtEmail.Text, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"))
                {
                    MessageBox.Show("Invalid Email Format", "Error");
                    return;
                }

                //Data Insertion into Database

                SqlConnection con = new SqlConnection("Data Source=KHURRAM-MACBOOK;Initial Catalog=db_WinFormShop;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES('" + txtName.Text + "','" + txtEmail.Text + "','"+txtPhone.Text+"','"+txtPassword.Text+"','"+txtAddress.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Entered", "Success");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Somthing Went wrong...\nError Trace : "+ex.Message, "Message");
            }



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage();
            h.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
