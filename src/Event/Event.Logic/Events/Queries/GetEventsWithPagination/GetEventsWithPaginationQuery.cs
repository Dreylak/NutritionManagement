using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Mappings;
using Common.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Events.Queries.GetEventsWithPagination
{
    public record GetEventsWithPaginationQuery(int PageNumber, int PageSize) : IRequest<PaginatedList<EventBriefDto>>;

    public class GetEventsWithPaginationQueryHandler : IRequestHandler<GetEventsWithPaginationQuery, PaginatedList<EventBriefDto>>
    {
        private readonly IEventDbContext _context;
        private readonly IMapper _mapper;

        public GetEventsWithPaginationQueryHandler(IEventDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EventBriefDto>> Handle(GetEventsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events
                .OrderBy(x => x.Created)
                .ProjectTo<EventBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
