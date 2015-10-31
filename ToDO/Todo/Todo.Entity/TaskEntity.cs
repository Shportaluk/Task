using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public TaskEntity( int id, string title, bool is_done )
        {
            Id = id;
            Title = title;
            IsDone = is_done;
        }
    }
}
