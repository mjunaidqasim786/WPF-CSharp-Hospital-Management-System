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
    public partial class PatDischarge : Form
    {
        Databaseusual databasclassobj = new Databaseusual();

        public PatDischarge()
        {
            InitializeComponent();
        }

        private void PatDischarge_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (patid.Text == "")
            {
                MessageBox.Show("Please enter Patient ID");
            }
            else if (paygvn.Text == "")
            {
                MessageBox.Show("Please enter Payment");
            }
            else
            {
                //Data Entry "Pat Dis" Table
                try
                {
                    string str = "INSERT INTO PATIENT_DISCHARGED VALUES('" + patid.Text + "','" + trtadv.Text + "','" + trtt.Text + "','" + medgivn.Text + "','" + paygvn.Text + "','" + datedis.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("Patient Dischaged & is Saved");
                        trtt.Clear();
                        trtadv.Clear();
                        paygvn.Clear();
                        datedis.ResetText();
                        medgivn.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
           
            trtt.Clear();
            trtadv.Clear();
            paygvn.Clear();
            datedis.ResetText();
            medgivn.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
