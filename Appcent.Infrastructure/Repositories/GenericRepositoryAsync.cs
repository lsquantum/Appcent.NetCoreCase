﻿using Appcent.Application.Interfaces;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly IBucket _bucket;
        public GenericRepositoryAsync(INamedBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync().GetAwaiter().GetResult();
        }
        public virtual async Task<T> GetByIdAsync(string id)
        {
            return null;
        }
        public async Task<IList<T>> GetAllAsync(string type)
        {
            return null;

        }
        public async Task<T> AddAsync(T entity)
        {
            var key = Guid.NewGuid().ToString();
            var collection = await _bucket.DefaultCollectionAsync();
            await collection.InsertAsync<T>(key, entity);
            return entity;
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
