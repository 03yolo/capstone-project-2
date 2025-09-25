using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Data.Entities;

namespace poms_website_project_2._0.Controllers
{
    public class SchoolFormsController : Controller
    {
        private readonly PomsDbContext _context;

        public SchoolFormsController(PomsDbContext context)
        {
            _context = context;
        }

        // GET: SchoolForms
        public async Task<IActionResult> Index()
        {
            var pomsDbContext = _context.SchoolForm.Include(s => s.Learner);
            return View(await pomsDbContext.ToListAsync());
        }

        // GET: SchoolForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolForm = await _context.SchoolForm
                .Include(s => s.Learner)
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (schoolForm == null)
            {
                return NotFound();
            }

            return View(schoolForm);
        }

        // GET: SchoolForms/Create
        public IActionResult Create()
        {
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn");
            return View();
        }

        // POST: SchoolForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,LearnerId,FormType,FilePath,GeneratedBy,GeneratedAt")] SchoolForm schoolForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", schoolForm.LearnerId);
            return View(schoolForm);
        }

        // GET: SchoolForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolForm = await _context.SchoolForm.FindAsync(id);
            if (schoolForm == null)
            {
                return NotFound();
            }
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", schoolForm.LearnerId);
            return View(schoolForm);
        }

        // POST: SchoolForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,LearnerId,FormType,FilePath,GeneratedBy,GeneratedAt")] SchoolForm schoolForm)
        {
            if (id != schoolForm.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolFormExists(schoolForm.FormId))
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
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", schoolForm.LearnerId);
            return View(schoolForm);
        }

        // GET: SchoolForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolForm = await _context.SchoolForm
                .Include(s => s.Learner)
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (schoolForm == null)
            {
                return NotFound();
            }

            return View(schoolForm);
        }

        // POST: SchoolForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolForm = await _context.SchoolForm.FindAsync(id);
            if (schoolForm != null)
            {
                _context.SchoolForm.Remove(schoolForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolFormExists(int id)
        {
            return _context.SchoolForm.Any(e => e.FormId == id);
        }
    }
}
