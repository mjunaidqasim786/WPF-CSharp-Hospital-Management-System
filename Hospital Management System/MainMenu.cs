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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Department dept = new Department();
            dept.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Department dept = new Department();
            dept.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Doctors dct = new Doctors();
            dct.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Doctors dct = new Doctors();
            dct.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PatientEntry ptent = new PatientEntry();
            ptent.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            PatientEntry ptent = new PatientEntry();
            ptent.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            RoomsInfo roomsInfo = new RoomsInfo();
            roomsInfo.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            RoomsInfo roomsInfo = new RoomsInfo();
            roomsInfo.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PatientCheckUp patientCheckUp = new PatientCheckUp();
            patientCheckUp.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PatientCheckUp patientCheckUp = new PatientCheckUp();
            patientCheckUp.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PatDischarge patDischarge = new PatDischarge();
            patDischarge.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            PatDischarge patDischarge = new PatDischarge();
            patDischarge.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            search sql = new search();
            sql.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            search sql = new search();
            sql.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
         
        }
    }
}
