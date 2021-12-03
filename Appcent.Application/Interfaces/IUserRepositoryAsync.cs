using Appcent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Application.Interfaces
{
    public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
        Task<bool> IsUniqueEmailAsync(string email);
        Task<User> GetUserAsync(string email, string password);
    }
}
