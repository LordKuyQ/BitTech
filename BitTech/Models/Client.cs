using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Client
{
    public long UserId { get; set; }

    public string? Fio { get; set; }

    public long? Phone { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
