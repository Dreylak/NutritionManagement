using AutoMapper;
using Common.Exceptions;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Queries.GetCustomerDetailsById
{
    public record GetCustomerDetailsByIdQuery(int Id) : IRequest<CustomerDetailsDto>;

    public class GetCustomerDetailsByIdQueryHandler : IRequestHandler<GetCustomerDetailsByIdQuery, CustomerDetailsDto>
    {
        private readonly ICustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailsByIdQueryHandler(ICustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return _mapper.Map<CustomerDetailsDto>(entity);
        }
    }
}
