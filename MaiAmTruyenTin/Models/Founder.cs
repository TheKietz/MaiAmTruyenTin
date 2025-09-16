using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{

    [Table("Founders")]
    public class Founder
    {
        [Key]
        [DisplayName("Mã nhà sáng lập")]
        public int FounderId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; } = null!;

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string? Phone { get; set; }

        [StringLength(100)]
        [DisplayName("Vai trò")]
        public string? Role { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string? Avarta { get; set; }

        [StringLength(255)]
        [DisplayName("Đóng góp")]
        public string? Contribution { get; set; }

        [DisplayName("Ngày tham gia")]
        public DateTime? FoundedDate { get; set; }

        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

}