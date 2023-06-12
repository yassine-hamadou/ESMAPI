namespace ServiceManagerApi.Dtos.Services;

public record ServicePostDto
{
  public string? Name { get; set; }
  public string? Model { get; set; }
  public string TenantId { get; set; } = null!;
  public int? IntervalForPm { get; set; }
}