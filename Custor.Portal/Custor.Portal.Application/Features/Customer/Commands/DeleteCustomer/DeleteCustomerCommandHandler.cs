using Custor.Portal.Application.Contracts.Persistence;
using Custor.Portal.Application.Exceptions;
using Custor.Portal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            // remove from database
            await _customerRepository.DeleteAsync(customerToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}
