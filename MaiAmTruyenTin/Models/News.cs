using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        [DisplayName("Mã tin tức")]
        public int NewsId { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; } = null!;

        [Required]
        [DisplayName("Nội dung")]
        public string Content { get; set; } = null!;

        [DisplayName("Ảnh bìa")]
        public string? CoverImage { get; set; }

        [DisplayName("Chuyên mục")]
        public int? CategoryId { get; set; }

        [DisplayName("Tác giả")]
        public int? AuthorId { get; set; }

        [Required]
        [DisplayName("Trạng thái")]
        public NewsStatus Status { get; set; } = NewsStatus.Draft;

        [DisplayName("Lượt xem")]
        public int ViewCount { get; set; } = 0;
        [DisplayName("Thời gian tạo")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [DisplayName("Người tạo")]
        public int? CreatedBy { get; set; }
        [DisplayName("Thời gian cập nhật")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        [DisplayName("Người cập nhật")]
        public int? UpdatedBy { get; set; }
        [DisplayName("Xóa")]
        public bool IsDeleted { get; set; } = false;
        [DisplayName("Người xóa")]
        public int? DeletedBy { get; set; }
        [DisplayName("Ngày xóa")]
        public DateTime? DeletedAt { get; set; }
        [DisplayName("Người duyệt")]
        public int? ApprovedBy { get; set; }
        [DisplayName("Ngày duyệt")]
        public DateTime? ApprovedAt { get; set; }
        
        [DisplayName("Mô tả ngắn")]
        [StringLength(500)]
        public string? Summary { get; set; }

        // Navigation
        public virtual User? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<NewsImage> NewsImages { get; set; } = new List<NewsImage>();
    }
}
