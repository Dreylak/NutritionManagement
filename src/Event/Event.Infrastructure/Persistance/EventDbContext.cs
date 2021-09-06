using Common.Infrastructure.Interface;
using Common.Persistance.EFCore;
using Event.Domain.Models;
using Event.Logic.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure.Persistance
{
    public class EventDbContext : ApplicationDbContext, IEventDbContext
    {
        public EventDbContext(
            DbContextOptions options, 
            ICurrentUserService currentUserService, 
            IDateTimeService dateTime) : base(options, currentUserService, dateTime)
        {
        }

        public DbSet<EventModel> Events { get; set; }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
