using Microsoft.AspNetCore.Mvc;

namespace MVCAssignment1.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Add(int a, int b)
        {
            int result = a + b;
            return Content($"Addition Result: {result}");
        }

        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            return Content($"Multiplication Result: {result}");
        }
    }
}
