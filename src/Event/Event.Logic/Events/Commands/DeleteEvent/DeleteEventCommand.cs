using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Events.Commands.DeleteEvent
{
    public record DeleteEventCommand(int Id) : IRequest;

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventDbContext _context;

        public DeleteEventCommandHandler(IEventDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventModel), request.Id);
            }

            _context.Events.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
