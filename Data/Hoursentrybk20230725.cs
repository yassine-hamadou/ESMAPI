using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Hoursentrybk20230725
{
    public int Id { get; set; }

    public string? FleetId { get; set; }

    public DateTime? Date { get; set; }

    public double? PreviousReading { get; set; }

    public double? CurrentReading { get; set; }

    public string? TenantId { get; set; }

    public int? Adjustment { get; set; }

    public string? Comment { get; set; }

    public DateTime? PreviousReadingDate { get; set; }
}
