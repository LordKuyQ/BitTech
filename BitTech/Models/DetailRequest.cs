using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class DetailRequest
{
    public long Id { get; set; }

    public long? RequestId { get; set; }

    public long? DetailId { get; set; }

    public virtual Detail? Detail { get; set; }

    public virtual Request? Request { get; set; }
}
