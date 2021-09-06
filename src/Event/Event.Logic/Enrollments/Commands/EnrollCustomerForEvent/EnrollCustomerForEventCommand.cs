using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Enrollments.Commands.EnrollCustomerForEvent
{
    public record EnrollCustomerForEventCommand(int CustomerId, int EventId) : IRequest;

    public class EnrollCustomerForEventCommandHandler : IRequestHandler<EnrollCustomerForEventCommand>
    {
        private readonly IEventDbContext _context;

        public EnrollCustomerForEventCommandHandler(IEventDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EnrollCustomerForEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Events
                .Include(e => e.Customers)
                .FirstOrDefaultAsync(e => e.Id == request.EventId);

            if (eventEntity == null)
            {
                throw new NotFoundException(nameof(EventModel), request.EventId);
            }

            var customerEntity = await _context.Customers.FindAsync(request.CustomerId);

            if (customerEntity == null)
            {
                customerEntity = new CustomerModel()
                {
                    Id = request.CustomerId
                };

                _context.Customers.Add(customerEntity);
            }

            if(eventEntity.Customers.Contains(customerEntity))
            {
                //TODO replace with bussiness exception
                throw new ValidationException("Customer already enrolled!");
            }

            eventEntity.Customers.Add(customerEntity);
            eventEntity.CustomersEnrolled++;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
