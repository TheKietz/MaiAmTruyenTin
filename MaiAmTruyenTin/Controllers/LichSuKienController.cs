using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace MaiAmTruyenTin.Controllers
{
    public class LichSuKienController : Controller
    {
        private readonly MaiamtruyentinContext _context;

        public LichSuKienController(MaiamtruyentinContext context)
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

        public IActionResult Index(string? keyword, int? categoryId)
        {
            var categories = _context.Categories.ToList();

            // Lấy tất cả sự kiện trước, bao gồm cả Category
            var events = _context.Events.Include(e => e.Category).ToList();

            // Tìm kiếm (lọc trên bộ nhớ, không phải SQL)
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

            var vm = new LichSuKienVM
            {
                Events = events.OrderBy(e => e.StartDate).ToList(),
                Keyword = keyword,
                SelectedCategory = categoryId?.ToString(),
                Categories = categories.ToDictionary(c => c.CategoryId, c => c.Name)
            };

            return View(vm);
        }


        // Trả dữ liệu JSON cho FullCalendar
        public IActionResult GetEvents()
        {
            var events = _context.Events.Select(e => new
            {
                title = e.Title,
                start = e.StartDate.ToString("yyyy-MM-dd"), // ISO 8601
                id = e.EventId,
                category = e.Category.Name
            }).ToList();

            return Json(events);
        }
    }
}
