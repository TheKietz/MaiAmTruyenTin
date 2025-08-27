using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class UserToken
{
    public int TokenId { get; set; }

    public int? UserId { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsRevoked { get; set; }

    public virtual User? User { get; set; }
}
