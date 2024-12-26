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

            Register r = new Register();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers Where Email ='"+txtEmail.Text+"' AND Password ='"+txtPassword.Text+"'", r.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful", "Success");
                AdmCategoryMgmt adm = new AdmCategoryMgmt();
                adm.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Login Failed: Email or Password Incorrect", "Error");

            }


        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register h = new Register();
            h.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage();
            h.ShowDialog();
            this.Close();


        }
    }
}
