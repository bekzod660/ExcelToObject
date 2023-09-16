using MediatR;
using Task.Application.Common.Abstraction;

namespace Task.Application.UseCases.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Payroll { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Employee employee = request.CustomMapper();

            //_context.Employees.Update(employee);
            //int result = await _context.SaveChangesAsync();
            //if (result > 0) return true;
            //else return false;

            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null) return false;

            employee.Id = request.Id;
            employee.Forename = request.Forename;
            employee.Surname = request.Surname;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Telephone = request.Telephone;
            employee.Mobile = request.Mobile;
            employee.Address = request.Address;
            employee.Address2 = request.Address2;
            employee.PostCode = request.PostCode;
            employee.Email = request.Email;
            employee.StartDate = request.StartDate;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
