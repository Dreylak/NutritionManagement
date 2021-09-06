using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Events.Commands.UpdateEvent
{
    public record UpdateEventCommand(
        int Id,
        string Title,
        string ShortDescription,
        string FullDescription,
        string Address,
        DateTime StartDate,
        DateTime EndDate,
        int CustomersCapacity) : IRequest;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventDbContext _context;

        public UpdateCustomerCommandHandler(IEventDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventModel), request.Id);
            }

            if (entity.CustomersEnrolled > request.CustomersCapacity)
            {
                // TODO: create bussiness error with enum of error codes, for example 10100 - EventReduceCustomersCapacityError (with full message in description)
                throw new ValidationException($"Cannot reduce event customers capacity to {request.CustomersCapacity} because there are already {entity.CustomersEnrolled} customers enrolled!");
            }

            entity.Title = request.Title;
            entity.ShortDescription = request.ShortDescription;
            entity.FullDescription = request.FullDescription;
            entity.Address = request.Address;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.CustomersCapacity = request.CustomersCapacity;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
