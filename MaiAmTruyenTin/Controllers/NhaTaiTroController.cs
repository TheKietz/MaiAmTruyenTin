using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MaiAmTruyenTin.Controllers
{
    public class NhaTaiTroController : Controller
    {
        private readonly MaiamtruyentinContext db;
        public NhaTaiTroController(MaiamtruyentinContext context) => db = context;

        public IActionResult Index()
        {
            // 1. Lấy danh sách Sponsor (tên + logo + ghi chú)
            var sponsors = db.Sponsors
                             .Select(s => new SponsorVM
                             {
                                 SponsorId = s.SponsorId,
                                 Name = s.Name,
                                 Logo = s.Logo,
                                 Website = s.Website,
                                 Notes = s.Notes
                             })
                             .ToList();

            // 2. Lấy danh sách Donate từ SponsorDonations
            var donations = (from sd in db.SponsorDonations
                             join s in db.Sponsors on sd.SponsorId equals s.SponsorId
                             orderby sd.DonationDate descending
                             select new SponsorDonationVM
                             {
                                 SponsorName = s.Name,
                                 Amount = sd.Amount,
                                 DonationDate = sd.DonationDate,
                                 Purpose = sd.Purpose,
                                 Note = sd.Note
                             }).ToList();

            // 3. Lấy tin tức liên quan đến nhà tài trợ
            var relatedNews = db.News
                                .Include(n => n.Category)
                                .Where(n => EF.Functions.Like(n.Category.Name, "%Nhà tài trợ%"))
                                .OrderByDescending(n => n.CreatedAt)
                                .Take(6)
                                .ToList();

            // 4. Tạo ViewModel tổng hợp
            var vm = new NhaTaiTroVM
            {
                Sponsors = sponsors,
                Donations = donations,
                RelatedNews = relatedNews
            };

            return View(vm);
        }
    }
}
