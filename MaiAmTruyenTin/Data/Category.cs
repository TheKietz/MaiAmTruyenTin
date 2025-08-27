using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
