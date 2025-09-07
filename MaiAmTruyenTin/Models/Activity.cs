using MaiAmTruyenTin.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaiAmTruyenTin.Models
{
    [Table("Activities")]
    public class Activity
    {
        [Key]
        [DisplayName("Mã hoạt động")]
        public int ActivityId { get; set; }

        [Required, StringLength(200)]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; } = null!;

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [StringLength(200)]
        [DisplayName("Địa điểm")]
        public string? Location { get; set; }

        [Required]
        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ActivityVolunteer> ActivityVolunteers { get; set; } = new List<ActivityVolunteer>();
    }

}
