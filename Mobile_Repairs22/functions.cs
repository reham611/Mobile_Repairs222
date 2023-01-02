using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Repairs22
{
    class functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string Constr;

        public functions()
        {
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rohimaa Ramadan\Documents\MobileRepair.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;

        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Constr);
            sda.Fill(dt);
            return dt;
        }
        public int SetData (string Query)
        {
            int Cnt = 0;

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();

            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            return Cnt;
        }
    }
}