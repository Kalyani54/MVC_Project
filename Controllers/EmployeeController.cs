using Microsoft.AspNetCore.Mvc;
using MVC_TravelProject.Models;
using MVC_TravelProject.Repository;

namespace MVC_TravelProject.Controllers
{
	public class EmployeeController : Controller
	{
		private IEmployeeRepository Ier;

		public EmployeeController(IEmployeeRepository er)
		{
			Ier = er;
		}
		public IActionResult Index()
		{
			IEnumerable<Employee> emp = Ier.GetEmployees();
			return View(emp);
		}
        //Add Employee
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Ier.AddEmployee(emp);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int EmployeeId)
        {

            Ier.DeleteEmployee(EmployeeId);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(int EmployeeId)
        {
            Employee emp = Ier.GetEmployeeById(EmployeeId);
            return View(emp);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee emp, int EmployeeId)
        {
            if (ModelState.IsValid)
            {
                Ier.UpdateEmployee(emp, EmployeeId);
            }
            return RedirectToAction("Index");
        }
    }
}
