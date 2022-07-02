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
    public partial class PatientEntry : Form
    {
        Databaseusual databasclassobj = new Databaseusual();

        public PatientEntry()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (namepat.Text == "")
            {
                MessageBox.Show("Please enter Name");
            }
            else if (idpat.Text == "")
            {
                MessageBox.Show("Please enter ID");
            }
            else if (agepat.Text == "")
            {
                MessageBox.Show("Please enter Doctor Age");
            }
            else if (deptpat.Text == "")
            {
                MessageBox.Show("Please enter Department");
            }
            else if (addpat.Text == "")
            {
                MessageBox.Show("Please enter Address");
            }
            else if (phonepat.Text == "")
            {
                MessageBox.Show("Please enter Phone Number");
            }
            else if (referdrpat.Text == "")
            {
                MessageBox.Show("Please enter Doctor Name");
            }
            else
            {
                //Entry Into Patient Entry Table
                try
                {
                    string str = "INSERT INTO PATIENT_ENTRY VALUES('" + idpat.Text + "','" + namepat.Text + "','" + datepat.Text + "','" + agepat.Text + "','" + genderpat.Text + "','" + referdrpat.Text + "','" + diagpat.Text + "','" + statuspat.Text + "','" + addpat.Text + "','" + citypat.Text + "','" + phonepat.Text + "','" + deptpat.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    int result = cmd.ExecuteNonQuery();
                    databasclassobj.closeConn();
                    if (result == 1)
                    {
                        MessageBox.Show("Patient Successfully Saved");
                        namepat.Clear();
                        idpat.Clear();
                        agepat.Clear();
                        datepat.ResetText();
                        statuspat.ResetText();
                        deptpat.ResetText();
                        diagpat.Clear();
                        phonepat.Clear();
                        addpat.Clear();
                        citypat.Clear();
                        referdrpat.Clear();
                        genderpat.ResetText();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured");
                    }
                    

                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            namepat.Clear();
            idpat.Clear();
            agepat.Clear();
            datepat.ResetText();
            statuspat.ResetText();
            deptpat.ResetText();
            diagpat.Clear();
            phonepat.Clear();
            addpat.Clear();
            citypat.Clear();
            referdrpat.Clear();
            genderpat.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
