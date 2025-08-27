using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class ActivityVolunteer
{
    public int Id { get; set; }

    public int? ActivityId { get; set; }

    public int? VolunteerId { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public string? Status { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual Volunteer? Volunteer { get; set; }
}
