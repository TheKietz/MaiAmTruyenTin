using MaiAmTruyenTin.Areas.Admin.ViewModels;
using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsAdminController : Controller
    {
        private readonly MaiamtruyentinContext _context;
        private readonly FileUploadHelper _fileHelper;

        public NewsAdminController(MaiamtruyentinContext context, IWebHostEnvironment env)
        {
            _context = context;
            _fileHelper = new FileUploadHelper(env);
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            var list = _context.News
                //.Include(n => n.Category)
                //.Include(n => n.Author)
                .Select(n => new TinTucVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    CoverImage = n.CoverImage,
                    Status = n.Status,
                    CreatedAt = n.CreatedAt,
                    AuthorName = n.Author != null ? n.Author.FullName : "",
                    CategoryName = n.Category != null ? n.Category.Name : ""
                })
                .ToList();

            return View(list);
        }

        //// GET: Admin/News/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var news = await _context.News
        //        .Include(n => n.ApprovedByNavigation)
        //        .Include(n => n.Author)
        //        .Include(n => n.Category)
        //        .Include(n => n.CreatedByNavigation)
        //        .Include(n => n.DeletedByNavigation)
        //        .Include(n => n.UpdatedByNavigation)
        //        .FirstOrDefaultAsync(m => m.NewsId == id);
        //    if (news == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(news);
        //}

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "FullName");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "FullName");

            return View();
        }


        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TinTucVM vm, IFormFile? CoverImageFile)
        {
            if (ModelState.IsValid)
            {
                var news = new News
                {
                    Title = vm.Title,
                    Content = vm.Content,
                    Status = vm.Status,
                    //AuthorId = vm.AuthorId,
                    CategoryId = vm.CategoryId,
                    CreatedAt = DateTime.Now,
                    CoverImage = await _fileHelper.UploadFile(CoverImageFile)

                };
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
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
        // POST: Admin/News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TinTucVM vm, IFormFile? CoverImageFile)
        {
            if (id != vm.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var news = await _context.News.FindAsync(id);
                    if (news == null) return NotFound();

                    // Cập nhật các field
                    news.Title = vm.Title;
                    news.Content = vm.Content;
                    news.Status = vm.Status;
                    news.AuthorId = vm.AuthorId;
                    news.CategoryId = vm.CategoryId;
                    news.UpdatedAt = DateTime.Now;
                    news.UpdatedBy = vm.UpdatedBy;

                    // Ảnh mới
                    if (CoverImageFile != null)
                    {
                        news.CoverImage = await _fileHelper.UploadFile(CoverImageFile);
                    }
                    // Nếu không upload, giữ nguyên CoverImage cũ (không cần xử lý thêm)

                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(vm.NewsId))
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

            ViewData["ApprovedBy"] = new SelectList(_context.Users, "UserId", "UserId", vm.ApprovedBy);
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", vm.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", vm.CategoryId);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserId", vm.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "UserId", "UserId", vm.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserId", vm.UpdatedBy);

            return View(vm);
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

        //[HttpPost]
        //public async Task<IActionResult> UploadImage(IFormFile upload)
        //{
        //    if (upload != null && upload.Length > 0)
        //    {
        //        var uploadDir = Path.Combine(_env.WebRootPath, "uploads");
        //        if (!Directory.Exists(uploadDir))
        //            Directory.CreateDirectory(uploadDir);

        //        var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName); // tên file hợp lệ
        //        var filePath = Path.Combine(uploadDir, fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await upload.CopyToAsync(stream);
        //        }

        //        return Json(new
        //        {
        //            uploaded = 1,
        //            fileName = fileName,
        //            url = "/uploads/" + fileName
        //        });
        //    }

        //    return Json(new { uploaded = 0, error = new { message = "No file uploaded" } });
        //}


        //[HttpGet]
        //public IActionResult UploadExplorer()
        //{
        //    var uploadDir = Path.Combine(_env.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadDir))
        //        Directory.CreateDirectory(uploadDir);

        //    var dir = new DirectoryInfo(uploadDir);
        //    ViewBag.fileInfo = dir.GetFiles();

        //    return View("FileExplorer");
        //}

    }
}
