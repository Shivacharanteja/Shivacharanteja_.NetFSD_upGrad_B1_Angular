using Microsoft.AspNetCore.Mvc;
using MVCAssignment1.Models;

namespace MVCAssignment1.Controllers
{
    public class StudentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return Content("Student Index Page");
        //}
        //public IActionResult Profile()
        //{
        //    return Content("Student Profile Page");
        //}
        //public IActionResult Details()
        //{
        //    ViewBag.Name = "John";
        //    ViewBag.Age = 25;

        //    return View();
        //}
        public IActionResult List()
        {
            List<string> students = new List<string>
        {
            "John",
            "Ravi",
            "Anita"
        };

            return View(students);
        }
        //public IActionResult Details()
        //{
        //    Student student = new Student
        //    {
        //        Name = "John",
        //        Age = 22
        //    };

        //    return View(student);
        //}
        public IActionResult Details(string name, int age)
        {
            ViewData["Message"] = "Student Information Page";

            return View(new Student
            {
                Name = name,
                Age = age
            });
        }
    }
}