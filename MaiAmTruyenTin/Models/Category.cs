using MaiAmTruyenTin.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DisplayName("Mã chuyên mục")]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Tên chuyên mục")]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();
    }
}
