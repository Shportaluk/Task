using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Entity;

namespace Todo.WebUI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public PriorityValue Priority { get; set; }
        public TaskModel( int id, string title, bool is_done, PriorityValue priority )
        {
            Id = id;
            Title = title;
            IsDone = is_done;
            Priority = PriorityValue.critical;
        }

    }
}