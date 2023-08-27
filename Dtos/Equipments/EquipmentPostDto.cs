using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceManagerApi.Dtos.Equipments;

public record EquipmentPostDto
{
  [Required] public int ModelId { get; set; }

  [Required] public string EquipmentId { get; set; } = null!;

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

  [Required] public int InitialReading { get; set; }

  [Required] public string MeterType { get; set; } = null!;

  [Required] public string TenantId { get; set; } = null!;
}