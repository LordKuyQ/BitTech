using System;
using System.Collections.Generic;

namespace BitTech.Models;

public partial class Operator
{
    public long Id { get; set; }

    public string? Fio { get; set; }

    public long? Phone { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
