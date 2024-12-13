using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormShop
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter Email and Passwords Properly", "Empty Field");
                return;
            }

            if (txtEmail.Text == "Khurram" && txtPassword.Text == "123")
            {
                MessageBox.Show("Login Successful", "Success");

            }
            else
            {
                MessageBox.Show("Login Failed", "Error");

            }


        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage();
            this.Hide();
            h.ShowDialog();

        }
    }
}
