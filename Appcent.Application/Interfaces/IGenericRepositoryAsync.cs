using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(string key);
        Task<IList<T>> GetAllAsync();
        Task<string> AddAsync(string key, T entity);
        Task UpdateAsync(string key, T entity);
        Task DeleteAsync(string key);
    }
}
