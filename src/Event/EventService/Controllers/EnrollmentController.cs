using Common;
using Event.Logic.Enrollments.Commands.EnrollCustomerForEvent;
using Event.Logic.Enrollments.Commands.RemoveCustomerFromEvent;
using Event.Logic.Enrollments.Queries.GetCustomerEnrollments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventService.Controllers
{
    public class EnrollmentController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CustomerEnrollmentDto>>> GetCustomerEnrollments([FromQuery] GetCustomerEnrollmentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> EnrollCustomerForEvent(EnrollCustomerForEventCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveCustomerFromEvent(RemoveCustomerFromEventCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
