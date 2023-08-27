namespace ServiceManagerApi.Dtos.ProDailyOverview;

public class ProDailyOverviewDto
{
    public int? NumberOfIncidents { get; set; }

    public int? HrsLostToRain { get; set; }

    public int? RainfallMm { get; set; }

    public string? Remarks { get; set; }

    public string? TenantId { get; set; }

    public DateTime? OverviewDate { get; set; }
}