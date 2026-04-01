using Microsoft.AspNetCore.Mvc;
using MVCAssignment3.Models;
using MVCAssignment3.ViewModels;

namespace MVCAssignment3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        static List<User> users = new List<User>();

        // REGISTER GET
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.Name,
                    Email=model.Email,
                    Password= model.Password
                };
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // LOGIN GET
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);

                return RedirectToAction("Profile");
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }

        // PROFILE
        public IActionResult Profile()
        {
            var name = HttpContext.Session.GetString("UserName");
            var email = HttpContext.Session.GetString("UserEmail");

            if (name == null)
            {
                return RedirectToAction("Login");
            }

            UserViewModel vm = new UserViewModel
            {
                Name = name,
                Email = email
            };

            return View(vm);
        }

        // EDIT GET
        public IActionResult Edit()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Email == updatedUser.Email);

            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Password = updatedUser.Password;

                HttpContext.Session.SetString("UserName", user.Name);
            }

            return RedirectToAction("Profile");
        }

        // LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
