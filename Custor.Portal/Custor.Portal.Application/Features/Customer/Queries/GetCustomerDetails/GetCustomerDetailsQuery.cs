using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Queries.GetCustomerDetails
{
    public record GetCustomerDetailsQuery(int Id) : IRequest<CustomerDetailsDto>;    
}
