using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormShop
{
    public partial class AdmProductsMgmt : Form
    {
        public SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=db_ShoppingStore;Integrated Security=True;");
        string ImageDbPath = null;
        public AdmProductsMgmt()
        {
            InitializeComponent();

            ListData();
            FillBrands();
            FillCategories();   


        }

        void FillBrands()
        {
            SqlCommand cmd = new SqlCommand("select * from Brands", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbBrands.Items.Clear();
            cbBrands.DataSource = dt;

            cbBrands.DisplayMember = "BrandName";
            cbBrands.ValueMember = "BrandID";


        }

        void FillCategories()
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCategory.Items.Clear();
            cbCategory.DataSource = dt;

            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";


        }

        void ListData()
        {
            SqlCommand cmd = new SqlCommand("select * from Products", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataGridCats.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Required
            //
            try
            {
                //Query
                SqlCommand cmd = new SqlCommand("Insert Into Products Values ('"+txtName.Text+"','"+cbBrands.SelectedValue+"','"+cbBrands.SelectedValue+"','"+txtPrice.Text+"','"+txtQty.Text+"','','"+txtDetail.Text+"','"+ImageDbPath+"')", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Create Dialog
            OpenFileDialog ofd = new OpenFileDialog();

            //Filter
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp";
            //Dialog Open Result
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                //File Name
                string FileNameOnly = Path.GetFileName(ofd.FileName);
                //Dest Path
                string DestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", FileNameOnly);
                //Folder Creation
                Directory.CreateDirectory(Path.GetDirectoryName(DestPath));
                //Copy
                File.Copy(ofd.FileName, DestPath, true);
                //Image Bind Label
                pictureBox1.ImageLocation = DestPath;
                lblImage.Text = FileNameOnly;

                ImageDbPath = FileNameOnly;

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Query
                SqlCommand cmd = new SqlCommand("DELETE FROM Products Where ProductID = '"+txtID.Text+"'", con);
                //Execute Open, Close
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Update List
                ListData();
                //Message
                MessageBox.Show("Item Deleted successfully.", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong. Please try again later.\nError: " + ex.Message);


            }
        }
    }
}
