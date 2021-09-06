using Common.Exceptions;
using Customer.Domain.Models;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(
        int Id,
        string FirstName,
        string LastName,
        DateTime BirthDate,
        string Gender,
        string Address,
        string PhoneNumber) : IRequest;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerDbContext _context;

        public UpdateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.BirthDate = request.BirthDate;
            entity.Gender = request.Gender;
            entity.Address = request.Address;
            entity.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
