using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Hospital_Management_System
{
    class Databaseusual

    {
        public static readonly string ConnectionString = @"Server=JUNAIDQASIM\SQLEXPRESS;Database=HOSPITAL_DATABASE;Trusted_Connection=True";
        public static SqlConnection connection = new SqlConnection(ConnectionString);
        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void closeConn()
        {
            connection.Close();
        }
    }

}
    

