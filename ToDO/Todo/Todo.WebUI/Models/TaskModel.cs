using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.WebUI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public TaskModel( int id, string title, bool is_done )
        {
            Id = id;
            Title = title;
            IsDone = is_done;
        }

    }
}