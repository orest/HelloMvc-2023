using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelloMvc.Models.VM;
using HelloMvc.Repos;

namespace HelloMvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepo _employeeRepo;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepo employeeRepo) {
            _logger = logger;
            _employeeRepo = employeeRepo;
        }

        public IActionResult Index() {
            var vm = new HomeVm();

            var students = new List<Student>()
            {
                new Student() {FirstName = "Bob"},
                new Student() {FirstName = "Adam"},
                new Student() {FirstName = "Bill"}
            };
            vm.Students = students;
            vm.Employee = _employeeRepo.GetEmployeeOfMonth();

            ViewBag.PageTitle = "My page title";

            //1. Create new ViewModel for Home/Index HomeVm
            //2. List<Student>, Employee
            //3. Add New Repository Method => GetEmployeeOfMonth
            //4. Pass HomeVm to View
            //5. Change View @model to use new HomeVm
            //6. show all student =>loop
            //7. Use PartialView For Employee

            return View(vm);

        }

        public IActionResult Select() {
            var student = new Student();

            return View(student);
        }


        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}