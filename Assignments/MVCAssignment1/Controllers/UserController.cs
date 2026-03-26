using Microsoft.AspNetCore.Mvc;

namespace MVCAssignment1.Controllers
{
    public class UserController : Controller
    {
        //public IActionResult Details(string? name, int? age)
        //{
        //    return Content($"Name: {name}, Age: {age}");
        //}
        //public IActionResult Index()
        //{
        //    ViewData["Name"] = "John";
        //    ViewData["Age"] = 25;

        //    return View();
        //}
        public IActionResult CheckAge()
        {
            int age = 20; // example
            ViewBag.Age = age;

            return View();
        }
    }
}
