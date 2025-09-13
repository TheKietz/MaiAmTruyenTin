using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MaiAmTruyenTin.Controllers
{
    public class DangKyTinhNguyenController : Controller
    {
        private readonly MaiamtruyentinContext db;
        public DangKyTinhNguyenController(MaiamtruyentinContext context) => db = context;
       
        public IActionResult Index()
        {
            // Lấy 3 tin tức mới nhất thuộc chuyên mục "Tình nguyện"
            var tinhNguyenNews = db.News
                                .Include(n => n.Category)
                                .Where(n => EF.Functions.Like(n.Category.Name, "%Tình nguyện%"))
                                .OrderByDescending(n => n.CreatedAt)
                                .Take(3)
                                .ToList();
            var call = db.StaticPages.FirstOrDefault(p => p.Title == "Kêu gọi tình nguyện viên")?.Content;
            // Tạo ViewModel
            var vm = new ViewModels.DangKyTinhNguyenVM
            {
                volunteerNews = tinhNguyenNews,
                NewVolunteer = new Volunteer(),
                callForVolunteers = call ?? string.Empty
            };
            return View(vm);
        }

        // POST: dangkytinhnguyen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DangKyTinhNguyenVM vm)
        {
            // kiểm tra trùng Email
            if (!string.IsNullOrEmpty(vm.NewVolunteer.Email) &&
                db.Volunteers.Any(v => v.Email == vm.NewVolunteer.Email))
            {
                ModelState.AddModelError("NewVolunteer.Email", "Email đã được sử dụng!");
            }

            // kiểm tra trùng Phone
            if (!string.IsNullOrEmpty(vm.NewVolunteer.Phone) &&
                db.Volunteers.Any(v => v.Phone == vm.NewVolunteer.Phone))
            {
                ModelState.AddModelError("NewVolunteer.Phone", "Số điện thoại đã được sử dụng!");
            }
            if (ModelState.IsValid)
            {
                vm.NewVolunteer.CreatedAt = DateTime.Now;
                vm.NewVolunteer.UpdatedAt = DateTime.Now;
                vm.NewVolunteer.IsDeleted = false;

                db.Volunteers.Add(vm.NewVolunteer);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Đăng ký tình nguyện thành công!";
                return RedirectToAction("Index");
            }

            // Nếu không hợp lệ, phải load lại dữ liệu News để tránh null ở View
            vm.volunteerNews = db.News
                .Include(n => n.Category)
                .Where(n => EF.Functions.Like(n.Category.Name, "%Tình nguyện%"))
                .OrderByDescending(n => n.CreatedAt)
                .Take(3)
                .ToList();

            return View("Index", vm);
        }
    }
}
