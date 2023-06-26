namespace ServiceManagerApi.Dtos.GroundEngagingTools;

public class GroundEngagingToolsPostDto
{
  public string EquipmentId { get; set; } = null!;
  public double? PreviousHours { get; set; }
  public double? CurrentHours { get; set; }
  public int? Quantity { get; set; }
  public string? Reason { get; set; }
  public DateTime? Date { get; set; }
  public string? ItemType { get; set; }
  public string TenantId { get; set; } = null!;
}