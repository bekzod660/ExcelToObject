using MediatR;
using System.Text.Json;
using Task.Application.Common;
using Task.Application.Common.Abstraction;
using Task.Application.Common.Extensions;
using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Task.Application.UseCases.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<ResponseViewModel>
    {
        public string? Sorting { get; set; } = null;
        public string SearchingText { get; set; } = null;
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
            Sorting<Employee> _sorting = default;
            if (request.Sorting != null)
                _sorting = QueryDeserialize<Sorting<Employee>>(request.Sorting);
            else
            {
                _sorting = new Sorting<Employee>();
                _sorting.Toggle(employee => employee.Forename);
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

            if (request.Sorting != null)
            {
                Employees = Employees.ApplySorting(_sorting);
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

            var responseViewModel = new ResponseViewModel(typeof(Employee))
            {
                Pagination = PaginatedList,
                Sorting = _sorting,
                Employee = request.Employee,
                nextUrl = request.NextUrl
            };
            return responseViewModel;
        }
    }
}
