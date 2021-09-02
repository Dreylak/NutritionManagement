using Customer.Domain.Models;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
        string FirstName, 
        string LastName,
        DateTime BirthDate,
        string Gender,
        string Address,
        string PhoneNumber) : IRequest<int>;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerDbContext _context;

        public CreateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new CustomerModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
