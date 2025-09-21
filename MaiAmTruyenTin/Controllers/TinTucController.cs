using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Enums;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;
using static MaiAmTruyenTin.ViewModels.TinTucVM;

namespace MaiAmTruyenTin.Controllers
{
    public class TinTucController : Controller
    {
        private readonly MaiamtruyentinContext db;
        public TinTucController(MaiamtruyentinContext context) => db = context;

        // GET: NewsController
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            // Lấy dữ liệu phân trang cho tin tức đã phê duyệt
            var newsDataQuery = db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved)
                .Include(n => n.Category);

            // EF Core không hỗ trợ trực tiếp ToPagedListAsync => cần lấy list trước rồi paged
            var allNews = await newsDataQuery
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
                .ToListAsync();

            var data = allNews.ToPagedList(pageNumber, pageSize);

            // Đếm số lượng tin approved theo từng chuyên mục
            var newsCountByCategory = await db.News
                .Where(n => n.Status == Enums.NewsStatus.Approved)
                .GroupBy(n => n.Category.Name)
                .Select(g => new NewsCategoryCountVM
                {
                    CategoryName = g.Key,
                    NewsCount = g.Count(),
                })
                .ToListAsync();

            // Lấy tin sự kiện sắp diễn ra
            var eventCategoryId = await db.Categories
                .Where(c => EF.Functions.Like(c.Name, "%Sự kiện%"))
                .Select(c => c.CategoryId)
                .FirstOrDefaultAsync();

            var eventNews = await db.News
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
                .ToListAsync();

            // Lấy tin mới nhất
            var recentNews = await db.News
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
                .ToListAsync();

            var vm = new TinTucVM
            {
                AllNewsPaged = data,
                RecentNews = recentNews,
                NewsCountByCategory = newsCountByCategory,
                EventNews = eventNews,
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var news = await db.News
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
                .FirstOrDefaultAsync(n => n.NewsId == id);

            if (news == null)
                return NotFound();

            var relatedNews = await db.News
                .Where(n => n.CategoryId == news.CategoryId && n.NewsId != news.NewsId)
                .Select(n => new NewsVM
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    AuthorName = n.Author != null ? n.Author.FullName : "Không rõ",
                    CategoryName = n.Category != null ? n.Category.Name : "Chưa phân loại",
                    CoverImage = n.CoverImage,
                    CreatedAt = n.CreatedAt
                })
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .ToListAsync();

            var vm = new NewsDetailVM
            {
                News = news,
                RelatedNews = relatedNews
            };

            return View(vm);
        }
    }
}
