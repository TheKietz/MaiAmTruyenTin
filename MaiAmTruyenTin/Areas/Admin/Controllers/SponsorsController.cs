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
    public class SponsorsController : Controller
    {
        private readonly MaiamtruyentinContext _context;
        private readonly FileUploadHelper _fileHelper;

        public SponsorsController(MaiamtruyentinContext context)
        {
            _context = context;
        }

        // GET: Admin/Sponsors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sponsors.ToListAsync());
        }

        // GET: Admin/Sponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsors
                .FirstOrDefaultAsync(m => m.SponsorId == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // GET: Admin/Sponsors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sponsors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SponsorId,Name,Representative,Email,Phone,Address,SponsorType,Logo,Website,Notes,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt")] Sponsor sponsor, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                sponsor.Logo = await _fileHelper.UploadFile(Logo);
                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        // GET: Admin/Sponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // POST: Admin/Sponsors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SponsorId,Name,Representative,Email,Phone,Address,SponsorType,Logo,Website,Notes,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,IsDeleted,DeletedBy,DeletedAt")] Sponsor sponsor, IFormFile? Logo)
        {
            if (id != sponsor.SponsorId)
            {
                return NotFound();
            }
            // Lấy dữ liệu cũ từ DB
            var existingNews = await _context.Sponsors.AsNoTracking()
                                    .FirstOrDefaultAsync(n => n.SponsorId == id);
            if (existingNews == null) return NotFound();

            if (Logo != null)
            {
                // Upload ảnh mới nếu có file
                sponsor.Logo = await _fileHelper.UploadFile(Logo);
            }
            else
            {
                // Giữ nguyên ảnh cũ
                sponsor.Logo = existingNews.Logo;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.SponsorId))
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
            return View(sponsor);
        }

        // POST: Admin/Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor != null)
            {
                _context.Sponsors.Remove(sponsor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorExists(int id)
        {
            return _context.Sponsors.Any(e => e.SponsorId == id);
        }
    }
}
