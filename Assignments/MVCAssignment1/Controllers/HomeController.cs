using Microsoft.AspNetCore.Mvc;
using MVCAssignment1.Models;
using System.Diagnostics;

namespace MVCAssignment1.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return Content("Welcome to ASP.NET Core MVC");
        //}

        //public IActionResult About()
        //{
        //    return Content("This is About page");
        //}


        //public IActionResult Contact()
        //{
        //    return Content("Contact us at support@test.com");
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

    }
}
