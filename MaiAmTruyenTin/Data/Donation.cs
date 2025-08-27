using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class Donation
{
    public int DonationId { get; set; }

    public int? UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? DonationDate { get; set; }

    public string? Note { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual User? User { get; set; }
}
