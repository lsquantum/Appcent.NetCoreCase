using Appcent.Application.Interfaces;
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
        public virtual async Task<T> GetByIdAsync(string key)
        {
            var collection = await _bucket.DefaultCollectionAsync();
            var result = await collection.GetAsync(key);
            return result.ContentAs<T>();
        }
        public async Task<IList<T>> GetAllAsync()
        {
            var queryResult = await _bucket.Cluster.QueryAsync<T>($"SELECT t.* FROM `default` t WHERE t.type='{nameof(T)}'");
            IAsyncEnumerable<T> rows = queryResult.Rows;
            List<T> data = new();
            await foreach (var row in rows) {
                data.Add(row);
            }
            return data;
        }
        public async Task<string> AddAsync(T entity)
        {
            var key = Guid.NewGuid().ToString();
            var collection = await _bucket.DefaultCollectionAsync();
            await collection.InsertAsync<T>(key, entity);
            return key;
        }
        public virtual async Task UpdateAsync(string key, T entity)
        {
            var collection = await _bucket.DefaultCollectionAsync();
            await collection.ReplaceAsync<T>(key, entity);
        }
        public virtual async Task DeleteAsync(string key)
        {
            var collection = await _bucket.DefaultCollectionAsync();
            await collection.RemoveAsync(key);
        }
    }
}
