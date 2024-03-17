using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Task.Application.Common
{
    public class ResponseViewModel
    {
        public Exception? Error { get; set; }
        public Employee? EditEmployee { get; set; }
        public string? Searching { get; set; }
        public Pagination<Employee>? Pagination { get; set; }
        public string? nextUrl { get; set; }
    }
}
