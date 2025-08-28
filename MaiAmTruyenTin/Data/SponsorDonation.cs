using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class SponsorDonation
{
    public int DonationId { get; set; }

    public int? SponsorId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? DonationDate { get; set; }

    public string? Purpose { get; set; }

    public string? Note { get; set; }

    public virtual Sponsor? Sponsor { get; set; }
}
