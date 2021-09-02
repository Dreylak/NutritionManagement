using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Mappings;
using Common.Models;
using Customer.Logic.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Logic.Customers.Queries.GetCustomersWithPagination
{
    public record GetCustomersWithPaginationQuery(int PageNumber, int PageSize) : IRequest<PaginatedList<CustomerBriefDto>>;

    public class GetCustomersWithPaginationQueryHandler : IRequestHandler<GetCustomersWithPaginationQuery, PaginatedList<CustomerBriefDto>>
    {
        private readonly ICustomerDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersWithPaginationQueryHandler(ICustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerBriefDto>> Handle(GetCustomersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .OrderBy(x => x.Created)
                .ProjectTo<CustomerBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
