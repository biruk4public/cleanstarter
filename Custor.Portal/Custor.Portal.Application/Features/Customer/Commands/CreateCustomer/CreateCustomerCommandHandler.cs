using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Customer information", validationResult);

            var customerToCreate = new Domain.Customer()
            {
                CompanyName = request.CompanyName,
                CompanyNameLocal = request.CompanyNameLocal,
                CompanyNameAmharic = request.CompanyNameAmharic,
                EnterpriseType = request.EnterpriseType,
                TradeName = request.TradeName,
                TradeNameLocal = request.TradeNameLocal,
                TradeNameAmharic = request.TradeNameAmharic,
                StartDate = request.StartDate,
                PreferredLanguage = request.PreferredLanguage,
            };

            await _customerRepository.CreateAsync(customerToCreate);

            return customerToCreate.Id;
        }
    }
}
