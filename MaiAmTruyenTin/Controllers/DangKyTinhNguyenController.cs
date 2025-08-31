using MaiAmTruyenTin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaiAmTruyenTin.Controllers
{
    public class DangKyTinhNguyenController : Controller
    {
        private readonly KrbltdhcMaiamtruyentinContext db;
        public DangKyTinhNguyenController(KrbltdhcMaiamtruyentinContext context) => db = context;
        public IActionResult Index()
        {
            // Lấy 3 tin tức mới nhất thuộc chuyên mục "Tình nguyện"
            var tinhNguyenNews = db.News
                                .Include(n => n.Category)
                                .Where(n => EF.Functions.Like(n.Category.Name, "%Tình nguyện%"))
                                .OrderByDescending(n => n.CreatedAt)
                                .Take(3)
                                .ToList();
            // Tạo ViewModel
            var vm = new ViewModels.DangKyTinhNguyenVM
            {
                volunteerNews = tinhNguyenNews,
                volunteers = db.Volunteers.ToList()
            };
            return View(vm);
        }
    }
}
