using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_TravelProject.Models;
using MVC_TravelProject.Repository;

namespace MVC_TravelProject.Controllers
{
    public class TravelController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITravelRepository _travelRepository;
        public TravelController(IEmployeeRepository employeeRepository, ITravelRepository travelRepository)
        {
            _employeeRepository = employeeRepository;
            _travelRepository = travelRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<TravelRequest> req = _travelRepository.GetRequests();
            return View(req);
        }
        public IActionResult RaiseRequest()
        {
            var employees = _employeeRepository.GetEmployees()
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FullName = $"{e.FirstName} {e.LastName}"
                });

            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");
            return View();
        }


        [HttpPost]

        public IActionResult RaiseRequest(TravelRequest req)
        {
            if (ModelState.IsValid)
            {
                _travelRepository.RaiseRequest(req);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRequest(int id)
        {
            _travelRepository.DeleteRequest(id);
            return RedirectToAction("Index");
        }


		public IActionResult UpdateRequest(int id)
		{
			TravelRequest? travelRequest = _travelRepository.GetRequestById(id);
            var employees = _employeeRepository.GetEmployees()
                   .Select(e => new
                   {
                       EmployeeId = e.EmployeeId,
                       FullName = $"{e.FirstName} {e.LastName}"
                   });

            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");
            if (travelRequest != null)
			{
				return View(travelRequest);
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult UpdateRequest(TravelRequest travelRequest, int id)
		{
			if (ModelState.IsValid)
			{

			_travelRepository.UpdateRequest(travelRequest, id);

			}
			return RedirectToAction("Index");
		}
		public IActionResult ApproveTravelRequest(int id)
		{
			TravelRequest tr = _travelRepository.GetRequestById(id);
			return View(tr);
		}

		[HttpPost]
		public IActionResult ApproveTravelRequest(int id, string ApproveStatus)
		{
			if (ModelState.IsValid)
			{
				_travelRepository.ApproveTravelRequest(id, ApproveStatus);
			}
			return RedirectToAction("Index");
		}

		public IActionResult BookTravelRequest(int id)
		{
			TravelRequest tr = _travelRepository.GetRequestById(id);
			return View(tr);
		}

		[HttpPost]
		public IActionResult BookTravelRequest(int id, string BookingStatus)
		{
			if (ModelState.IsValid)
			{
				_travelRepository.BookTravelRequest(id, BookingStatus);
			}
			return RedirectToAction("Index");
		}

	}
}
