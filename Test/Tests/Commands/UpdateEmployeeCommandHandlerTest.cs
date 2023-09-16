using Employees.Tests.Common;
using Task.Application.UseCases.Employees.Commands;

namespace Employees.Tests.Tests.Commands
{
    public class UpdateEmployeeCommandHandlerTest : BaseTest
    {
        [Fact]
        public async System.Threading.Tasks.Task UpdateEmployeeCommandHandlerTest_Success()
        {
            //Arrange
            var handler = new UpdateEmployeeCommandHandler(context);
            //Act
            bool employee = await handler.Handle(new UpdateEmployeeCommand
            {
                Id = Guid.Parse("10b6debf-6cd3-43ed-833e-08dbae86f565"),
                Payroll = "ss",
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
            }, CancellationToken.None);

            //Assert
            Assert.True(employee);
        }

        //[Fact]
        //public async Task EmployeeUpdateCommandHandler_FailOnWrongPayyroll()
        //{
        //    //Arrange
        //    var handler = new EmployeeUpdateCommandHandler(context);

        //    //Act
        //    bool result=await handler.Handle(new EmployeeUpdateCommand
        //    {
        //        PayyrollNumber = Guid.NewGuid().ToString()
        //    }, CancellationToken.None);


        //    //Assert
        //    Assert.False(result);

        //}
    }
}
