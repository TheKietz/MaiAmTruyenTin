using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    public class StaticPage
    {
        [Key]
        public int PageId { get; set; }

        [Required(ErrorMessage = "Slug là bắt buộc")]
        [StringLength(100, ErrorMessage = "Slug không được vượt quá 100 ký tự")]
        [Display(Name = "Đường dẫn (Slug)")]
        public string Slug { get; set; } = null!; 

        [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tiêu đề không được vượt quá 255 ký tự")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; } = null!;

        [Display(Name = "Ảnh bìa")]
        [StringLength(255, ErrorMessage = "Đường dẫn ảnh không được vượt quá 255 ký tự")]
        public string? CoverImage { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsVisible { get; set; } = true;

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CreatedByUser")]
        [Display(Name = "Người tạo")]
        public int? CreatedBy { get; set; }
        public virtual User? CreatedByUser { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("UpdatedByUser")]
        [Display(Name = "Người cập nhật")]
        public int? UpdatedBy { get; set; }
        public virtual User? UpdatedByUser { get; set; }

        [Display(Name = "Đã xóa")]
        public bool isDeleted { get; set; } = false;

        [ForeignKey("DeletedByUser")]
        [Display(Name = "Người xóa")]
        public int? DeletedBy { get; set; }
        public virtual User? DeletedByUser { get; set; }

        [Display(Name = "Ngày xóa")]
        public DateTime? DeletedAt { get; set; }
    }
}
