using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using static MaiAmTruyenTin.ViewModels.TinTucVM;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

public class TinTucService : ITinTucService
{

    private readonly MaiamtruyentinContext _db;
    public TinTucService(MaiamtruyentinContext db)
    {
        _db = db;
    }

    public TinTucVM GetPagedNews(int? page)
    {
        // Phân trang
        int pageSize = 6;
        int pageNumber = page == null || page < 0 ? 1 : page.Value;
        // Lấy dữ liệu đã phân trang
        var data = _db.News
            .Where(n => n.Status == MaiAmTruyenTin.Enums.NewsStatus.Approved)
         .Include(n => n.Category)
         .OrderByDescending(n => n.CreatedAt)
         .ToPagedList(pageNumber, pageSize);

        // Đếm số lượng tin approved theo từng chuyên mục
        var newsCountByCategory = _db.News
                    .Where(n => n.Status == MaiAmTruyenTin.Enums.NewsStatus.Approved)
                    .GroupBy(n => n.Category.Name)
                    .Select(g => new NewsCategoryCountVM
                    {
                        CategoryName = g.Key,
                        NewsCount = g.Count(),

                    })
                    .ToList();

        return new TinTucVM
        {
            AllNewsPaged = data,
            RecentNews = _db.News
                   .Include(n => n.Category)
                   .OrderByDescending(n => n.CreatedAt)
                   .Take(5)
                   .ToList(),
            NewsCountByCategory = newsCountByCategory
        };
    }

    public NewsDetailVM GetNewsDetail(int id)
    {
        // Lấy chi tiết tin tức
        var news = _db.News
                     .Include(n => n.Category)
                     .FirstOrDefault(n => n.NewsId == id);

        if (news == null)
            return null;

        // lấy thêm tin liên quan
        var relatedNews = _db.News
                            .Where(n => n.CategoryId == news.CategoryId && n.NewsId != news.NewsId)
                            .OrderByDescending(n => n.CreatedAt)
                            .Take(5)
                            .ToList();
        // Tạo ViewModel
        return new NewsDetailVM
        {
            News = news,
            RelatedNews = relatedNews
        };
    }


}