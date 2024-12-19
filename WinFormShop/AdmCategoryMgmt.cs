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
    public partial class AdmCategoryMgmt : Form
    {
        public SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_ShoppingStore;Integrated Security=True;");

        public AdmCategoryMgmt()
        {
            InitializeComponent();

            ListData();


        }

        void ListData()
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataGridCats.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Required

            try
            {
                //Query
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES('" + txtName.Text + "','" + txtDetail.Text + "','Image')", con);
                //Execute Open, Close
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Update List
                ListData();
                //Message
                MessageBox.Show(txtName.Text + " added successfully.", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong. Please try again later.\nError: " + ex.Message);


            }
        }
    }
}
