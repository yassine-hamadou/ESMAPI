namespace ServiceManagerApi.Dtos.Sequences;

public record SequencePostDto
{
  public string? SequenceName { get; set; }

  public string? EquipModel { get; set; }

  public int? Interval { get; set; }

  public string? TenantId { get; set; }
}