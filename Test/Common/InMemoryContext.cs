
using MarketManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Task.Domain.Entity;

namespace Employees.Tests.Common
{
    public static class InMemoryContext
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            context.Employees.AddRange(new List<Employee>
            {
                 new Employee
            {
                Id = Guid.Parse("d50f9ea1-ed25-476a-833d-08dbae86f565"),
                Payroll = "P003AT",
                Forename = "John",
                Surname = "Doe",
                DateOfBirth = "01/01/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                PostCode = "12345",
                Email = "john.doe@example.com",
                StartDate = "05/01/2022"
            },
                  new Employee
            {
                Id = Guid.Parse("10b6debf-6cd3-43ed-833e-08dbae86f565"),
                Payroll = "P003AZ",
                Forename = "Alex",
                Surname = "Doe",
                DateOfBirth = "01/10/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                PostCode = "12345",
                Email = "alex.doe@example.com",
                StartDate = "05/01/2022"
            },
                   new Employee
            {
                Id = Guid.Parse("a20a610a-37c1-4a73-833f-08dbae86f565"),
                Payroll = "P003AC",
                Forename = "Tom",
                Surname = "Wilson",
                DateOfBirth = "14/01/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                PostCode = "12345",
                Email = "tom.doe@example.com",
                StartDate = "08/10/2022"
            }
            });

            return context;
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
