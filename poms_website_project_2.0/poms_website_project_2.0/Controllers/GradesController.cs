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
    public class GradesController : Controller
    {
        private readonly PomsDbContext _context;

        public GradesController(PomsDbContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var pomsDbContext = _context.Grade.Include(g => g.Faculty).Include(g => g.Learner).Include(g => g.Subject);
            return View(await pomsDbContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade
                .Include(g => g.Faculty)
                .Include(g => g.Learner)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "UserId", "EmployeeNo");
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,LearnerId,FacultyId,SubjectId,Quarter,WwScore,WwTotal,WwPercentage,PtScore,PtTotal,PtPercentage,QaScore,QaTotal,QaPercentage,FinalGrade,Remarks,EncodedAt")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "UserId", "EmployeeNo", grade.FacultyId);
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", grade.LearnerId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "UserId", "EmployeeNo", grade.FacultyId);
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", grade.LearnerId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeId,LearnerId,FacultyId,SubjectId,Quarter,WwScore,WwTotal,WwPercentage,PtScore,PtTotal,PtPercentage,QaScore,QaTotal,QaPercentage,FinalGrade,Remarks,EncodedAt")] Grade grade)
        {
            if (id != grade.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.GradeId))
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
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "UserId", "EmployeeNo", grade.FacultyId);
            ViewData["LearnerId"] = new SelectList(_context.Learner, "UserId", "Lrn", grade.LearnerId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grade
                .Include(g => g.Faculty)
                .Include(g => g.Learner)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grade.FindAsync(id);
            if (grade != null)
            {
                _context.Grade.Remove(grade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.GradeId == id);
        }
    }
}
