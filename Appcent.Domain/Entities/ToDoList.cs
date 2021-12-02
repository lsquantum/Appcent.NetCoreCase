using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Domain.Entities
{
    public enum TaskStatus { InProgress, Done, Postponed, Cancel }
    public class ToDoList
    {
        public string TaskName { get; set; }
        public TaskStatus TaskStatus { get; set; } = TaskStatus.InProgress;
        public DateTime Created { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public string Type => "ToDoList";
    }
}
