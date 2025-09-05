using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  MaiAmTruyenTin.Enums;
namespace MaiAmTruyenTin.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DisplayName("Mã học sinh")]
        public int StudentId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; } = null!;

        [DisplayName("Giới tính")]
        public StudentGender Gender { get; set; } = StudentGender.Other;

        [Required]
        [DisplayName("Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Tình trạng sức khỏe")]
        public string? HealthStatus { get; set; }

        [DisplayName("Lớp học")]
        public string? Class { get; set; }

        [DisplayName("Ngày vào mái ấm")]
        public DateTime? AdmissionDate { get; set; }

        [DisplayName("Người bảo trợ")]
        public string? GuardianName { get; set; }

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