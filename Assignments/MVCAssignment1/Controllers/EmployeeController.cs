using Microsoft.AspNetCore.Mvc;

namespace MVCAssignment1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Details()
        {
            ViewData["Name"] = "Ravi";
            ViewData["Salary"] = 50000;
            ViewData["Department"] = "IT";

            return View();
        }
    }
}