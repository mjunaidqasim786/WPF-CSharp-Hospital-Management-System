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
    public partial class Doctors : Form
    {
        Databaseusual databasclassobj = new Databaseusual();
        public Doctors()
        {
            InitializeComponent();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            databasclassobj.createConn();
            string str2 = "SELECT * FROM ALL_DOCTORS";
            SqlCommand cmd2 = new SqlCommand(str2, Databaseusual.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = new BindingSource(dt, null);
            databasclassobj.closeConn();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addalldoctorbutton_Click(object sender, EventArgs e)
        {
            if (dptall.Text == "")
            {
                MessageBox.Show("Please enter Department Name");
            }
            else if (didall.Text == "")
            {
                MessageBox.Show("Please enter Doctor Id");
            }
            else
            {

                try
                {
                    string str = "INSERT INTO ALL_DOCTORS VALUES('" + didall.Text + "','" + dptall.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    databasclassobj.createConn();
                    int result = cmd.ExecuteNonQuery();

                    //INSERT INTO "ALL DOC" AND show Data by SELECT Query

                    if (result == 1)
                    {
                        MessageBox.Show("Doctor ID is Saved");


                        string str2 = "SELECT * FROM ALL_DOCTORS";
                        SqlCommand cmd2 = new SqlCommand(str2);
                        SqlDataAdapter da = new SqlDataAdapter(str2, Databaseusual.connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);

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

        private void adddrdcbutton_Click(object sender, EventArgs e)
        {
            if (radiodc.Checked)
            {
                if (namedr.Text == "")
                {
                    MessageBox.Show("Please enter Name");
                }
                else if (diddr.Text == "")
                {
                    MessageBox.Show("Please enter ID As in Above");
                }
                else if (qualdr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Qualification");
                }
                else if (salarydr.Text == "")
                {
                    MessageBox.Show("Please enter Payment");
                }
                else if (adddr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Address");
                }
                else if (phonedr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Phone Number");
                }
                else if (fspc.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Fees Per Call");
                }
                else
                {

                    try
                    {
                        string str = "INSERT INTO DOCTOR_ON_CALL VALUES('" + diddr.Text + "','" + namedr.Text + "','" + qualdr.Text + "','" + fspc.Text + "','" + salarydr.Text + "','" + adddr.Text + "','" + phonedr.Text + "'); ";
                        SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                        databasclassobj.createConn();
                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Doctor Saved");
                            string str2 = "SELECT * FROM DOCTOR_ON_CALL";
                            SqlCommand cmd2 = new SqlCommand(str2);
                            SqlDataAdapter da = new SqlDataAdapter(str2, Databaseusual.connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView2.DataSource = new BindingSource(dt, null);
                            diddr.Clear();
                            namedr.Clear();
                            qualdr.Clear();
                            salarydr.Clear();
                            entrydr.ResetText();
                            exitdr.ResetText();
                            adddr.Clear();
                            phonedr.Clear();
                            datedr.ResetText();
                            fspc.Clear();

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
            else if (radiodr.Checked)
            {
                if (namedr.Text == "")
                {
                    MessageBox.Show("Please enter Name");
                }
                else if (diddr.Text == "")
                {
                    MessageBox.Show("Please enter ID As in Above");
                }
                else if (qualdr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Qualification");
                }
                else if (salarydr.Text == "")
                {
                    MessageBox.Show("Please enter Salary");
                }
                else if (adddr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Address");
                }
                else if (phonedr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Phone Number");
                }
                else if (entrydr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Entry Time");
                }
                else if (datedr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Date Of Joining");
                }
                else if (exitdr.Text == "")
                {
                    MessageBox.Show("Please enter Doctor Exit Time");
                }
                else
                {

                    try
                    {
                        string str5 = "INSERT INTO DOCTOR_REGULAR VALUES('" + diddr.Text + "','" + namedr.Text + "','" + qualdr.Text + "','" + salarydr.Text + "','" + entrydr.Text + "','" + exitdr.Text + "','" + adddr.Text + "','" + phonedr.Text + "','" + datedr.Text + "'); ";
                        SqlCommand cmd5 = new SqlCommand(str5, Databaseusual.connection);
                        if (Databaseusual.connection.State == ConnectionState.Closed)
                        {
                            databasclassobj.createConn();
                        }
                        int result = cmd5.ExecuteNonQuery();

                        //INSERT INTO "REG DOC" AND show Data by SELECT query

                        if (result == 1)
                        {
                            MessageBox.Show("Doctor Saved");
                            diddr.Clear();
                            namedr.Clear();
                            qualdr.Clear();
                            salarydr.Clear();
                            entrydr.ResetText();
                            exitdr.ResetText();
                            adddr.Clear();
                            phonedr.Clear();
                            datedr.ResetText();
                            fspc.Clear();

                            string str6 = "SELECT * FROM DOCTOR_REGULAR";
                            SqlCommand cmd6 = new SqlCommand(str6);
                            SqlDataAdapter da = new SqlDataAdapter(str6, Databaseusual.connection);
                            DataTable dt6 = new DataTable();
                            da.Fill(dt6);
                            dataGridView2.DataSource = new BindingSource(dt6, null);

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
                MessageBox.Show("Select Radio Button Kindly");
            }
        }

        private void radiodr_CheckedChanged(object sender, EventArgs e)
        {
            labelfs.Hide();
            fspc.Hide();
            label6.Text = "Salary";
            label7.Show();
            label11.Show();
            entrydr.Show();
            exitdr.Show();
            label13.Show();
            datedr.Show();
            if (Databaseusual.connection.State == ConnectionState.Closed)
            {
                databasclassobj.createConn();
            }
            string str4 = "SELECT * FROM DOCTOR_REGULAR";
            SqlCommand cmd4 = new SqlCommand(str4, Databaseusual.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            dataGridView2.DataSource = new BindingSource(dt2, null);
            databasclassobj.closeConn();
        }

        private void radiodc_CheckedChanged(object sender, EventArgs e)
        {
            labelfs.Show();
            fspc.Show();
            label6.Text = "Payment";
            label7.Hide();
            label11.Hide();
            entrydr.Hide();
            exitdr.Hide();
            label13.Hide();
            datedr.Hide();
            if (Databaseusual.connection.State == ConnectionState.Closed)
            {
                databasclassobj.createConn();
            }
            string str3 = "SELECT * FROM DOCTOR_ON_CALL";
            SqlCommand cmd3 = new SqlCommand(str3, Databaseusual.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            dataGridView2.DataSource = new BindingSource(dt1, null);
            databasclassobj.closeConn();
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            diddr.Clear();
            namedr.Clear();
            qualdr.Clear();
            salarydr.Clear();
            entrydr.ResetText();
            exitdr.ResetText();
            adddr.Clear();
            phonedr.Clear();
            datedr.ResetText();
            fspc.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            didall.Text = "D";
            dptall.ResetText();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
