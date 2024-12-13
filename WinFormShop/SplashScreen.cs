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
    public partial class SplashScreen : Form
    {
        private int progress = 0;
        public SplashScreen()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            progress += 5;

            if (progress >= 100)
            {
                this.Close();
            }
            progressBar1.Value = progress;
            label1.Text = progress.ToString() + "%";

        }
    }
}
