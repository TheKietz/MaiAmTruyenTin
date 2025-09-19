using MaiAmTruyenTin.Enums;
using MaiAmTruyenTin.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaiAmTruyenTin.ViewModels
{
    public class NewsVM
    {
        [DisplayName("Mã tin tức")]
        public int NewsId { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; } = null!;
        [DisplayName("Trạng thái")]
        public NewsStatus Status { get; set; } = NewsStatus.Draft;
        [Required]
        [DisplayName("Nội dung")]
        public string Content { get; set; } = null!;

        [DisplayName("Ảnh bìa")]
        public string? CoverImage { get; set; }

        [DisplayName("Chuyên mục")]
        public int? CategoryId { get; set; }

        [DisplayName("Tác giả")]
        public int? AuthorId { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Lượt xem")]
        public int ViewCount { get; set; } = 0;
       
        [DisplayName("Thời gian cập nhật")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        [DisplayName("Chuyên mục")]
        public string CategoryName { get; set; } = null!;

        [DisplayName("Mô tả ngắn")]
        [StringLength(500)]
        public string? Summary { get; set; }
        public virtual User? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<NewsImage> NewsImages { get; set; } = new List<NewsImage>();
    }
}
