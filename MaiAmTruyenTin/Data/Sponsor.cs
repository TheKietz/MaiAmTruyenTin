using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class Sponsor
{
    public int SponsorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Representative { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? SponsorType { get; set; }

    public string? Logo { get; set; }

    public string? Website { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual ICollection<SponsorDonation> SponsorDonations { get; set; } = new List<SponsorDonation>();

    public virtual User? UpdatedByNavigation { get; set; }
}
