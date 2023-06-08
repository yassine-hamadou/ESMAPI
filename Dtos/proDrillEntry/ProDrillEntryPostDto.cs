namespace ServiceManagerApi.Dtos.proDrillEntry;

public class ProDrillEntryPostDto
{
    public string? RigId { get; set; }

    public int? ShiftId { get; set; }

    public int? ActivityId { get; set; }

    public int? ActivityDetailId { get; set; }

    public DateTime? DrillDate { get; set; }

    public int? MeterValue { get; set; }

    public string? TenantId { get; set; }
}