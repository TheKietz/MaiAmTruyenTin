using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Controllers
{
    public class DangKyTinhNguyenController : Controller
    {
        private readonly IDangKyTinhNguyenService _service;

        public DangKyTinhNguyenController(IDangKyTinhNguyenService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            // Lấy 3 tin tức mới nhất thuộc chuyên mục "Tình nguyện"
            var vm = new DangKyTinhNguyenVM
            {
                volunteerNews = _service.GetLatestVolunteerNews(),
                NewVolunteer = new Volunteer()
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
                       await _service.IsEmailUsedAsync(vm.NewVolunteer.Email))
            {
                ModelState.AddModelError("NewVolunteer.Email", "Email đã được sử dụng!");
            }

            if (!string.IsNullOrEmpty(vm.NewVolunteer.Phone) &&
                await _service.IsPhoneUsedAsync(vm.NewVolunteer.Phone))
            {
                ModelState.AddModelError("NewVolunteer.Phone", "Số điện thoại đã được sử dụng!");
            }

            if (ModelState.IsValid)
            {
                await _service.AddVolunteerAsync(vm.NewVolunteer);
                TempData["SuccessMessage"] = "Đăng ký tình nguyện thành công!";
                return RedirectToAction("Index");
            }

            vm.volunteerNews = _service.GetLatestVolunteerNews();
            return View("Index", vm);
        }
    }
}
