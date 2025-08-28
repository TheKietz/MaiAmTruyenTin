using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Activity> ActivityCreatedByNavigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityDeletedByNavigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityUpdatedByNavigations { get; set; } = new List<Activity>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<Founder> FounderCreatedByNavigations { get; set; } = new List<Founder>();

    public virtual ICollection<Founder> FounderDeletedByNavigations { get; set; } = new List<Founder>();

    public virtual ICollection<Founder> FounderUpdatedByNavigations { get; set; } = new List<Founder>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseDeletedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUpdatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<News> NewsApprovedByNavigations { get; set; } = new List<News>();

    public virtual ICollection<News> NewsAuthors { get; set; } = new List<News>();

    public virtual ICollection<News> NewsCreatedByNavigations { get; set; } = new List<News>();

    public virtual ICollection<News> NewsDeletedByNavigations { get; set; } = new List<News>();

    public virtual ICollection<News> NewsUpdatedByNavigations { get; set; } = new List<News>();

    public virtual ICollection<Sponsor> SponsorCreatedByNavigations { get; set; } = new List<Sponsor>();

    public virtual ICollection<Sponsor> SponsorDeletedByNavigations { get; set; } = new List<Sponsor>();

    public virtual ICollection<Sponsor> SponsorUpdatedByNavigations { get; set; } = new List<Sponsor>();

    public virtual ICollection<Student> StudentCreatedByNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentDeletedByNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentUpdatedByNavigations { get; set; } = new List<Student>();

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

    public virtual ICollection<Volunteer> VolunteerCreatedByNavigations { get; set; } = new List<Volunteer>();

    public virtual ICollection<Volunteer> VolunteerDeletedByNavigations { get; set; } = new List<Volunteer>();

    public virtual ICollection<Volunteer> VolunteerUpdatedByNavigations { get; set; } = new List<Volunteer>();
}
