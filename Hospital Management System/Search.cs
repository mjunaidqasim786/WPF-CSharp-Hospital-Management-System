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
    public partial class search : Form
    {
        Databaseusual databasclassobj = new Databaseusual();
        public search()
        {
            InitializeComponent();
        }

        private void docbuuton_Click(object sender, EventArgs e)
        {
            string str2 = "( SELECT DISTINCT DOCTOR_NUMBER , DOCTOR_NAME , QUALIFICATION , SALARY AS PAYMENT, ADDRESS , PHONE_NO FROM DOCTOR_REGULAR WHERE DOCTOR_NUMBER = '"+docid.Text+ "') UNION (SELECT DOCTOR_NUMBER, DOCTOR_NAME, QUALIFICATION, PYMENT_DUE AS PAYMENT, ADDRESS, PHONE_NO FROM DOCTOR_ON_CALL WHERE DOCTOR_NUMBER = '"+docid.Text+"'); ";
            SqlCommand cmd2 = new SqlCommand(str2);
            SqlDataAdapter da = new SqlDataAdapter(str2, Databaseusual.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = new BindingSource(dt, null);
        }

        private void patbutton_Click(object sender, EventArgs e)
        {
            string str2 = "SELECT * FROM PATIENT_ENTRY WHERE PATIENT_NUMBER = '"+docid.Text+"'";
            SqlCommand cmd2 = new SqlCommand(str2);
            SqlDataAdapter da = new SqlDataAdapter(str2, Databaseusual.connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = new BindingSource(dt, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }
    }
}
