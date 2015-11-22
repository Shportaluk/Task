using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeRepository
{
    public class SqlUserRepository : IUserRepository
    {
        private string con_str { get; set; }
        public SqlUserRepository()
        {
            //con_str = "Data Source=.\\SQLExpress;Initial Catalog=master;Integrated Security=True";
            con_str = "Server=10.7.1.10;Database=SAP_TASK_TODO;User Id=sa;Password=123456;";
        }
        public bool IsUser( string user, string pass )
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("SELECT * FROM tbl_Users WHERE Login = '{0}' and Pass = '{1}'", user, pass);
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (!string.IsNullOrWhiteSpace(reader[0].ToString()))
                { return true; }
            }

            con.Close();
            return false;
        }
    }
}
