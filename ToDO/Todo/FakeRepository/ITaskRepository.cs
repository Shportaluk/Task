using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entity;

namespace FakeRepository
{
    public interface ITaskRepository
    {
        List<TaskEntity> GetAll();
        void Add(string txt);
        void Delete(int id, string taskTitle);
        TaskEntity SelectById( int Id );
        void Update(int Id, string Title, bool IsDone);
    }
}
