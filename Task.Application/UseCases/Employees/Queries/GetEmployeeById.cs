using MediatR;
using Task.Application.Common.Abstraction;
using Task.Domain.Entity;

namespace Task.Application.UseCases.Employees.Queries
{
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee>;
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IApplicationDbContext _context;
        public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == request.Id);
            return employee;
        }
    }
}
