using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class TblUser
{
    public string Username { get; set; } = null!;

    public string? Pwd { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Email { get; set; }
    public string? LoginMethod { get; set; } = "Default";

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
