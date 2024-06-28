using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Queries.GetAllCustomers
{
    public record GetCustomersQuery : IRequest<List<CustomerDto>>;
}
