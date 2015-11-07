using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entity;

namespace FakeRepository
{

    public class FakeTaskRepository //: ITaskRepository
    {
        static List<TaskEntity> listTask = new List<TaskEntity>();
        static int globalId = 0;
        public List<TaskEntity> GetAll()
        {
            return listTask;
        }

        public void Add ( string txt )
        {
            #region Validation

            if ( string.IsNullOrWhiteSpace( txt ) )
            {
                throw new ArgumentException( "Error Task title cannot be empty" );
            }
            else if ( txt.Length > 50 )
            {
                throw new ArgumentException( "Error Task ( Task > 50 sings )" );
            }

            #endregion

            listTask.Add(new TaskEntity( globalId, txt, false));
            globalId++;
        }

        public void Delete(int id, string taskTitle)
        {
            listTask.RemoveAll( t => t.Id == id && t.Title == taskTitle );
        }

        public TaskEntity SelectById(int Id)
        {
            return listTask.Find( m => m.Id == Id );
        }

        public void Update( int Id, string Title, bool IsDone )
        {
            var task = listTask.FirstOrDefault(i => i.Id == Id );
            task.Title = Title;
            task.IsDone = IsDone;
        }
    }
}
