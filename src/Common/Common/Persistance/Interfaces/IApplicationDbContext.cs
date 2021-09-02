using System.Threading;
using System.Threading.Tasks;

namespace Common.Persistance.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
