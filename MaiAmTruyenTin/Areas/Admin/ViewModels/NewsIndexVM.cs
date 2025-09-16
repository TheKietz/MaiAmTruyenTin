using System.ComponentModel.DataAnnotations;
using MaiAmTruyenTin.Enums;

namespace MaiAmTruyenTin.Areas.Admin.ViewModels
{
    public class NewsIndexVM
    {
        [Key]
        public int NewsId { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string CoverImage { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Vui lòng nhập trạng thái")] 
        public NewsStatus Status { get; set; } = NewsStatus.Pending;
        [Display(Name = "Tên tác giả")]
        public string AuthorName { get; set; }
        [Display(Name = "Loại bài viết")]
        public string CategoryName { get; set; }
    }
    
}
