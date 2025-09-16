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
using MaiAmTruyenTin.Areas.Admin.ViewModels;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly MaiamtruyentinContext _context;
        private readonly FileUploadHelper _fileHelper;

        public NewsController(MaiamtruyentinContext context, IWebHostEnvironment env)
        {
            _context = context;
            _fileHelper = new FileUploadHelper(env);
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            var newsList = await _context.News
                .Include(n => n.Author)
                .Include(n => n.Category)
                .Select(n => new NewsIndexVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    CoverImage = n.CoverImage,                   
                    Status = n.Status,
                    AuthorName = n.Author.FullName,
                    CategoryName = n.Category.Name
                })
                .ToListAsync();

            return View(newsList);
        }


        // GET: Admin/News/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Content,CoverImage,CategoryId,AuthorId,Status,ViewCount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt,ApprovedBy,ApprovedAt")] News news, IFormFile? CoverImageFile)
        {
            if (ModelState.IsValid)
            {
                news.CoverImage = await _fileHelper.UploadFile(CoverImageFile);
                news.IsDeleted = false;
                news.Status = Enums.NewsStatus.Pending;
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "FullName", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", news.CategoryId);
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "Email", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", news.CategoryId);
            ViewData["StatusList"] = EnumHelper.GetEnumSelectList(news.Status);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Title,Content,CoverImage,CategoryId,AuthorId,Status,ViewCount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt,ApprovedBy,ApprovedAt")] News news, IFormFile? CoverImageFile)
        {
            if (id != news.NewsId) return NotFound();

            if (ModelState.IsValid)
            {
                // Lấy dữ liệu cũ từ DB
                var existingNews = await _context.News.AsNoTracking()
                                        .FirstOrDefaultAsync(n => n.NewsId == id);
                if (existingNews == null) return NotFound();

                if (CoverImageFile != null)
                {
                    // Upload ảnh mới nếu có file
                    news.CoverImage = await _fileHelper.UploadFile(CoverImageFile);
                }
                else
                {
                    // Giữ nguyên ảnh cũ
                    news.CoverImage = existingNews.CoverImage;
                }

                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "FullName", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", news.CategoryId);
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
