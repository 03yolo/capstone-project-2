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
    public class AssessmentModelsController : Controller
    {
        private readonly PomsDbContext _context;

        public AssessmentModelsController(PomsDbContext context)
        {
            _context = context;
        }

        // GET: AssessmentModels
        public async Task<IActionResult> Index()
        {
            var pomsDbContext = _context.AssessmentModel.Include(a => a.Faculty).Include(a => a.Subject);
            return View(await pomsDbContext.ToListAsync());
        }

        // GET: AssessmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.AssessmentModel
                .Include(a => a.Faculty)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (assessmentModel == null)
            {
                return NotFound();
            }

            return View(assessmentModel);
        }

        // GET: AssessmentModels/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.FacultyModel, "UserId", "EmployeeNo");
            ViewData["SubjectId"] = new SelectList(_context.Set<SubjectModel>(), "SubjectId", "SubjectId");
            return View();
        }

        // POST: AssessmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssessmentId,SubjectId,FacultyId,QuarterId,AssessmentName,AssessmentType,AssessmentNo,TotalItems,DateGiven")] AssessmentModel assessmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.FacultyModel, "UserId", "EmployeeNo", assessmentModel.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.Set<SubjectModel>(), "SubjectId", "SubjectId", assessmentModel.SubjectId);
            return View(assessmentModel);
        }

        // GET: AssessmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.AssessmentModel.FindAsync(id);
            if (assessmentModel == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_context.FacultyModel, "UserId", "EmployeeNo", assessmentModel.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.Set<SubjectModel>(), "SubjectId", "SubjectId", assessmentModel.SubjectId);
            return View(assessmentModel);
        }

        // POST: AssessmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentId,SubjectId,FacultyId,QuarterId,AssessmentName,AssessmentType,AssessmentNo,TotalItems,DateGiven")] AssessmentModel assessmentModel)
        {
            if (id != assessmentModel.AssessmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentModelExists(assessmentModel.AssessmentId))
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
            ViewData["FacultyId"] = new SelectList(_context.FacultyModel, "UserId", "EmployeeNo", assessmentModel.FacultyId);
            ViewData["SubjectId"] = new SelectList(_context.Set<SubjectModel>(), "SubjectId", "SubjectId", assessmentModel.SubjectId);
            return View(assessmentModel);
        }

        // GET: AssessmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessmentModel = await _context.AssessmentModel
                .Include(a => a.Faculty)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (assessmentModel == null)
            {
                return NotFound();
            }

            return View(assessmentModel);
        }

        // POST: AssessmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessmentModel = await _context.AssessmentModel.FindAsync(id);
            if (assessmentModel != null)
            {
                _context.AssessmentModel.Remove(assessmentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentModelExists(int id)
        {
            return _context.AssessmentModel.Any(e => e.AssessmentId == id);
        }
    }
}
