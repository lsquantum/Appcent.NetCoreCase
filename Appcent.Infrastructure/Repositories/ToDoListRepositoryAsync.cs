using Appcent.Domain.Entities;
using Appcent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;

namespace Appcent.Infrastructure.Repositories
{
    public class ToDoListRepositoryAsync : GenericRepositoryAsync<ToDoList>, IToDoListRepositoryAsync
    {
        public ToDoListRepositoryAsync(INamedBucketProvider bucketProvider) : base(bucketProvider)
        {
        }
    }
}
