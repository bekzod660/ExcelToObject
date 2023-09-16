using Microsoft.EntityFrameworkCore;
using Task.Domain.Entity;

namespace Task.Application.Common.Abstraction
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
