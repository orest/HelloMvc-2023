using HelloMvc.Models;
using HelloMvc.Models.VM;
using HelloMvc.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class EmployeesController : Controller {
        private readonly IEmployeeRepo _employeeRepo;
        //public static EmployeeMockRepo _employeeRepo =new EmployeeMockRepo() ;

        public EmployeesController(IEmployeeRepo employeeRepo) {
            _employeeRepo = employeeRepo;
        }


        public IActionResult Index()
        {
            
            var employeeData = _employeeRepo.GetAllEmployees();
            return View(employeeData);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVm model) {
            //var errorList = new List<string>();

            //if (string.IsNullOrEmpty(model.FirstName)) {
            //    errorList.Add("Invalid First Name"); ;
            //}

            //if (string.IsNullOrEmpty(model.LastName)) {
            //    errorList.Add("Invalid Last Name"); ;
            //}

            //if (errorList.Any()) {
            //    ViewBag.ErrorList = errorList;
            //    return View(model);
            //}


            //1. Add Properties to Employee -> HomePhone and MobilePhone
            //2. Add Properties to EmployeeVm -> HomePhone and MobilePhone
            //3. Add-Migration
            //4. Update-Database
            //4.5 Update Mapping Logic between Employee and EmployeeVM
            //5. Add Validation Logic


            if (string.IsNullOrEmpty(model.HomePhone) && string.IsNullOrEmpty(model.MobilePhone)) {

                ModelState.AddModelError("", "Home phone or Mobile phone required ");
            }


            if (ModelState.IsValid) {
                var entity = new Employee() {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HomePhone = model.HomePhone,
                    MobilePhone = model.MobilePhone
                };
                _employeeRepo.CreateEmployee(entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Edit(int id) {
            if (id == 0) {
                return RedirectToAction("Index");
            }

            var employee = _employeeRepo.GetById(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model) {
            //_employeeRepo.Update(model);
            return RedirectToAction("Index");
        }
    }
}