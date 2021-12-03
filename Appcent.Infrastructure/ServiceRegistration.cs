using Appcent.Application.Interfaces;
using Appcent.Infrastructure.Repositories;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            //Add Couchbase
            services.AddCouchbase(_config.GetSection("Couchbase"));
            services.AddCouchbaseBucket<INamedBucketProvider>("default");

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IToDoListRepositoryAsync, ToDoListRepositoryAsync>();
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();

            #endregion
        }
    }
}
