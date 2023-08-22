using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class HoursEntry
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

    public string EntrySource { get; set; } = null!;

    public virtual Equipment? Fleet { get; set; }
}
