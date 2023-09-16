using Employees.Tests.Common;
using Microsoft.AspNetCore.Http;
using Task.Application.Common.Models;
using Task.Application.UseCases.Employees.Commands;
using Task.Domain.Entity;

namespace Employees.Tests.Tests.Commands
{
    public class CreateEmployeeHandlerTest : BaseTest
    {
        private readonly string path = @"..\..\..\File\dataset.csv";
        private readonly ICsvFileParser _parser;
        private IFormFile _file;
        public CreateEmployeeHandlerTest()
        {
            _parser = new CsvFileParser();

        }

        [Fact]
        public async System.Threading.Tasks.Task GetEmployeesTest_Return_Int_AddedEmplyees_Count()
        {
            // Arrange
            int addedEmployees = 0;
            List<Employee> employees;
            var handler = new CreateEmployeeCommandHandler(context, _parser);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                _file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                };
                employees = _parser.Parse<Employee>(_file);

                addedEmployees = await handler.Handle(new CreateEmployeeCommand
                {
                    file = _file
                }, CancellationToken.None);
            }

            // Act

            Assert.Equal(employees.Count, addedEmployees);
        }
    }

}
