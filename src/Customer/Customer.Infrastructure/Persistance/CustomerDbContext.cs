using Common.Infrastructure.Interface;
using Common.Persistance.EFCore;
using Customer.Domain.Models;
using Customer.Logic.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Persistance
{
    public class CustomerDbContext : ApplicationDbContext, ICustomerDbContext
    {
        public CustomerDbContext(
            DbContextOptions<CustomerDbContext> options,
            ICurrentUserService currentUserService,
            IDateTimeService dateTime) : base(options, currentUserService, dateTime)
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
