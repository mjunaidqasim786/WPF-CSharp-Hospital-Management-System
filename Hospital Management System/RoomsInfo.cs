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
    public partial class RoomsInfo : Form
    {
        Databaseusual databasclassobj = new Databaseusual();

        public RoomsInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roomid.Text == "")
            {
                MessageBox.Show("Please enter Room No.");
            }
            else if (roomstats.Text == "")
            {
                MessageBox.Show("Please enter Status");
            }
            else if (roomtype.Text == "")
            {
                MessageBox.Show("Please enter Room Type");
            }
            else if (roomchrgs.Text == "")
            {
                MessageBox.Show("Please enter Room Charges");
            }
            else
            {
                //DATA entry in "Room" Table
                try
                {
                    string str = "INSERT INTO ROOM_DETAILS VALUES('" + roomid.Text + "','" + roomtype.Text + "','" + roomstats.Text + "','" + roomchrgs.Text + "','" +otherchrgs.Text + "'); ";
                    SqlCommand cmd = new SqlCommand(str, Databaseusual.connection);
                    if (Databaseusual.connection.State == ConnectionState.Closed)
                    {
                        databasclassobj.createConn();
                    }
                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("Room Data Saved");
                        string str2 = "SELECT * FROM ROOM_DETAILS";
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

        private void RoomsInfo_Load(object sender, EventArgs e)
        {
            string str2 = "SELECT * FROM ROOM_DETAILS";
            SqlCommand cmd2 = new SqlCommand(str2);
            SqlDataAdapter da = new SqlDataAdapter(str2, Databaseusual.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = new BindingSource(dt, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            roomchrgs.Clear();
            roomid.Clear();
            roomstats.ResetText();
            roomtype.ResetText();
            otherchrgs.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
