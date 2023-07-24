using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Pmdup
{
    public string? FleetId { get; set; }

    public double? Smu { get; set; }

    public string? Service { get; set; }

    public DateTime? Date { get; set; }

    public string? Model { get; set; }
}
