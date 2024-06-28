using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Application.Exceptions;
using Custor.Portal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerDetailsQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            var customerToReturn = new CustomerDetailsDto()
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                CompanyNameLocal = customer.CompanyNameLocal,
                CompanyNameAmharic = customer.CompanyNameAmharic,
                EnterpriseType = customer.EnterpriseType,
                TradeName = customer.TradeName,
                TradeNameLocal = customer.TradeNameLocal,
                TradeNameAmharic = customer.TradeNameAmharic,
                StartDate = customer.StartDate,
                PreferredLanguage = customer.PreferredLanguage
            };

            return customerToReturn;
        }
    }
}
