using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment2.DataBase;
using EFCoreAssignment2.Entities;
using EFCoreAssignment2.Models;
using Microsoft.EntityFrameworkCore;
namespace EFCoreAssignment2.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 INDEX - Show courses WITH students
        public IActionResult Index()
        {
            var courses = _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .ToList();

            return View(courses);
        }

        // 🔹 DETAILS
        public IActionResult Details(int id)
        {
            var course = _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // 🔹 CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    return Content(error.ErrorMessage);
                }
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 🔹 EDIT (GET)
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // 🔹 DELETE (GET)
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // 🔹 DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
