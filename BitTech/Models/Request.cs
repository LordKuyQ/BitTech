using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Request
{
    public long RequestId { get; set; }

    public DateOnly? StartDate { get; set; }

    public long? EquipmentId { get; set; }

    public string? ProblemDescryption { get; set; }

    public string? RequestStatus { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public long? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<DetailRequest> DetailRequests { get; set; } = new List<DetailRequest>();

    public virtual Equipment? Equipment { get; set; }
}
