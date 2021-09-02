using Common.Persistance.Interfaces;
using Customer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Logic.Common.Interfaces
{
    public interface ICustomerDbContext : IApplicationDbContext
    {
        DbSet<CustomerModel> Customers { get; set; }
    }
}
