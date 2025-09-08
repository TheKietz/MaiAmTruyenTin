using System.ComponentModel.DataAnnotations;
namespace MaiAmTruyenTin.Enums
{
    public enum UserRole
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Người đóng góp")]
        Contributor,
        [Display(Name = "Người dùng")]
        User,
       
    }
    public enum StudentGender
    {
        [Display(Name = "Nam")]
        Male,
        [Display(Name = "Nữ")]
        Female,
        [Display(Name = "Khác")]
        Other
    }
    public enum NewsStatus
    {
        [Display(Name = "Nháp")]
        Draft,

        [Display(Name = "Chờ duyệt")]
        Pending,

        [Display(Name = "Đã duyệt")]
        Approved,

        [Display(Name = "Từ chối")]
        Rejected
    }
    public enum ActivityVolunteersStatus
    {
        [Display(Name = "Đang chờ")]
        Pending,
        [Display(Name = "Được duyệt")]
        Approved,
        [Display(Name = "Từ chối")]
        Rejected
    }
    public enum BannerPosition
    {
        HOMEPAGE_TOP, SIDEBAR, FOOTER
    }
   
}
