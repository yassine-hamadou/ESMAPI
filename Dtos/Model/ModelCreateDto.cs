using System.ComponentModel.DataAnnotations;

namespace ServiceManagerApi.Dtos.Model;

public record ModelCreateDto
{
  public int? ManufacturerId { get; set; }
  public int? ModelClassId { get; set; }
  public string? Name { get; set; }
  [Required] public string Code { get; set; }
  public string? PictureLink { get; set; }
  public string? TenantId { get; set; }
  public IFormFile? ImageFile { get; set; }
}