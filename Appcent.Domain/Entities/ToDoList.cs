using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Domain.Entities
{
    public class ToDoList
    {
        public string TaskName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type => "ToDoList";
    }
}
