using Common;
using Common.Models;
using Customer.Logic.Customers.Commands.CreateCustomer;
using Customer.Logic.Customers.Commands.DeleteCustomer;
using Customer.Logic.Customers.Commands.UpdateCustomer;
using Customer.Logic.Customers.Queries.GetCustomersWithPagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CustomerBriefDto>>> GetCustomersWithPagination([FromQuery] GetCustomersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCustomerCommand(id));

            return NoContent();
        }
    }
}
