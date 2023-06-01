namespace ServiceManagerApi.Dtos.FleetSchedule;

public class FleetSchedulePostDto
{
  public string FleetId { get; set; } = null!;

  public string VmModel { get; set; }

  public string VmClass { get; set; }

  public int? ServiceTypeId { get; set; }

  public string LocationId { get; set; }

  public string? Description { get; set; }

  public DateTime? TimeStart { get; set; }

  public DateTime? TimeEnd { get; set; }

  public string? Responsible { get; set; }

  public string? ReferenceId { get; set; }

  public string? TenantId { get; set; }
}