using Microsoft.AspNetCore.Http;
using Task.Domain.Entity;

namespace Task.Application.Common.Models;
public interface ICsvFileParser
{
    public List<Employee> Parse<T>(IFormFile fileProvider);
}