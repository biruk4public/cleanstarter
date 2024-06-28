using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Domain;
using Custor.Portal.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDatabaseContext context) : base(context)
        {            
        }
    }
}
