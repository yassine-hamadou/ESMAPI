namespace ServiceManagerApi.Dtos.BacklogDto;

public record BacklogDto
(
    int Id,
    string? EquipmentId,
    DateTime? Bdate,
    string? Item,
    string? Note,
    string? Comment,
    string? ReferenceId,
    int? Status,
    DateTime? Cdate
);

public record BacklogPostDto
(
    string EquipmentId,
    DateTime? Bdate,
    string? Item,
    string? Note,
    string? Comment,
    string? ReferenceId,
    int? Status,
    DateTime? Cdate,
    string TenantId
);

public record BacklogPutDto
(
    int Id,
    string EquipmentId,
    DateTime? Bdate,
    string? Item,
    string? Note,
    string? Comment,
    string? ReferenceId,
    int? Status,
    DateTime? Cdate
);