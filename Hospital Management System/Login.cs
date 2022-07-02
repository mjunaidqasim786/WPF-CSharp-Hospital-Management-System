using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class Login : Form
    {
        Databaseusual databasclassobj = new Databaseusual();
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            nametxt.Clear();
            passwordtxt.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            registerform form = new registerform();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "")
            {
                MessageBox.Show("Please enter Your Name");
            }

            else if (passwordtxt.Text == "")
            {
                MessageBox.Show("Please enter Your Password");
            }

            else
            {

                try
                {
                    string str = "Select * from signin Where USER_NAME= '" + nametxt.Text + "'AND USER_PASSWORD= '" + passwordtxt.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("You Are Logged In");
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong UserName Or Password");
                    }
                    databasclassobj.closeConn();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (Label label in Controls.OfType<Label>())
            {
                label.BackColor = Color.Transparent;
            }

        }

        private void exitlabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordtxt.UseSystemPasswordChar == true)
            {
                passwordtxt.UseSystemPasswordChar = false;
            }
            else 
            {
                passwordtxt.UseSystemPasswordChar = true;
            }
        }
    }
}
