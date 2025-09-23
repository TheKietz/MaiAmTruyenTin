using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Helpers;
using MaiAmTruyenTin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaticPagesController : Controller
    {
        private readonly MaiamtruyentinContext _context;
        private readonly FileUploadHelper _fileHelper;

        public StaticPagesController(MaiamtruyentinContext context)
        {
            _context = context;
        }

        // GET: Admin/StaticPages
        public async Task<IActionResult> Index()
        {
            var maiamtruyentinContext = _context.StaticPages.Include(s => s.CreatedByUser).Include(s => s.DeletedByUser).Include(s => s.UpdatedByUser);
            return View(await maiamtruyentinContext.ToListAsync());
        }

        // GET: Admin/StaticPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticPage = await _context.StaticPages
                .Include(s => s.CreatedByUser)
                .Include(s => s.DeletedByUser)
                .Include(s => s.UpdatedByUser)
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (staticPage == null)
            {
                return NotFound();
            }

            return View(staticPage);
        }

        // GET: Admin/StaticPages/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Email");
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "Email");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Admin/StaticPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,Slug,Title,Content,CoverImage,IsVisible,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,isDeleted,DeletedBy,DeletedAt")] StaticPage staticPage, IFormFile? CoverImageFile)
        {
            if (ModelState.IsValid)
            {
                staticPage.CoverImage = await _fileHelper.UploadFile(CoverImageFile);
                staticPage.isDeleted = false;
                staticPage.CreatedAt = staticPage.CreatedAt == DateTime.MinValue ? DateTime.Now : staticPage.CreatedAt;
                _context.Add(staticPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }           
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.UpdatedBy);
            return View(staticPage);
        }

        // GET: Admin/StaticPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.UpdatedBy);
            return View(staticPage);
        }

        // POST: Admin/StaticPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,Slug,Title,Content,CoverImage,IsVisible,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,isDeleted,DeletedBy,DeletedAt")] StaticPage staticPage)
        {
            if (id != staticPage.PageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staticPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaticPageExists(staticPage.PageId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Email", staticPage.UpdatedBy);
            return View(staticPage);
        }

        // POST: Admin/StaticPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage != null)
            {
                _context.StaticPages.Remove(staticPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaticPageExists(int id)
        {
            return _context.StaticPages.Any(e => e.PageId == id);
        }
    }
}
