using Custor.Portal.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(CustomerMustExist);

            RuleFor(p => p.CompanyName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.CompanyNameLocal)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

            RuleFor(p => p.CompanyNameAmharic)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters");

        }
        private async Task<bool> CustomerMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _customerRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
