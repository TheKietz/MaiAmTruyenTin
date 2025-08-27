using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class NewsImage
{
    public int ImageId { get; set; }

    public int? NewsId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? Caption { get; set; }

    public virtual News? News { get; set; }
}
