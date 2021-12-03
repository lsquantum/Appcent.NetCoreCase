using Appcent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists
{
    public class GetAllToDoListsViewModel
    {
        public string ObjectId { get; set; }
        public string TaskName { get; set; }
        public Status TaskStatus { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
    }
}
