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
            // Lấy dữ liệu phân trang cho tin tức đã phê duyệt
            var newsDataQuery = db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved)
                .Include(n => n.Category);
            // Lấy dữ liệu đã phân trang
            var data = newsDataQuery
                .Select(n => new NewsVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    Content = n.Content,
                    CoverImage = n.CoverImage,
                    CategoryId = n.CategoryId,
                    AuthorId = n.AuthorId,
                    ViewCount = n.ViewCount,
                    CreatedAt = n.CreatedAt,
                    Summary = n.Summary
                })
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
            // Lấy tin sự kiện sắp diễn ra
            var eventCategoryId = db.Categories
                .Where(c => EF.Functions.Like(c.Name, "%Sự kiện%"))
                .Select(c => c.CategoryId)
                .FirstOrDefault();

            var eventNews = db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved && n.CategoryId == eventCategoryId)
                .OrderByDescending(n => n.CreatedAt)
                .Join(db.Categories,
                    n => n.CategoryId,
                    c => c.CategoryId,
                    (n, c) => new { News = n, CategoryName = c.Name })
                .Take(3)
                .Select(nc => new NewsVM
                {
                    NewsId = nc.News.NewsId,
                    Title = nc.News.Title,
                    Content = nc.News.Content,
                    CoverImage = nc.News.CoverImage,
                    CategoryId = nc.News.CategoryId,
                    AuthorId = nc.News.AuthorId,
                    ViewCount = nc.News.ViewCount,
                    CreatedAt = nc.News.CreatedAt,
                    Summary = nc.News.Summary,
                    CategoryName = nc.CategoryName 
                })
                .ToList();
            // Lấy tin mới nhất
            var recentNews = db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved)
                .Include(n => n.Category)
                .Select(n => new NewsVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    Status = n.Status,
                    CoverImage = n.CoverImage,
                    CreatedAt = n.CreatedAt
                })
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .ToList();
            // Tạo ViewModel
            var vm = new TinTucVM
            {
                AllNewsPaged = data,
                RecentNews = recentNews,
                NewsCountByCategory = newsCountByCategory,
                EventNews = eventNews,
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            // Lấy chi tiết tin tức
            var news = db.News
                .Include(n => n.Category)
                .Select(n => new NewsVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    Status = n.Status,
                    Content = n.Content,
                    CoverImage = n.CoverImage,
                    CategoryId = n.CategoryId,
                    AuthorId = n.AuthorId,
                    ViewCount = n.ViewCount,
                    CreatedAt = n.CreatedAt,
                    Summary = n.Summary
                })
                .FirstOrDefault(n => n.NewsId == id);

            if (news == null)
                return NotFound();

            // lấy thêm tin liên quan
            var relatedNews = db.News
                .Where(n => n.CategoryId == news.CategoryId && n.NewsId != news.NewsId)
                .Select(n => new NewsVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    CoverImage = n.CoverImage,
                    CreatedAt = n.CreatedAt
                })
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
