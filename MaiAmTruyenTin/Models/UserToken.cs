using MaiAmTruyenTin.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MaiAmTruyenTin.Models
{
    [Table("UserTokens")]
    public class UserToken
    {
        [Key]
        public int TokenId { get; set; }

        public int UserId { get; set; }

        [Required, StringLength(500)]
        [DisplayName("Refresh Token")]
        public string RefreshToken { get; set; } = null!;

        [DisplayName("Ngày hết hạn")]
        public DateTime ExpiryDate { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Đã thu hồi?")]
        public bool IsRevoked { get; set; } = false;

        public virtual User? User { get; set; }
    }
}