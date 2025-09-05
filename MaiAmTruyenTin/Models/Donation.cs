using MaiAmTruyenTin.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("Donations")]
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        public int? UserId { get; set; }

        [Required]
        [DisplayName("Số tiền")]
        public decimal Amount { get; set; }

        [DisplayName("Ngày ủng hộ")]
        public DateTime? DonationDate { get; set; } = DateTime.Now;

        [StringLength(255)]
        [DisplayName("Ghi chú")]
        public string? Note { get; set; }

        [DisplayName("Phương thức thanh toán")]
        public string? PaymentMethod { get; set; }

        public virtual User? User { get; set; }
    }
}
