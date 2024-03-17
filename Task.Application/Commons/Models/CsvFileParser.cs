using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Task.Application.Commons.Models;
using Task.Domain.Entity;

namespace Task.Application.Common.Models;

public class CsvFileParser : ICsvFileParser
{
    public List<Employee> Parse<T>(IFormFile file)
    {
        using (var stream = file.OpenReadStream())
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.Context.RegisterClassMap<EmployeeMap>();
            var records = csv.GetRecords<Employee>().ToList();
            return records;
        }
    }
}

