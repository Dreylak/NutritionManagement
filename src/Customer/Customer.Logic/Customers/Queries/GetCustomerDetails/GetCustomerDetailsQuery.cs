using AutoMapper;
using Common.Exceptions;
using Customer.Domain.Models;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Queries.GetCustomerDetails
{
    public record GetCustomerDetailsQuery(int Id) : IRequest<CustomerDetailsDto>;

    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
    {
        private readonly ICustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailsQueryHandler(ICustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.Id);
            }

            return _mapper.Map<CustomerDetailsDto>(entity);
        }
    }
}
