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
    public class LearnerModelsController : Controller
    {
        private readonly PomsDbContext _context;

        public LearnerModelsController(PomsDbContext context)
        {
            _context = context;
        }

        // GET: LearnerModels
        public async Task<IActionResult> Index()
        {
            var pomsDbContext = _context.LearnerModel.Include(l => l.LearnerNavigation);
            return View(await pomsDbContext.ToListAsync());
        }

        // GET: LearnerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerModel = await _context.LearnerModel
                .Include(l => l.LearnerNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (learnerModel == null)
            {
                return NotFound();
            }

            return View(learnerModel);
        }

        // GET: LearnerModels/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId");
            return View();
        }

        // POST: LearnerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Lrn,BirthDate,GradeLevel")] LearnerModel learnerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learnerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", learnerModel.UserId);
            return View(learnerModel);
        }

        // GET: LearnerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerModel = await _context.LearnerModel.FindAsync(id);
            if (learnerModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", learnerModel.UserId);
            return View(learnerModel);
        }

        // POST: LearnerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Lrn,BirthDate,GradeLevel")] LearnerModel learnerModel)
        {
            if (id != learnerModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learnerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerModelExists(learnerModel.UserId))
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
            ViewData["UserId"] = new SelectList(_context.UserModel, "UserId", "UserId", learnerModel.UserId);
            return View(learnerModel);
        }

        // GET: LearnerModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learnerModel = await _context.LearnerModel
                .Include(l => l.LearnerNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (learnerModel == null)
            {
                return NotFound();
            }

            return View(learnerModel);
        }

        // POST: LearnerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learnerModel = await _context.LearnerModel.FindAsync(id);
            if (learnerModel != null)
            {
                _context.LearnerModel.Remove(learnerModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerModelExists(int id)
        {
            return _context.LearnerModel.Any(e => e.UserId == id);
        }
    }
}
