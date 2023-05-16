using HelloMvc.Models;
using HelloMvc.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class EmployeesController : Controller {
        private readonly IEmployeeRepo _employeeRepo;
        //public static EmployeeMockRepo _employeeRepo =new EmployeeMockRepo() ;

        public EmployeesController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }


        public IActionResult Index()
        {
            var employeeData = _employeeRepo.GetAllEmployees();
            return View(employeeData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            _employeeRepo.CreateEmployee(model);
            //var employeeData = _employeeRepo.GetAllEmployees();
            return RedirectToAction("Index");
        }


        public IActionResult Edit( int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var employee = _employeeRepo.GetById(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            //_employeeRepo.Update(model);
            return RedirectToAction("Index");
        }
    }
}
