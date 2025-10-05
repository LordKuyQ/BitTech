using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Equipment
{
    public long Id { get; set; }

    public string? HomeTechType { get; set; }

    public string? HomeTechModel { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
