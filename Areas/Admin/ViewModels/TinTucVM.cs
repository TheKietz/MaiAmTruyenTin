using System.ComponentModel.DataAnnotations;
using MaiAmTruyenTin.Enums;

namespace MaiAmTruyenTin.Areas.Admin.ViewModels
{
    public class TinTucVM
    {
        [Key]
        public int NewsId { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string? CoverImage { get; set; }

        [Display(Name = "Chuyên mục")]
        public int? CategoryId { get; set; }

        [Display(Name = "Tác giả")]
        public int? AuthorId { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Vui lòng nhập trạng thái")]
        public NewsStatus Status { get; set; } = NewsStatus.Draft;

        [Display(Name = "Lượt xem")]
        public int? ViewCount { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Người tạo")]
        public int? CreatedBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Người cập nhật")]
        public int? UpdatedBy { get; set; }

        [Display(Name = "Đã xóa")]
        public bool? IsDeleted { get; set; }

        [Display(Name = "Người xóa")]
        public int? DeletedBy { get; set; }

        [Display(Name = "Ngày xóa")]
        public DateTime? DeletedAt { get; set; }

        [Display(Name = "Người duyệt")]
        public int? ApprovedBy { get; set; }

        [Display(Name = "Ngày duyệt")]
        public DateTime? ApprovedAt { get; set; }
        [Display(Name = "Tác giả")]
        public string AuthorName { get; set; }
        [Display(Name = "Loại tin tức")]
        public string CategoryName { get; set; }
    }
}
