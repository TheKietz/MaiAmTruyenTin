using System.Globalization;
using System.Text;
using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.EntityFrameworkCore;

public class LichSuKienService : ILichSuKienService
{
    private readonly MaiamtruyentinContext _context;

    public LichSuKienService(MaiamtruyentinContext context)
    {
        _context = context;
    }

    // Xóa dấu tiếng Việt
    private string RemoveDiacritics(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        var normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var ch in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    public LichSuKienVM GetLichSuKienData(string? keyword, int? categoryId)
    {
        var categories = _context.Categories.ToList();
        var events = _context.Events.Include(e => e.Category).ToList();

        // Tìm kiếm
        if (!string.IsNullOrEmpty(keyword))
        {
            string kw = RemoveDiacritics(keyword).ToLower();
            events = events.Where(e =>
                RemoveDiacritics(e.Title).ToLower().Contains(kw) ||
                (!string.IsNullOrEmpty(e.Description) && RemoveDiacritics(e.Description).ToLower().Contains(kw))
            ).ToList();
        }

        // Lọc theo danh mục
        if (categoryId.HasValue && categoryId.Value > 0)
        {
            events = events.Where(e => e.CategoryId == categoryId.Value).ToList();
        }

        return new LichSuKienVM
        {
            Events = events.OrderBy(e => e.StartDate).ToList(),
            Keyword = keyword,
            SelectedCategory = categoryId?.ToString(),
            Categories = categories.ToDictionary(c => c.CategoryId, c => c.Name)
        };
    }

    public List<object> GetEventsForCalendar()
    {
        return _context.Events.Select(e => new
        {
            title = e.Title,
            start = e.StartDate.ToString("yyyy-MM-dd"),
            id = e.EventId,
            category = e.Category.Name
        }).Cast<object>().ToList();
    }

    LichSuKienVM ILichSuKienService.GetLichSuKienData(string? keyword, int? categoryId)
    {
        throw new NotImplementedException();
    }
}