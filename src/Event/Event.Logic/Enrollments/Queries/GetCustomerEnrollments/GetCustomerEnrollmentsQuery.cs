using AutoMapper;
using Common.Exceptions;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Logic.Enrollments.Queries.GetCustomerEnrollments
{
    public record GetCustomerEnrollmentsQuery(int CustomerId) : IRequest<List<CustomerEnrollmentDto>>;

    public class GetEventDetailsQueryHandler : IRequestHandler<GetCustomerEnrollmentsQuery, List<CustomerEnrollmentDto>>
    {
        private readonly IEventDbContext _context;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IEventDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerEnrollmentDto>> Handle(GetCustomerEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .Include(c => c.Events)
                .FirstOrDefaultAsync(c => c.Id == request.CustomerId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.CustomerId);
            }

            return _mapper.Map<List<CustomerEnrollmentDto>>(entity.Events);
        }
    }
}
