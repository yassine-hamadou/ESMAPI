using System.ComponentModel.DataAnnotations;

namespace ServiceManagerApi.Dtos.Manufacturers;

public record ManufacturerPostDto(
    string? Name,
    string? Email,
    string? Address,
    string? Contact,
    int? Phone,
    string? Code,
    [Required] string TenantId
);

public record ManufacturerPutDto(
    int ManufacturerId,
    string? Name,
    string? Email,
    string? Address,
    string? Contact,
    int? Phone,
    string? Code,
    string? TenantId
);

public record ManufacturerDto(
    int ManufacturerId,
    string? Name,
    string? Email,
    string? Address,
    string? Contact,
    int? Phone,
    string? Code,
    string? TenantId
);