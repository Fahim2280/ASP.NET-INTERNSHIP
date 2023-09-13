using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quad_Theory_Limited.Models;

namespace Quad_Theory_Limited.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        //Show Students List
        public IActionResult Index()
        {
            
                List<Student> students = _context.Students.Include(s => s.Classes).ToList();
                return View(students);
            
            
        }

        public IActionResult Create()
        {
            ViewBag.Classes = _context.Classes.ToList(); // Populate Classes for dropdown
            return View();
        }

        //Add Students Information 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            /*try { 
            if (ModelState.IsValid)
            {
                // Assign CreatedDate and ModificationDate
                student.CreatedDate = DateTime.Now;
                student.ModificationDate = DateTime.Now;

                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, repopulate Classes for dropdown
            ViewBag.Classes = _context.Classes.ToList();
            return View(student);

            }catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return StatusCode(500, "An error occurred while saving the changes.");
            }*/


            try
            {
                if (ModelState.IsValid)
                {
                    // Assign CreatedDate and ModificationDate
                    student.CreatedDate = DateTime.Now;
                    student.ModificationDate = DateTime.Now;
                    student.Id = Guid.NewGuid(); // Generate a new GUID for the primary key

                    _context.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                // If ModelState is not valid, repopulate Classes for dropdown
                ViewBag.Classes = _context.Classes.ToList();
                return View(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return StatusCode(500, "An error occurred while saving the changes.");
            }
        }

        //Show Students Information 
        public IActionResult Details(Guid id)
        {
            try
            {
                var student = _context.Students.Include(s => s.Classes).FirstOrDefault(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return StatusCode(500, "An error occurred while saving the changes.");
            }

           
        }

        public IActionResult Edit(Guid id)
        {
            try
            {
                var student = _context.Students.Include(s => s.Classes).FirstOrDefault(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }

                ViewBag.Classes = _context.Classes.ToList();

                return View(student);

            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return StatusCode(500, "An error occurred while saving the changes.");
            }

            
        }

        //Edit Students Information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                student.ModificationDate = DateTime.Now;
                _context.Update(student);
                _context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to student list page
            }

            ViewBag.Classes = _context.Classes.ToList();
            return View(student);
        }

        //Delete Students Information 
        public IActionResult Delete(Guid id)
        {
            try
            {
                var student = _context.Students.Where(s => s.Id == id).First();
                _context.Students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to student list page
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return StatusCode(500, "An error occurred while saving the changes.");
            }
            
        }

    }
}
