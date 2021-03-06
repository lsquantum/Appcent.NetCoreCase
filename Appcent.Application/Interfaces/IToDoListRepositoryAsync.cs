using Appcent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Application.Interfaces
{
    public interface IToDoListRepositoryAsync : IGenericRepositoryAsync<ToDoList>
    {
        Task<IList<ToDoList>> GetAllByUserIdAsync(string id);
    }
}
