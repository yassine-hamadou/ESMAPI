using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ViewEquip
{
    public string? EquipmentId { get; set; }

    public string? Description { get; set; }

    public int? ModelId { get; set; }

    public string? Name { get; set; }

    public string? Manufacturer { get; set; }

    public string? Modelclass { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? ManufactureDate { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public DateTime? EndOfLifeDate { get; set; }

    public DateTime? WarrantyStartDate { get; set; }

    public DateTime? WarrantyEndDate { get; set; }

    public string? TenantId { get; set; }

    public string Status { get; set; } = null!;
}
