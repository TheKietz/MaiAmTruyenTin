using MaiAmTruyenTin.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MaiAmTruyenTin.Models
{
    [Table("Volunteers")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class Volunteer
    {
        [Key]
        [DisplayName("Mã tình nguyện viên")]
        public int VolunteerId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; } = null!;

        [StringLength(100)]
        [EmailAddress]
        [DisplayName("Email")]
        public string? Email { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string? Phone { get; set; }

        [DisplayName("Ngày tham gia")]
        public DateTime? JoinDate { get; set; } = DateTime.Now;

        [StringLength(255)]
        [DisplayName("Kỹ năng")]
        public string? Skills { get; set; }

        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ActivityVolunteer> ActivityVolunteers { get; set; } = new List<ActivityVolunteer>();
    }
}