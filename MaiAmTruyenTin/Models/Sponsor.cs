using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MaiAmTruyenTin.Models
{
    [Table("Sponsors")]
    public class Sponsor
    {
        [Key]
        [DisplayName("Mã nhà tài trợ")]
        public int SponsorId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Tên tổ chức/cá nhân")]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        [DisplayName("Người đại diện")]
        public string? Representative { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }

        [StringLength(50)]
        [DisplayName("Loại hình tài trợ")]
        public string? SponsorType { get; set; }

        [StringLength(255)]
        [DisplayName("Logo")]
        public string? Logo { get; set; }

        [StringLength(255)]
        [DisplayName("Website")]
        public string? Website { get; set; }

        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SponsorDonation> SponsorDonations { get; set; } = new List<SponsorDonation>();
    }
}
