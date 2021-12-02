using Appcent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        public GenericRepositoryAsync()
        {

        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return null;
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return null;

        }
        public async Task<T> AddAsync(T entity)
        {
            return null;

        }

        public virtual async Task UpdateAsync(T entity)
        {
            return;
        }
        public virtual async Task DeleteAsync(T entity)
        {
            return;
        }
    }
}
