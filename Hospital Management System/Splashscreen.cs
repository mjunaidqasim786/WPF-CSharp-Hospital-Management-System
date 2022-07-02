using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            
            progressBar2.Increment(2);
            if (progressBar2.Value == 100)
            {
                timer1.Enabled = false;
                timer1.Stop();
                Login lgin = new Login();
                lgin.Show();
                this.Hide();
            }

        }

        private void Splashscreen_Load(object sender, EventArgs e)
        {
      
        }
    }
}
