using MediatR;
using Task.Application.Common.Abstraction;
using Task.Domain.Entity;

namespace Task.Application.UseCases.Employees.Commands
{
    public record DeleteEmpoyeeCommand(Guid employeeId) : IRequest<Employee>;
    public record DeleteEmpoyeeCommandHandler : IRequestHandler<DeleteEmpoyeeCommand, Employee>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmpoyeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(DeleteEmpoyeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _context.Employees.FindAsync(request.employeeId);
            if (employee == null) return null;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
