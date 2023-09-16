using MediatR;
using Microsoft.AspNetCore.Http;
using Task.Application.Common.Abstraction;
using Task.Application.Common.Models;
using Task.Domain.Entity;

namespace Task.Application.UseCases.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public IFormFile file { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly ICsvFileParser _parser;
        public CreateEmployeeCommandHandler(IApplicationDbContext context, ICsvFileParser parser)
        {
            _context = context;
            _parser = parser;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (_parser == null)
            {
                // Handle the case where _parser is null
                throw new InvalidOperationException("_parser is not initialized.");
            }

            if (request.file == null)
            {
                // Handle the case where request.file is null
                throw new ArgumentNullException(nameof(request.file), "The file is null.");
            }

            if (_context == null)
            {
                // Handle the case where _context is null
                throw new InvalidOperationException("_context is not initialized.");
            }
            List<Employee> Employees = _parser.Parse<Employee>(request.file);
            foreach (var employee in Employees)
            {
                employee.Id = Guid.NewGuid();
            }
            int addedEmployeeCount = 0;
            foreach (var item in Employees)
            {
                _context.Employees.Add(item);
                addedEmployeeCount++;
            }
            await _context.SaveChangesAsync();
            return addedEmployeeCount;
        }
    }

}
