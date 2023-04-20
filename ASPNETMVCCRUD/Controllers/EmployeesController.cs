using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly MVCDemoDbContext mvcDemoDbcontext;

        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };
            mvcDemoDbContext.Employees.Add(employee);
            mvcDemoDbContext.SaveChanges();
            return RedirectToAction("Add");
        }
    }
}

