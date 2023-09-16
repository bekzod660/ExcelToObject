using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Task.Application.Common
{
    public class ResponseViewModel
    {
        public Exception? Error { get; set; }
        public Employee? Employee { get; set; }
        public List<string> Columns { get; set; }
        public string? Searching { get; set; }
        public Pagination<Employee>? Pagination { get; set; }
        public Sorting<Employee>? Sorting { get; set; }
        public ResponseViewModel(Type type)
        {
            this.Columns = type.GetProperties().Select(info => info.Name).ToList();
        }
        public string? nextUrl { get; set; }
    }
}
