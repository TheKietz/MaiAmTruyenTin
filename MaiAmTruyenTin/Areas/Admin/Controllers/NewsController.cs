using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaiAmTruyenTin.Data;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly KrbltdhcMaiamtruyentinContext _context;

        public NewsController(KrbltdhcMaiamtruyentinContext context)
        {
            _context = context;
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            var krbltdhcMaiamtruyentinContext = _context.News.Include(n => n.ApprovedByNavigation).Include(n => n.Author).Include(n => n.Category).Include(n => n.CreatedByNavigation).Include(n => n.DeletedByNavigation).Include(n => n.UpdatedByNavigation);
            return View(await krbltdhcMaiamtruyentinContext.ToListAsync());
        }

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.ApprovedByNavigation)
                .Include(n => n.Author)
                .Include(n => n.Category)
                .Include(n => n.CreatedByNavigation)
                .Include(n => n.DeletedByNavigation)
                .Include(n => n.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Content,CoverImage,CategoryId,AuthorId,Status,ViewCount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt,ApprovedBy,ApprovedAt")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.ApprovedBy);
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", news.CategoryId);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.UpdatedBy);
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.ApprovedBy);
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", news.CategoryId);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.UpdatedBy);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Title,Content,CoverImage,CategoryId,AuthorId,Status,ViewCount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt,ApprovedBy,ApprovedAt")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
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
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.ApprovedBy);
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", news.CategoryId);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", news.UpdatedBy);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.ApprovedByNavigation)
                .Include(n => n.Author)
                .Include(n => n.Category)
                .Include(n => n.CreatedByNavigation)
                .Include(n => n.DeletedByNavigation)
                .Include(n => n.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
