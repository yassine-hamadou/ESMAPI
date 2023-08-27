using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProDailyOverview
{
    public int Id { get; set; }

    public int? NumberOfIncidents { get; set; }

    public int? HrsLostToRain { get; set; }

    public int? RainfallMm { get; set; }

    public string? Remarks { get; set; }

    public string? TenantId { get; set; }

    public DateTime? OverviewDate { get; set; }
}
