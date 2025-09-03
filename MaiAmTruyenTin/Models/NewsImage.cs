using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("NewsImages")]
    public class NewsImage
    {
        [Key]
        [DisplayName("Mã ảnh")]
        public int ImageId { get; set; }

        [Required]
        public int NewsId { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Đường dẫn ảnh")]
        public string ImagePath { get; set; } = null!;

        [StringLength(255)]
        [DisplayName("Chú thích")]
        public string? Caption { get; set; }

        public virtual News? News { get; set; }
    }
}