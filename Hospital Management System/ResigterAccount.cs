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
    public partial class registerform : Form
    {
        Databaseusual databasclassobj = new Databaseusual();
        public registerform()
        {
            InitializeComponent();
           
        }
        private void ResigterAccount_Load(object sender, EventArgs e)
        {
            spepass.Focus();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (spepass.Text == "")
            {
                MessageBox.Show("Please enter Admin Specified Password");
            }

            //Check Specific Password Given Only By Admin

            else if (spepass.Text == "admin")
            {
                if (regusernametxt.Text == "")
                {
                    MessageBox.Show("Please enter Your Name");
                }
                else if (regemailtxt.Text == "")
                {
                    MessageBox.Show("Please enter Your Email");
                }
                else if (regpasstxt.Text == "")
                {
                    MessageBox.Show("Please enter Your Password");
                }
                else if (regdestxt.Text == "")
                {
                    MessageBox.Show("Please enter Your Designation");
                }
                else
                {

                    try
                    {
                        string str = "INSERT INTO signin VALUES('" + regusernametxt.Text + "','" + regemailtxt.Text + "','" + regdestxt.Text + "','" + regpasstxt.Text + "'); ";
                      
                        SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                        if (Databaseusual.connection.State == ConnectionState.Closed)
                        {
                            databasclassobj.createConn();
                        }
                        int result = cmd.ExecuteNonQuery();
                        
                    // Data Entry INTO "SIGNIN" TABLE

                        if (result == 1)
                        {
                            MessageBox.Show("Data Saved");
                            Login homepage = new Login();
                            homepage.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Error Occured");
                        }

                        databasclassobj.closeConn();
                    }
                    catch (SqlException excep)
                    {
                        MessageBox.Show(excep.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Incorrect Admin Specific Password");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            spepass.Focus();
            regdestxt.Clear();
            regusernametxt.Clear();
            regpasstxt.Clear();
            regemailtxt.Clear();
            spepass.Clear();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backlogin_Click(object sender, EventArgs e)
        {
            Login homepage = new Login();
            homepage.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (regpasstxt.UseSystemPasswordChar == true)
            {
                regpasstxt.UseSystemPasswordChar = false;
            }
            else
            {
                regpasstxt.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (spepass.UseSystemPasswordChar == true)
            {
                spepass.UseSystemPasswordChar = false;
            }
            else
            {
                spepass.UseSystemPasswordChar = true;
            }
        }
    }
}
