// Service interface
using MaiAmTruyenTin.Models;

public interface IDangKyTinhNguyenService
{
    List<News> GetLatestVolunteerNews(int take = 3);
    Task<bool> IsEmailUsedAsync(string email);
    Task<bool> IsPhoneUsedAsync(string phone);
    Task AddVolunteerAsync(Volunteer volunteer);
}