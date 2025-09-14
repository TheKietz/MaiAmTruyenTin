using MaiAmTruyenTin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MaiAmTruyenTin.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DisplayName("Mã người dùng")]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; } = null!;

        [Required, StringLength(100)]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string? Phone { get; set; }

        [Required, StringLength(255)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; } = null!;

        [Required, StringLength(20)]
        [DisplayName("Vai trò")]
        public UserRole Role { get; set; } = UserRole.Contributor;

        [DisplayName("Ngày tạo")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Người tạo")]
        public int? CreatedBy { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [DisplayName("Người cập nhật")]
        public int? UpdatedBy { get; set; }

        [DisplayName("Đã xóa?")]
        public bool IsDeleted { get; set; } = false;

        [DisplayName("Người xóa")]
        public int? DeletedBy { get; set; }

        [DisplayName("Ngày xóa")]
        public DateTime? DeletedAt { get; set; }

        // Navigation
        public virtual ICollection<News> News { get; set; } = new List<News>();
        public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}