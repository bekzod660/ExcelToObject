using Microsoft.AspNetCore.Http;
using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Employees.Tests.Tests.Commands
{
    public class FileParseHandlerTests
    {
        private readonly string filePath = @"..\..\..\File\dataset2.csv";
        private IFormFile _file;
        private ICsvFileParser _parser;

        public FileParseHandlerTests()
        {
            _parser = new CsvFileParser();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            _file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary()
            };
        }

        [Fact]
        public async System.Threading.Tasks.Task Parse_Should_Parse_Stream_Into_List_Of_Entities()
        {
            List<Employee> employees = _parser.Parse<Employee>(_file);

            // Assert
            Assert.NotNull(employees);
            Assert.NotEmpty(employees);
        }

    }
}
