using EFCoreAssignment2.DBFirstModels;
using EFCoreAssignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EFCoreAssignment2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DBFirstContext _context;

        public DepartmentController(DBFirstContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            return View(_context.Departments.ToList());
        }

        // CREATE
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            return View(_context.Departments.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            _context.Departments.Update(dept);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            return View(_context.Departments.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dept = _context.Departments.Find(id);
            _context.Departments.Remove(dept);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
