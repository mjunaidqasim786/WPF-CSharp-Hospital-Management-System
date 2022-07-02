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
    public partial class Department : Form
    {
        Databaseusual databasclassobj = new Databaseusual();

        public Department()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dptname.Text == "")
            {
                MessageBox.Show("Please enter Department Name");
            }
            else if (dptloc.Text == "")
            {
                MessageBox.Show("Please enter Department Location");
            }
            else if (dptfac.Text == "")
            {
                MessageBox.Show("Please enter Department Facilities");
            }
            
            else
            {

                try
                {
                    string str = "INSERT INTO DEPARTMENT VALUES('" + dptname.Text + "','" + dptloc.Text + "','" + dptfac.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    int result = cmd.ExecuteNonQuery();

               // Entry of data INTO "DEPARTMENT" Table

                    if (result == 1)
                    {
                        MessageBox.Show("Department Saved");
                        dptfac.Clear();
                        dptname.Clear();
                        dptloc.Clear();
                        string str2 = "SELECT * FROM DEPARTMENT";
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

        private void Department_Load(object sender, EventArgs e)
        {
            if (Databaseusual.connection.State == ConnectionState.Closed)
            {
                databasclassobj.createConn();
            }
            string str2 = "SELECT * FROM DEPARTMENT";
            SqlCommand cmd2 = new SqlCommand(str2, Databaseusual.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = new BindingSource(dt, null);
            databasclassobj.closeConn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dptfac.Clear();
            dptname.Clear();
            dptloc.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
