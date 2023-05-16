using HelloMvc.Models;
using HelloMvc.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class VacationsController : Controller {
        private readonly IEmployeeRepo _employeeRepo;

        //public static EmployeeMockRepo _employeeRepo = new EmployeeMockRepo();
        public VacationsController(IEmployeeRepo employeeRepo) {
            _employeeRepo = employeeRepo;
        }
        public IActionResult Index(int employeeId) {
            if (employeeId == 0) {
                return RedirectToAction("Index", "Employees");
            }


            //var vacations = _employeeRepo.EmployeeVacationsRetrieve(employeeId);
            var vm = _employeeRepo.GetById(employeeId);
            return View(vm);
        }

        public IActionResult Create(int employeeId) {
            var vm = new VacationRequest() { EmployeeId = employeeId, 
                StartDate = DateTime.Today.AddMonths(1),
                EndDate = DateTime.Today.AddMonths(1).AddDays(2),

            };
            return View(vm);

        }

        [HttpPost]
        public IActionResult Create(VacationRequest model)
        {
            _employeeRepo.VacationsRequestCreate(model);
            return RedirectToAction("Index", new {employeeId = model.EmployeeId});

        }

        public IActionResult Delete(int id) {
            var vr = _employeeRepo.VacationsRequestRetrieveById(id);
            return View(vr);
        }
        [HttpPost]
        public IActionResult Delete(VacationRequest model) {
            var vr = _employeeRepo.VacationsRequestDelete(model.VacationRequestId, model.EmployeeId);
            return RedirectToAction("Index", new { employeeId = model.EmployeeId });
        }
    }
}
