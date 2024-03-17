using MediatR;
using System.Text.Json;
using Task.Application.Common;
using Task.Application.Common.Abstraction;
using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Task.Application.UseCases.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<ResponseViewModel>
    {
        public string? SearchingText { get; set; } = null;
        public string? Pagination { get; set; } = null;
        public int PageSize { get; set; } = 10;
        public Employee? Employee { get; set; } = null;
        public string? NextUrl { get; set; } = null;
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, ResponseViewModel>
    {
        private readonly IApplicationDbContext _context;
        public GetEmployeesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        private T QueryDeserialize<T>(string query)
        {
            return JsonSerializer.Deserialize<T>(query, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ResponseViewModel> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Employee> employeesQuery = _context.Employees;

            if (!string.IsNullOrWhiteSpace(request.SearchingText))
            {
                employeesQuery = employeesQuery.Where(
                    x => x.Surname.Contains(request.SearchingText) ||
                    x.Forename.Contains(request.SearchingText) ||
                    x.Email.Contains(request.SearchingText) ||
                    x.Address.Contains(request.SearchingText) ||
                    x.Address2.Contains(request.SearchingText)
                    );
            }
            List<Employee> Employees = _context.Employees.ToList();
            if (request.SearchingText != null)
            {
                string search = QueryDeserialize<string>(request.SearchingText);
                Employees = Employees.Where(
                    x => x.Surname.Contains(search) ||
                    x.Forename.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.Address.Contains(search) ||
                    x.Address2.Contains(search)
                    ).ToList();
            }
            Pagination<Employee> _pagination = null;

            int pageNumber = 1;
            if (request.Pagination is not null)
            {
                pageNumber = QueryDeserialize<int>(request.Pagination);
            }

            var PaginatedList = await Pagination<Employee>.CreateAsync(Employees, pageNumber, request.PageSize);
            if (PaginatedList.Items.Count == 0)
            {
                PaginatedList = await Pagination<Employee>.CreateAsync(Employees, 1, request.PageSize);
            }

            var responseViewModel = new ResponseViewModel()
            {
                Pagination = PaginatedList,
                EditEmployee = request.Employee,
                nextUrl = request.NextUrl
            };
            return responseViewModel;
        }
    }
}
