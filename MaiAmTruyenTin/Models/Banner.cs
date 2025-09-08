using MaiAmTruyenTin.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("Banners")]
    public class Banner
    {
        [Key]
        [DisplayName("ID banner")]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Tiêu đề banner")]
        public string Title { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Url banner")]
        public string ImageUrl { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ url banner")]
        public string LinkUrl { get; set; }

        [Required]
        [DisplayName("Vị trí banner")]
        public BannerPosition Position { get; set; } = BannerPosition.HOMEPAGE_TOP;

        [DisplayName("Trạng thái banner")]
        public bool IsActive { get; set; } = true;

        [DisplayName("Thứ tự hiển thị")]
        public int DisplayOrder { get; set; } = 0;

        [DisplayName("Ngày bắt đầu hiển thị")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Ngày kết thúc hiển thị")]
        public DateTime? EndDate { get; set; }
    }
}
