using Custor.Portal.Application.Contracts.Logging;
using Custor.Portal.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppLogger<GetCustomersQueryHandler> _logger;

        public GetCustomersQueryHandler(IAppLogger<GetCustomersQueryHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAsync();
            var customersToreturn = new List<CustomerDto>();
            foreach (var item in customers)
            {
                var customerModel = new CustomerDto();
                customerModel.Id = item.Id;
                customerModel.CompanyName = item.CompanyName;
                customerModel.CompanyNameLocal = item.CompanyNameLocal;
                customerModel.CompanyNameAmharic = item.CompanyNameAmharic;
                customerModel.EnterpriseType = item.EnterpriseType;
                customerModel.TradeName = item.TradeName;
                customerModel.TradeNameLocal = item.TradeNameLocal;
                customerModel.TradeNameAmharic = item.TradeNameAmharic;
                customerModel.StartDate = item.StartDate;
                customerModel.PreferredLanguage = item.PreferredLanguage;
                customersToreturn.Add(customerModel);
            }
           
            _logger.LogInformation("Customers were retrieved successfully");

            return customersToreturn;
        }
    }
}
