using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MaiAmTruyenTin.Models
{
    [Table("SponsorDonations")]
    public class SponsorDonation
    {
        [Key]
        [DisplayName("Mã tài trợ")]
        public int DonationId { get; set; }

        public int SponsorId { get; set; }

        [Required]
        [DisplayName("Số tiền")]
        public decimal Amount { get; set; }

        [DisplayName("Ngày tài trợ")]
        public DateTime? DonationDate { get; set; } = DateTime.Now;

        [StringLength(255)]
        [DisplayName("Mục đích")]
        public string? Purpose { get; set; }

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }

        public virtual Sponsor? Sponsor { get; set; }
    }
}