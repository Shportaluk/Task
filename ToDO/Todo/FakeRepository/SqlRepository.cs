using FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entity;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SqlRepository
{
    public class SqlTaskRepository : ITaskRepository
    {
        List<TaskEntity> listTask = new List<TaskEntity>();
        private string con_str { get; set; }

        public SqlTaskRepository()
        {
            con_str = "Data Source=.\\SQLExpress;Initial Catalog=master;Integrated Security=True";
            //con_str = "Server=10.7.1.10;Database=SAP_TASK_TODO;User Id=sa;Password=123456;";
        }

        public SqlTaskRepository( string con_str )
        {
            this.con_str = con_str;
        }

        public List<TaskEntity> GetAll( string Id_Task )
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            //cmd.CommandText = "SELECT * FROM tbl_task";
            cmd.CommandText = String.Format( "SELECT * FROM tbl_task WHERE Id_User = {0}", Id_Task );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int id;
            string title;
            bool isDone;
            int priority;
            

            while (reader.Read())
            {
                
                id = int.Parse( reader[0].ToString() );
                title = reader[1].ToString();
                isDone = Boolean.Parse( reader[2].ToString() );
                priority = int.Parse( reader[3].ToString() );
                TaskEntity task = new TaskEntity( id , title, isDone, priority );

                listTask.Add(task);
            }

            con.Close();


            return listTask;
        }

        public List<TaskEntity> GetDone()
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM tbl_task WHERE IsDone = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            int id;
            string title;
            bool isDone;
            int priority;


            while (reader.Read())
            {

                id = int.Parse(reader[0].ToString());
                title = reader[1].ToString();
                isDone = Boolean.Parse(reader[2].ToString());
                priority = int.Parse(reader[3].ToString());
                TaskEntity task = new TaskEntity(id, title, isDone, priority);
            }

            return listTask;
        }

        public List<TaskEntity> GetDontDone()
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM tbl_task WHERE IsDone = 0";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int id;
            string title;
            bool isDone;
            int priority;

            while (reader.Read())
            {
                id = int.Parse( reader[0].ToString() );
                title = reader[1].ToString();
                isDone = Boolean.Parse( reader[2].ToString() );
                priority = int.Parse(reader[3].ToString());
                TaskEntity task = new TaskEntity(id, title, isDone, priority);
            }

            return listTask;
        }

        public void Add(string txt)
        {
            #region Validation

            if (string.IsNullOrWhiteSpace(txt))
            {
                throw new ArgumentException("Error Task title cannot be empty");
            }
            else if (txt.Length > 50)
            {
                throw new ArgumentException("Error Task ( Task > 50 sings )");
            }

            #endregion

            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("INSERT INTO tbl_task VALUES ( '{0}' , '0', 2 );", txt);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            con.Close();

        }

        public void Delete(int id, string taskTitle)
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("DELETE FROM tbl_task WHERE Id = {0}", id );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            con.Close();
        }

        public TaskEntity SelectById(int Id)
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("SELECT * FROM tbl_task WHERE Id = {0}", Id);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            int id = 0;
            string title = " ";
            bool isDone = false;
            int priority = 0;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = int.Parse(reader[0].ToString());
                title = reader[1].ToString();
                isDone = Boolean.Parse(reader[2].ToString());
                priority = int.Parse( reader[3].ToString() );
            }

            con.Close();
            TaskEntity task = new TaskEntity(id, title, isDone, priority);
            return task;
        }

        public void Update(int Id, string Title, bool IsDone, int Priority)
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("UPDATE tbl_task SET Title = '{0}', IsDone = '{1}', Priority = {2} WHERE Id = {3}", Title, IsDone,  Priority, Id);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
            con.Close();
        }

        public void ChangeStatus( int id )
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("UPDATE tbl_task SET IsDone = 1 WHERE Id = {0}", id );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
                cmd.ExecuteReader();
            con.Close();
        }

        public bool CheckUser( string user, string pass )
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format( "SELECT Id_Task FROM tbl_Users WHERE Login = '{0}' and Pass = '{1}'", user, pass );
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (!string.IsNullOrWhiteSpace( reader[0].ToString() ) )
                {
                    //Id_Task = reader[0].ToString();
                    return true;
                }
            }

            con.Close();
               
            return false;
        }
    }
}
