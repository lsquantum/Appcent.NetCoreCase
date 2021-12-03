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
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly IBucket _bucket;
        public UserRepositoryAsync(INamedBucketProvider bucketProvider) : base(bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync().GetAwaiter().GetResult();
        }
        public async Task<bool> IsUniqueEmailAsync(string email)
        {
            var queryResult = await _bucket.Cluster.QueryAsync<User>($"SELECT t.* FROM `default` t WHERE t.type='User' AND t.email='{email}'");
            IAsyncEnumerable<User> rows = queryResult.Rows;
            List<User> data = new();
            await foreach (var row in rows)
            {
                data.Add(row);
            }
            if (data.Count > 0)
                return false;
            else
                return true;
        }
    }
}
