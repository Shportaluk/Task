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
        string con_str = "Data Source=.\\SQLExpress;Initial Catalog=master;Integrated Security=True";
        //string con_str = "Server=10.7.1.10;Database=SAP_TASK_TODO;User Id=sa;Password=123456;";


        public List<TaskEntity> GetAll()
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM tbl_task";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int id;
            string title;
            bool isDone;

            

            while (reader.Read())
            {
                
                id = int.Parse( reader[0].ToString() );
                title = reader[1].ToString();
                isDone = Boolean.Parse( reader[2].ToString() );
                TaskEntity task = new TaskEntity( id , title, isDone );

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

            while (reader.Read())
            {
                id = int.Parse( reader[0].ToString() );
                title = reader[1].ToString();
                isDone = Boolean.Parse(reader[2].ToString());

                listTask.Add(new TaskEntity(id, title, isDone) );
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

            while (reader.Read())
            {
                id = int.Parse( reader[0].ToString() );
                title = reader[1].ToString();
                isDone = Boolean.Parse( reader[2].ToString() );

                listTask.Add( new TaskEntity( id, title, isDone ) );
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

            cmd.CommandText = string.Format( "INSERT INTO tbl_task VALUES ( '{0}', 'False' )", txt );
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

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = int.Parse(reader[0].ToString());
                title = reader[1].ToString();
                isDone = Boolean.Parse(reader[2].ToString());
                
            }

            con.Close();
            TaskEntity task = new TaskEntity(id, title, isDone);
            return task;
        }

        public void Update(int Id, string Title, bool IsDone)
        {
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("UPDATE tbl_task SET Title = '{0}', IsDone = '{1}' WHERE Id = {2}", Title, IsDone, Id);
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
    }
}
