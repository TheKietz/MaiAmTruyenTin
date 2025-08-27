using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class Volunteer
{
    public int VolunteerId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? JoinDate { get; set; }

    public string? Skills { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ActivityVolunteer> ActivityVolunteers { get; set; } = new List<ActivityVolunteer>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
