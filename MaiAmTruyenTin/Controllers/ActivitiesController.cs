using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaiAmTruyenTin.Data;

namespace MaiAmTruyenTin.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly KrbltdhcMaiamtruyentinContext _context;

        public ActivitiesController(KrbltdhcMaiamtruyentinContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var krbltdhcMaiamtruyentinContext = _context.Activities.Include(a => a.CreatedByNavigation).Include(a => a.DeletedByNavigation).Include(a => a.UpdatedByNavigation);
            return View(await krbltdhcMaiamtruyentinContext.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.CreatedByNavigation)
                .Include(a => a.DeletedByNavigation)
                .Include(a => a.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,Title,Description,Location,StartDate,EndDate,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.UpdatedBy);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.UpdatedBy);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,Title,Description,Location,StartDate,EndDate,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt")] Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.ActivityId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", activity.UpdatedBy);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.CreatedByNavigation)
                .Include(a => a.DeletedByNavigation)
                .Include(a => a.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.ActivityId == id);
        }
    }
}
