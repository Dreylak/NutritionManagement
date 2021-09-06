using AutoMapper;
using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Events.Queries.GetEventDetails
{
    public record GetEventDetailsQuery(int Id) : IRequest<EventDetailsDto>;

    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsDto>
    {
        private readonly IEventDbContext _context;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IEventDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventDetailsDto> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EventModel), request.Id);
            }

            return _mapper.Map<EventDetailsDto>(entity);
        }
    }
}
