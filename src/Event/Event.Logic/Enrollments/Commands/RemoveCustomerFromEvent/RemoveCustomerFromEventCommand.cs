using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Enrollments.Commands.RemoveCustomerFromEvent
{
    public record RemoveCustomerFromEventCommand(int CustomerId, int EventId) : IRequest;

    public class RemoveCustomerFromEventCommandHandler : IRequestHandler<RemoveCustomerFromEventCommand>
    {
        private readonly IEventDbContext _context;

        public RemoveCustomerFromEventCommandHandler(IEventDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveCustomerFromEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Events
                .Include(e => e.Customers)
                .FirstOrDefaultAsync(e => e.Id == request.EventId);

            if (eventEntity == null)
            {
                throw new NotFoundException(nameof(EventModel), request.EventId);
            }

            var customerEntity = await _context.Customers.FirstOrDefaultAsync(e => e.Id == request.CustomerId);

            if (customerEntity == null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.CustomerId);
            }

            if (!eventEntity.Customers.Remove(customerEntity))
            {
                //TODO replace with bussiness exception
                throw new ValidationException("Customer doesn't enrolled to the event!");
            }

            eventEntity.CustomersEnrolled--;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
