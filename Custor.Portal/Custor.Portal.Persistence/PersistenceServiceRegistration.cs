using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Persistence.DatabaseContext;
using Custor.Portal.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<CustomerDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("CustomerDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
