using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
namespace MaiAmTruyenTin.ViewModels
{
    public class DangKyTinhNguyenVM
    {
        public List<NewsVM> volunteerNews { get; set; } = new();
        public List<Volunteer> volunteers { get; set; } = new();
        public Volunteer NewVolunteer { get; set; } = new();
        public string callForVolunteers { get; set; }
    }
}