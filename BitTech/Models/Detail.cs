using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Detail
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DetailRequest> DetailRequests { get; set; } = new List<DetailRequest>();
}
