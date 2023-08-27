namespace ServiceManagerApi.Dtos.ProDrill;

public class DrillEntryDto
{
    public int? ShiftId { get; set; }

    public string? EquipmentId { get; set; }

    public string? OperatorCode { get; set; }

    public int? PitLocationId { get; set; }

    public string? BlastNumber { get; set; }

    public decimal? TotalMeters { get; set; }

    public decimal? RedrillMeters { get; set; }

    public decimal? SmuHours { get; set; }

    public decimal? DownHours { get; set; }

    public decimal? EffectiveDrillingHours { get; set; }

    public decimal? OperatingHours { get; set; }

    public decimal? StandByHours { get; set; }

    public decimal? Availability { get; set; }

    public decimal? Uoa { get; set; }

    public decimal? PenRateEffHrs { get; set; }

    public decimal? PenRateOpHrs { get; set; }

    public decimal? UtilizationEffectiveHours { get; set; }
    
    public string? TenantId { get; set; }

    public string? BatchNumber { get; set; }
    
    public DateTime? DrillDate { get; set; }
}