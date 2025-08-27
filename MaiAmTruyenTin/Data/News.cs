using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class News
{
    public int NewsId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? CoverImage { get; set; }

    public int? CategoryId { get; set; }

    public int? AuthorId { get; set; }

    public string Status { get; set; } = null!;

    public int? ViewCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual User? Author { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? DeletedByNavigation { get; set; }

    public virtual ICollection<NewsImage> NewsImages { get; set; } = new List<NewsImage>();

    public virtual User? UpdatedByNavigation { get; set; }
}
