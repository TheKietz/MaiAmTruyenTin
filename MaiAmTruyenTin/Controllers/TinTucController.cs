using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;
using MaiAmTruyenTin.Enums;
using static MaiAmTruyenTin.ViewModels.TinTucVM;

namespace MaiAmTruyenTin.Controllers
{
    public class TinTucController : Controller
    {
        private readonly MaiamtruyentinContext db;
        public TinTucController(MaiamtruyentinContext context) => db = context;
        // GET: NewsController
        public IActionResult Index(int? page)
        {
            // Phân trang
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            // Lấy dữ liệu đã phân trang
            var data = db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved)
             .Include(n => n.Category)
             .OrderByDescending(n => n.CreatedAt)
             .ToPagedList(pageNumber, pageSize);

            // Đếm số lượng tin approved theo từng chuyên mục
            var newsCountByCategory = db.News
                        .Where(n => n.Status == Enums.NewsStatus.Approved)
                        .GroupBy(n => n.Category.Name)
                        .Select(g => new NewsCategoryCountVM
                        {
                            CategoryName = g.Key,
                            NewsCount = g.Count(),

                        })
                        .ToList();
            // Tạo ViewModel
            var vm = new TinTucVM
            {
                AllNewsPaged = data,
                RecentNews = db.News
                       .Include(n => n.Category)
                       .OrderByDescending(n => n.CreatedAt)
                       .Take(5)
                       .ToList(),
                NewsCountByCategory = newsCountByCategory
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            // Lấy chi tiết tin tức
            var news = db.News
                         .Include(n => n.Category)
                         .FirstOrDefault(n => n.NewsId == id);

            if (news == null)
                return NotFound();

            // lấy thêm tin liên quan
            var relatedNews = db.News
                                .Where(n => n.CategoryId == news.CategoryId && n.NewsId != news.NewsId)
                                .OrderByDescending(n => n.CreatedAt)
                                .Take(5)
                                .ToList();
            // Tạo ViewModel
            var vm = new NewsDetailVM
            {
                News = news,
                RelatedNews = relatedNews
            };

            return View(vm);
        }

    }
}
