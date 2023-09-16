using Task.Application.UseCases.Employees.Commands;
using Task.Domain.Entity;

namespace Task.Application.Common.Extensions
{
    public static class Mapper
    {
        public static Employee CustomMapper(this UpdateEmployeeCommand employee)
        {
            return new Employee
            {
                Id = employee.Id,
                Payroll = employee.Payroll,
                Forename = employee.Forename,
                Surname = employee.Surname,
                DateOfBirth = employee.DateOfBirth,
                Telephone = employee.Telephone,
                Mobile = employee.Mobile,
                StartDate = employee.StartDate,
                PostCode = employee.PostCode,
                Address = employee.Address,
                Address2 = employee.Address2,
                Email = employee.Email,
            };
        }
    }
}
