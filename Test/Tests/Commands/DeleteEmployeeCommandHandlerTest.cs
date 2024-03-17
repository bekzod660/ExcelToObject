using Employees.Tests.Common;
using Task.Application.UseCases.Employees.Commands;

namespace Employees.Tests.Tests.Commands
{
    public class DeleteEmployeeCommandHandlerTest : BaseTest //IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async System.Threading.Tasks.Task EmployeeDeleteCommandHandler_Success()
        {
            var handler = new DeleteEmpoyeeCommandHandler(context);

            //Act
            Guid id = Guid.Parse("a20a610a-37c1-4a73-833f-08dbae86f565");
            var result = await handler.Handle(new DeleteEmpoyeeCommand(id), CancellationToken.None);
            //Assert
            Assert.NotNull(result);
        }
    }
}
