using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment2.DBFirstModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace EFCoreAssignment2.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DBFirstContext _context;

        public TeacherController(DBFirstContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var teachers = _context.Teachers
                .Include(t => t.Department)
                .ToList();

            return View(teachers);
        }

        // CREATE
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Find(id);

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", teacher.DepartmentId);

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers
                .Include(t => t.Department)
                .FirstOrDefault(t => t.Id == id);

            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _context.Teachers.Find(id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
