using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Common.Abstraction;
using Task.Application.UseCases.Employees.Commands;
using Task.Application.UseCases.Employees.Queries;
using Task.Domain.Entity;

namespace Task.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IMediator mediator, IApplicationDbContext context)
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        [HttpGet]
        public async ValueTask<ViewResult> Index(
            string? sorting,
            string? pagination,
            string? searching)
        {
            GetEmployeesQuery query = new GetEmployeesQuery
            {
                Sorting = sorting,
                SearchingText = searching,
                Pagination = pagination
            };
            var employees = await _mediator.Send(query);
            ViewData["Error"] = TempData["Error"] ?? null;
            ViewData["Message"] = TempData["Message"] ?? null;
            return View(employees);
        }

        [HttpPost("/addEmployee")]
        public async ValueTask<ActionResult<List<Employee>>> AddEmployee([FromForm] CreateEmployeeCommand CvsFile)
        {
            if (CvsFile.file.ContentType != "text/csv")
            {
                TempData["Error"] = "invalid file mimetype";
                return RedirectToAction("Index");
            }
            int adddedEmplloyees = await _mediator.Send(CvsFile);
            TempData["Message"] = $"Successfully imported data count: {adddedEmplloyees}";
            return RedirectToAction("Index");
        }

        [HttpGet("/edit/{id:guid}")]
        public async ValueTask<ViewResult> Index(Guid id, string? next)
        {
            GetEmployeeByIdQuery query = new GetEmployeeByIdQuery(id);

            var employee = await _mediator.Send(query);

            GetEmployeesQuery queryEmployees = new GetEmployeesQuery
            {
                Employee = employee,
                NextUrl = next
            };
            var employees = await _mediator.Send(queryEmployees);
            return View(employees);
        }
        [HttpPost("edit/{id:guid}")]
        public async ValueTask<IActionResult> UpdateEmployee(UpdateEmployeeCommand employee, string? next)
        {
            var updatedEmployee = await _mediator.Send(employee);
            var employees = await _mediator.Send(new GetEmployeesQuery());

            TempData["Message"] = "Successfully updated " + $"{employee.Forename} {employee.Surname}";
            return RedirectToAction("Index");
        }


        [HttpGet("delete/{id:guid}")]
        public async ValueTask<IActionResult> DeleteEmployee(Guid id)
        {
            DeleteEmpoyeeCommand deleteEmpoyee = new DeleteEmpoyeeCommand(id);
            var deletedEmployee = await _mediator.Send(deleteEmpoyee);
            if (deletedEmployee == null)
            {
                TempData["Error"] = "User not found";
                return View(
                    "Index");
            }
            TempData["Message"] = "Successfully deleted " + $"{deletedEmployee.Forename}   {deletedEmployee.Surname}";
            return RedirectToAction("Index");
        }

    }
}