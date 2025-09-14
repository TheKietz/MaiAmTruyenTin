using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using Microsoft.EntityFrameworkCore;

public class DangKyTinhNguyenService : IDangKyTinhNguyenService
{
    private readonly MaiamtruyentinContext _db;
    public DangKyTinhNguyenService(MaiamtruyentinContext db) => _db = db;

    public List<News> GetLatestVolunteerNews(int take = 3)
    {
        return _db.News
            .Include(n => n.Category)
            .Where(n => EF.Functions.Like(n.Category.Name, "%Tình nguyện%"))
            .OrderByDescending(n => n.CreatedAt)
            .Take(take)
            .ToList();
    }

    public async Task<bool> IsEmailUsedAsync(string email)
    {
        return await _db.Volunteers.AnyAsync(v => v.Email == email);
    }

    public async Task<bool> IsPhoneUsedAsync(string phone)
    {
        return await _db.Volunteers.AnyAsync(v => v.Phone == phone);
    }

    public async Task AddVolunteerAsync(Volunteer volunteer)
    {
        volunteer.CreatedAt = DateTime.Now;
        volunteer.UpdatedAt = DateTime.Now;
        volunteer.IsDeleted = false;

        _db.Volunteers.Add(volunteer);
        await _db.SaveChangesAsync();
    }
}
