using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloMvc.Models {
    public class Student {
        public Student()
        {
            Countries = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "USA", Text = "United States"},
                new SelectListItem() {Value = "UA", Text = "Ukraine"}
            };
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; set; }

    }
}
