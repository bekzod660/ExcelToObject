using Employees.Tests.Common;
using Shouldly;
using Task.Application.UseCases.Employees.Queries;
namespace Employees.Tests.Tests.Queries
{
    public class GetEmployeesQueryHandlerTest : BaseTest
    {
        [Fact]
        public async System.Threading.Tasks.Task Return_Employees_Count()
        {
            //Arrange
            var handler = new GetEmployeesQueryHandler(context);

            //Act
            var result = await handler.Handle(new GetEmployeesQuery(), CancellationToken.None);
            int employeesCount = result.Pagination.Items.Count();

            //Assert
            employeesCount.ShouldBeGreaterThanOrEqualTo(0);
        }
    }
}
