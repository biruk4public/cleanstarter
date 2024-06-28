using Custor.Portal.Application.Contracts.Logging;
using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Application.Exceptions;
using Custor.Portal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppLogger<UpdateCustomerCommandHandler> _logger;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IAppLogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Customer), request.Id);
                throw new BadRequestException("Invalid Customer type", validationResult);
            }

            var customerToUpdate = new Domain.Customer()
            {
                Id = request.Id,
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
            
            await _customerRepository.UpdateAsync(customerToUpdate);

            return Unit.Value;
        }
    }
}
