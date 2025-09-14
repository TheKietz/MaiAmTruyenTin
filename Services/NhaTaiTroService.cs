
using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.EntityFrameworkCore;

public class NhaTaiTroService : INhaTaiTroService
{
    private readonly MaiamtruyentinContext _db;
    public NhaTaiTroService(MaiamtruyentinContext db)
    {
        _db = db;
    }

    public NhaTaiTroVM GetNhaTaiTroData()
    {
        var sponsors = _db.Sponsors
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
        var donations = (from sd in _db.SponsorDonations
                         join s in _db.Sponsors on sd.SponsorId equals s.SponsorId
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
        var relatedNews = _db.News
                            .Include(n => n.Category)
                            .Where(n => EF.Functions.Like(n.Category.Name, "%Nhà tài trợ%"))
                            .OrderByDescending(n => n.CreatedAt)
                            .Take(6)
                            .ToList();

        // 4. Tạo ViewModel tổng hợp
        return new NhaTaiTroVM
        {
            Sponsors = sponsors,
            Donations = donations,
            RelatedNews = relatedNews
        };
    }
}