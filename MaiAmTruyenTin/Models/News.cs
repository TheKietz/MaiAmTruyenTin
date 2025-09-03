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

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        // Navigation
        public virtual User? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<NewsImage> NewsImages { get; set; } = new List<NewsImage>();
    }
}
