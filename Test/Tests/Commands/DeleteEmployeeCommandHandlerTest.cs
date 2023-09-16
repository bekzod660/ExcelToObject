using Employees.Tests.Common;
using Task.Application.UseCases.Employees.Commands;

namespace Employees.Tests.Tests.Commands
{
    public class DeleteEmployeeCommandHandlerTest : BaseTest //IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async System.Threading.Tasks.Task EmployeeDeleteCommandHandler_Success()
        {
            //Arrange
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //   .UseSqlServer("workstation id=Task1111.mssql.somee.com;packet size=4096;user id=bek66001_SQLLogin_1;pwd=niq4t4wtpl;data source=Task1111.mssql.somee.com;TrustServerCertificate=True; persist security info=False;initial catalog=Task1111;")
            //   .Options;
            //ApplicationDbContext db = new ApplicationDbContext(options);
            var handler = new DeleteEmpoyeeCommandHandler(context);

            //Act
            Guid id = Guid.Parse("a20a610a-37c1-4a73-833f-08dbae86f565");
            var result = await handler.Handle(new DeleteEmpoyeeCommand(id), CancellationToken.None);
            //Assert
            Assert.NotNull(result);
        }


        //        [Fact]
        //public async Task EmployeeDeleteCommandHandler_FailOnWrongPayyroll()
        //{
        //    //Arrange
        //    var handler = new EmployeeDeleteCommandHandler(context);


        //    //Act
        //    bool result = await handler.Handle(new EmployeeDeleteCommand
        //    {
        //        PayyrollNumber = Guid.NewGuid().ToString()
        //    }, CancellationToken.None);


        //    //Assert
        //    Assert.False(result);
        //}
    }
}
