using Appcent.Domain.Entities;
using Appcent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using Couchbase;

namespace Appcent.Infrastructure.Repositories
{
    public class ToDoListRepositoryAsync : GenericRepositoryAsync<ToDoList>, IToDoListRepositoryAsync
    {
        private readonly IBucket _bucket;
        public ToDoListRepositoryAsync(INamedBucketProvider bucketProvider) : base(bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync().GetAwaiter().GetResult();
        }

        public async Task<IList<ToDoList>> GetAllByUserIdAsync(string id)
        {
            var queryResult = await _bucket.Cluster.QueryAsync<ToDoList>($"SELECT t.* FROM `default` t WHERE t.type='{typeof(ToDoList).Name}' AND t.userId='{id}'");
            IAsyncEnumerable<ToDoList> rows = queryResult.Rows;
            List<ToDoList> data = new();
            await foreach (var row in rows)
            {
                data.Add(row);
            }
            return data;
        }
    }
}
