using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using urgent_IT_project1.Models;

namespace urgent_IT_project1.Controllers
{
    public class CoursesController : Controller
    {
        private readonly PlacementContext _context;
        IWebHostEnvironment env;
        public CoursesController(PlacementContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Courses
        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }
        /*public async Task<IActionResult> Index()
        {
              return _context.Courses != null ? 
                          View(await _context.Courses.ToListAsync()) :
                          Problem("Entity set 'PlacementContext.Courses'  is null.");
        }*/

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel prod)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (prod.Photo != null)
                {
                    var ext = Path.GetExtension(prod.Photo.FileName);
                    var size = prod.Photo.Length;
                    if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                    {
                        if (size <= 1000000)
                        {


                            string folder = Path.Combine(env.WebRootPath, "images");
                            fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(prod.Photo.FileName);
                            string filepath = Path.Combine(folder, fileName);

                            using (var fileStream = new FileStream(filepath, FileMode.Create))
                            {
                                prod.Photo.CopyTo(fileStream);
                            }

                            Course p = new Course()
                            {
                                CImage = fileName,
                                CName = prod.CName,
                                CDuration = prod.CDuration,
                                CDescrip1 = prod.CDescrip1,
                                CDescrip2 = prod.CDescrip2,
                                CPrice = prod.CPrice

                            };

                            _context.Courses.Add(p);
                            _context.SaveChanges();
                            TempData["Success"] = "Product Added.";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Size_Error"] = "Image must be less than 1MB";

                        }
                    }
                    else
                    {
                        TempData["Ext_Error"] = "Only PNG, JGP, JPEG Images Allowed";
                    }
                }
            }
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CImage,CName,CDuration,CDescrip1,CDescrip2,CPrice")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }*/

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CImage,CName,CDuration,CDescrip1,CDescrip2,CPrice")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'PlacementContext.Courses'  is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Placement_Course()
        {
            return View();
        }
    }
}
