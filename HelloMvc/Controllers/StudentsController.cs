using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers {
    public class StudentsController : Controller {
        public IActionResult Index() {
            //Shows all students
            return View();
        }

        //students/details/3
        //[Route("StudentInfo/{id:int}")]
        public IActionResult Details(int id) {

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create (string firstName, string lastName)
        //{
        //    var student = new Student() {FirstName = firstName, LastName = lastName};
        //    /// add to DB

        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(Student model ) {
          
            /// add to DB

            return RedirectToAction("Index","Home");
        }
    }
}
