using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Comment
{
    public long CommentId { get; set; }

    public string? Message { get; set; }

    public long? MasterId { get; set; }

    public long? RequestId { get; set; }

    public virtual Master? Master { get; set; }

    public virtual Request? Request { get; set; }
}
