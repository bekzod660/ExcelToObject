
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Abstraction;
using Task.Domain.Entity;

namespace MarketManager.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

}
