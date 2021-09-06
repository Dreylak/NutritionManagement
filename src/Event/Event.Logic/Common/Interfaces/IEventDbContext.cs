using Common.Persistance.Interfaces;
using Event.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Event.Logic.Common.Interfaces
{
    public interface IEventDbContext : IApplicationDbContext
    {
        DbSet<EventModel> Events { get; set; }

        DbSet<CustomerModel> Customers { get; set; }
    }
}
