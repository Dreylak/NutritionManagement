using Common;
using Common.Models;
using Event.Logic.Events.Commands.CreateEvent;
using Event.Logic.Events.Commands.DeleteEvent;
using Event.Logic.Events.Commands.UpdateEvent;
using Event.Logic.Events.Queries.GetEventDetails;
using Event.Logic.Events.Queries.GetEventsWithPagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventService.Controllers
{
    public class EventController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<EventBriefDto>>> GetEventsWithPagination([FromQuery] GetEventsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsDto>> GetEventDetails(int id)
        {
            return await Mediator.Send(new GetEventDetailsQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEventCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEventCommand command)
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
            await Mediator.Send(new DeleteEventCommand(id));

            return NoContent();
        }
    }
}
