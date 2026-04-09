using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment2.DataBase;
using EFCoreAssignment2.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 INDEX - Show all enrollments with Student & Course
        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            return View(enrollments);
        }

        // 🔹 DETAILS
        public IActionResult Details(int id)
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
                return NotFound();

            return View(enrollment);
        }

        // 🔹 CREATE (GET)
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        // 🔹 CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                // 🔁 VERY IMPORTANT: reload dropdowns
                ViewBag.Students = new SelectList(_context.Students, "Id", "Name", enrollment.StudentId);
                ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title", enrollment.CourseId);

                return View(enrollment);
            }

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 🔹 EDIT (GET)
        public IActionResult Edit(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment == null)
                return NotFound();

            LoadDropdowns(enrollment.StudentId, enrollment.CourseId);

            return View(enrollment);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Update(enrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // 🔴 Reload dropdowns if validation fails
            LoadDropdowns(enrollment.StudentId, enrollment.CourseId);

            return View(enrollment);
        }

        // 🔹 DELETE (GET)
        public IActionResult Delete(int id)
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
                return NotFound();

            return View(enrollment);
        }

        // 🔹 DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // 🔹 HELPER METHOD FOR DROPDOWNS (BEST PRACTICE)
        private void LoadDropdowns(int? studentId = null, int? courseId = null)
        {
            ViewBag.Students = new SelectList(_context.Students, "Id", "Name", studentId);
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title", courseId);
        }
    }
}