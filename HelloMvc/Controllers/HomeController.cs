using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloMvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {

            var students = new List<Student>()
            {
                new Student() {FirstName = "Bob"},
                new Student() {FirstName = "Adam"},
                new Student() {FirstName = "Bill"}
            };

            ViewBag.PageTitle = "My page title";

            return View(students);

        }

        public IActionResult Select()
        {
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