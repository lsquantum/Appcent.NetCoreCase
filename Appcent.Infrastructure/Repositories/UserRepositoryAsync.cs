﻿using Appcent.Domain.Entities;
using Appcent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;

namespace Appcent.Infrastructure.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(INamedBucketProvider bucketProvider) : base(bucketProvider)
        {
        }
        public Task<bool> IsUniqueEmailAsync(string email)
        {
            return null;
        }
    }
}
