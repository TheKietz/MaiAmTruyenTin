using System.ComponentModel.DataAnnotations;

namespace MaiAmTruyenTin.ViewModels
{
    public class FounderVM
    {
        [Display(Name = "Ảnh đại diện")]
        public string Avarta { get; set; }
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
        [Display(Name = "Vai trò")]
        public string Role { get; set; }
        [Display(Name = "Thông tin")]
        public string Notes { get; set; }
        [Display(Name = "Các đóng góp")]
        public string Contribution { get; set; }
    }
}
