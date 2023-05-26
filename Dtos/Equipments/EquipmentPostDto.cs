namespace ServiceManagerApi.Dtos.Equipments;

public record EquipmentPostDto
{
  public int Id { get; set; }

  public int? ModelId { get; set; }

  public string EquipmentId { get; set; } = null!;

  public string? Description { get; set; }

  public string? SerialNumber { get; set; }

  public DateTime? ManufactureDate { get; set; }

  public DateTime? PurchaseDate { get; set; }

  public DateTime? EndOfLifeDate { get; set; }

  public string? Facode { get; set; }

  public string? Note { get; set; }

  public DateTime? WarrantyStartDate { get; set; }

  public DateTime? WarrantyEndDate { get; set; }

  public string? UniversalCode { get; set; }

  public string? MeterType { get; set; }

  public string? TenantId { get; set; }
}