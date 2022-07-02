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
    public partial class PatientCheckUp : Form
    {
        Databaseusual databasclassobj = new Databaseusual();
        public PatientCheckUp()
        {
            InitializeComponent();
        }

        private void PatientCheckUp_Load(object sender, EventArgs e)
        {
            
        }

        private void radioAdmit_CheckedChanged(object sender, EventArgs e)
        {
            oaftrcond.Hide();
            oaftrconl.Hide();
            oopno.Hide();
            oopnol.Hide();
            oother.Hide();
            ootherl.Hide();
            ormedl.Hide();
            ormedno.Hide();
            otype.Hide();
            otypel.Hide();
            rpay.Hide();
            rpayl.Hide();
            ordnol.Hide();
            ordno.Hide();

            aadvn.Show();
            aadvnl.Show();
            aattdnl.Show();
            aattdnt.Show();
            adeptnl.Show();
            adeptnt.Show();
            adiagl.Show();
            adiagt.Show();
            amodepl.Show();
            amodptxt.Show();
            aroomnl.Show();
            aroomnt.Show();
            artrt.Hide();
            artrtl.Hide();
            aaaadatel.Show();
            aaaadatet.Show();
        }

        private void radioOperate_CheckedChanged(object sender, EventArgs e)
        {
            aadvn.Hide();
            aadvnl.Hide();
            aattdnl.Hide();
            aattdnt.Hide();
            adeptnl.Hide();
            adeptnt.Hide();
            adiagl.Hide();
            adiagt.Hide();
            amodepl.Hide();
            amodptxt.Hide();
            aroomnl.Hide();
            aroomnt.Hide();
            artrt.Hide();
            artrtl.Hide();
            rpay.Hide();
            rpayl.Hide();
            aaaadatel.Hide();
            aaaadatet.Hide();

            oaftrcond.Show();
            oaftrconl.Show();
            oopno.Show();
            oopnol.Show();
            oother.Show();
            ootherl.Show();
            ormedl.Show();
            ormedno.Show();
            otype.Show();
            otypel.Show();
          
            ordnol.Show();
            ordno.Show();

        }

        private void radioregular_CheckedChanged(object sender, EventArgs e)
        {
            oaftrcond.Hide();
            oaftrconl.Hide();
            oopno.Hide();
            oopnol.Hide();
            oother.Hide();
            ootherl.Hide();
            aadvn.Hide();
            aadvnl.Hide();
            aattdnl.Hide();
            aattdnt.Hide();
            adeptnl.Hide();
            adeptnt.Hide();
            adiagl.Hide();
            adiagt.Hide();
            amodepl.Hide();
            amodptxt.Hide();
            otype.Hide();
            otypel.Hide();
            aroomnl.Hide();
            aroomnt.Hide();
            aaaadatel.Hide();
            aaaadatet.Hide();

            rpay.Show();
            rpayl.Show();
            ordno.Show();
            ordnol.Show();
            artrt.Show();
            artrtl.Show();
            ormedl.Show();
            ormedno.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioAdmit.Checked)
            {
                if (aprpatid.Text == "")
                {
                    MessageBox.Show("Please enter ID");
                }
                else if (aprcond.Text == "")
                {
                    MessageBox.Show("Please enter Condition");
                }
                else if (aadvn.Text == "")
                {
                    MessageBox.Show("Please enter Advance Payment");
                }
                else if (aroomnt.Text == "")
                {
                    MessageBox.Show("Please enter Room No.");
                }
                else if (adeptnt.Text == "")
                {
                    MessageBox.Show("Please enter Department");
                }
                else if (amodptxt.Text == "")
                {
                    MessageBox.Show("Please enter Phone Number");
                }
                else if (aprdate.Text == "")
                {
                    MessageBox.Show("Please enter Date");
                }
                else
                {
                    try
                    {
                        //INSERT data in Doc admit Junaid
                        string str = "INSERT INTO PATIENT_ADMITTED VALUES('" + aprpatid.Text + "','" + aadvn.Text + "','" + amodptxt.Text + "','" + aroomnt.Text + "','" + adeptnt.Text + "','" + aprdate.Text + "','" + aprcond.Text + "','" + adiagt.Text + "','" + aaaadatet.Text + "','" + aattdnt.Text + "'); ";
                        SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                        if (Databaseusual.connection.State == ConnectionState.Closed)
                        {
                            databasclassobj.createConn();
                        }
                        int result = cmd.ExecuteNonQuery();
                        databasclassobj.closeConn();
                        if (result == 1)
                        {
                            MessageBox.Show("Admitted Patient Info Saved");
                            foreach (TextBox textBox in Controls.OfType<TextBox>())
                            {
                                textBox.Text = "";
                            }

                            amodptxt.ResetText();
                            adeptnt.ResetText();
                            aprcond.ResetText();
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
            else if (radioOperate.Checked)
            {
                if (aprpatid.Text == "")
                {
                    MessageBox.Show("Please enter ID");
                }
                else if (aprcond.Text == "")
                {
                    MessageBox.Show("Please enter Condition");
                }
                else if (oopno.Text == "")
                {
                    MessageBox.Show("Please enter Operation Theatre No.");
                }
                else if (ordno.Text == "")
                {
                    MessageBox.Show("Please enter Doctor No.");
                }
                else if (ormedl.Text == "")
                {
                    MessageBox.Show("Please enter Medicine");
                }
                else if (otype.Text == "")
                {
                    MessageBox.Show("Please enter Type");
                }
                else if (aprdate.Text == "")
                {
                    MessageBox.Show("Please enter Date");
                }
                else
                {
              
                    try
                    {
                        string str = "INSERT INTO PATIENT_OPERATED VALUES('" + aprpatid.Text + "','" + aprdate.Text + "','" + aprcond.Text + "','" + oaftrcond.Text + "','" + otype.Text + "','" + ormedno.Text + "','" + ordno.Text + "','" + oopno.Text + "','" + oother.Text + "'); ";
                        SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                        databasclassobj.createConn();
                        int result = cmd.ExecuteNonQuery();
                        databasclassobj.closeConn();
                        if (result == 1)
                        {
                            MessageBox.Show("Operated Patient Info Saved");
                            foreach (TextBox textBox in Controls.OfType<TextBox>())
                            {
                                textBox.Text = "";
                            }

                            amodptxt.ResetText();
                            adeptnt.ResetText();
                            aprcond.ResetText();
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
            else if (radioregular.Checked)
            {
                if (aprpatid.Text == "")
                {
                    MessageBox.Show("Please enter ID");
                }
                else if (aprcond.Text == "")
                {
                    MessageBox.Show("Please enter Condition");
                }
                else if (rpay.Text == "")
                {
                    MessageBox.Show("Please enter Payment");
                }
                else if (ordno.Text == "")
                {
                    MessageBox.Show("Please enter Doctor No.");
                }
                else if (ormedl.Text == "")
                {
                    MessageBox.Show("Please enter Medicine");
                }
                
                else if (aprdate.Text == "")
                {
                    MessageBox.Show("Please enter Date");
                }
                else
                {
                    //"PAT REG" TABLE ENTRY
                    try
                    {
                        string str = "INSERT INTO PATIENT_REGULAR VALUES('" + aprpatid.Text + "','" + aprdate.Text + "','" + aprcond.Text + "','" + artrt.Text + "','" + ormedno.Text + "','" + ordno.Text + "','" + rpay.Text + "'); ";
                        SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                        if (Databaseusual.connection.State == ConnectionState.Closed)
                        {
                            databasclassobj.createConn();
                        }
                        int result = cmd.ExecuteNonQuery();
                        databasclassobj.closeConn();
                        if (result == 1)
                        {
                            MessageBox.Show("Regular Patient Info Saved");
                            foreach (TextBox textBox in Controls.OfType<TextBox>())
                            {
                                textBox.Text = "";
                            }

                            amodptxt.ResetText();
                            adeptnt.ResetText();
                            aprcond.ResetText();
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
            else
            {
                MessageBox.Show("Please Radio Button First.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idpatchk.Text == "")
            {
                MessageBox.Show("Please enter ID");
            }
            else if (diagpatchk.Text == "")
            {
                MessageBox.Show("Please enter Diagnosis");
            }
            else if (docidchk.Text == "")
            {
                MessageBox.Show("Please enter Doctor ID");
            }
            else if (treatpatchk.Text == "")
            {
                MessageBox.Show("Please enter Treatment");
            }
            else
            {
                //INSERT data in "PAT CHKUP" Junaid
                try
                {
                    string str = "INSERT INTO PATIENT_CHECKUP VALUES('" + idpatchk.Text + "','" + docidchk.Text + "','" + diagpatchk.Text + "','" + statspatchk.Text + "','" + treatpatchk.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    int result = cmd.ExecuteNonQuery();
                    databasclassobj.closeConn();
                    if (result == 1)
                    {
                        MessageBox.Show("Patient Info Saved");
                        foreach (TextBox textBox in Controls.OfType<TextBox>())
                        {
                            textBox.Text = "";
                        }

                        amodptxt.ResetText();
                        adeptnt.ResetText();
                        aprcond.ResetText();
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
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }

            amodptxt.ResetText();
            adeptnt.ResetText();
            aprcond.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
