using Custor.Portal.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
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

            _customerRepository = customerRepository;
        }
    }
}
