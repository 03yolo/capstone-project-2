using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Models;

namespace poms_website_project_2._0.Controllers
{
    public class FacultyModelsController : Controller
    {
        private readonly PomsDbContext _context;

        public FacultyModelsController(PomsDbContext context)
        {
            _context = context;
        }

        // GET: FacultyModels
        public async Task<IActionResult> Index()
        {
            var pomsDbContext = _context.FacultyModel.Include(f => f.FacultyNavigation);
            return View(await pomsDbContext.ToListAsync());
        }

        // GET: FacultyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyModel = await _context.FacultyModel
                .Include(f => f.FacultyNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (facultyModel == null)
            {
                return NotFound();
            }

            return View(facultyModel);
        }

        // GET: FacultyModels/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId");
            return View();
        }

        // POST: FacultyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,EmployeeNo,Designation")] FacultyModel facultyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", facultyModel.UserId);
            return View(facultyModel);
        }

        // GET: FacultyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyModel = await _context.FacultyModel.FindAsync(id);
            if (facultyModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", facultyModel.UserId);
            return View(facultyModel);
        }

        // POST: FacultyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,EmployeeNo,Designation")] FacultyModel facultyModel)
        {
            if (id != facultyModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyModelExists(facultyModel.UserId))
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
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", facultyModel.UserId);
            return View(facultyModel);
        }

        // GET: FacultyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyModel = await _context.FacultyModel
                .Include(f => f.FacultyNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (facultyModel == null)
            {
                return NotFound();
            }

            return View(facultyModel);
        }

        // POST: FacultyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultyModel = await _context.FacultyModel.FindAsync(id);
            if (facultyModel != null)
            {
                _context.FacultyModel.Remove(facultyModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyModelExists(int id)
        {
            return _context.FacultyModel.Any(e => e.UserId == id);
        }
    }
}
