using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaiAmTruyenTin.Enums;

namespace MaiAmTruyenTin.Models
{
    [Table("ActivityVolunteers")]
    public class ActivityVolunteer
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Hoạt động")]
        public int ActivityId { get; set; }

        [DisplayName("Tình nguyện viên")]
        public int VolunteerId { get; set; }

        [DisplayName("Ngày đăng ký")]
        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        [DisplayName("Trạng thái")]
        public ActivityVolunteersStatus Status { get; set; } = ActivityVolunteersStatus.Approved;

        public virtual Activity? Activity { get; set; }
        public virtual Volunteer? Volunteer { get; set; }
    }
}
