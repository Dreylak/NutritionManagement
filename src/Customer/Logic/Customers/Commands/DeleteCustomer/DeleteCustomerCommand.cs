using Common.Exceptions;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(int Id) : IRequest;

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerDbContext _context;

        public DeleteCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
