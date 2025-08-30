using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;
using static MaiAmTruyenTin.ViewModels.TinTucVM;

namespace MaiAmTruyenTin.Controllers
{
    public class TinTucController : Controller
    {
        private readonly KrbltdhcMaiamtruyentinContext db;
        public TinTucController(KrbltdhcMaiamtruyentinContext context) => db = context;
        // GET: NewsController
        public  IActionResult Index(int? page)
        {
            int pageSize = 6; 
            int pageNumber = page==null||page<0 ? 1:page.Value;

            var data = db.News
             .Include(n => n.Category)
             .OrderByDescending(n => n.CreatedAt)
             .ToPagedList(pageNumber, pageSize);


            var newsCountByCategory = db.News
                        .GroupBy(n => n.Category.Name)
                        .Select(g => new NewsCategoryCountVM
                        {
                            CategoryName = g.Key,
                            NewsCount = g.Count()
                        })
                        .ToList();

            var vm = new TinTucVM
            {
                AllNewsPaged = data, // dùng pagedlist thay vì list
                RecentNews = db.News
                       .Include(n => n.Category)
                       .OrderByDescending(n => n.CreatedAt)
                       .Take(5)
                       .ToList(),
                NewsCountByCategory = newsCountByCategory
            };

            return View(vm);
        }


    }
}
