using Custor.Portal.Application.Features.Customer.Commands.CreateCustomer;
using Custor.Portal.Application.Features.Customer.Commands.DeleteCustomer;
using Custor.Portal.Application.Features.Customer.Commands.UpdateCustomer;
using Custor.Portal.Application.Features.Customer.Queries.GetAllCustomers;
using Custor.Portal.Application.Features.Customer.Queries.GetCustomerDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Custor.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<CustomerDto>> Get()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());
            return customers;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailsDto>> Get(int id)
        {
            var customer = await _mediator.Send(new GetCustomerDetailsQuery(id));
            return Ok(customer);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCustomerCommand customer)
        {
            var response = await _mediator.Send(customer);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCustomerCommand customer)
        {
            await _mediator.Send(customer);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
