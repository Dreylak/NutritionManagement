using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Events.Commands.CreateEvent
{
    public record CreateEventCommand(
        string Title,
        string ShortDescription,
        string FullDescription,
        string Address,
        DateTime StartDate,
        DateTime EndDate,
        int CustomersCapacity) : IRequest<int>;

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventDbContext _context;

        public CreateEventCommandHandler(IEventDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new EventModel
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                FullDescription = request.FullDescription,
                Address = request.Address,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CustomersCapacity = request.CustomersCapacity
            };

            _context.Events.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
