using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Component
{
    public int Id { get; set; }

    public string EquipmentId { get; set; } = null!;

    public string? Description { get; set; }

    public string? SerialNumber { get; set; }

    public int? Quantity { get; set; }

    public string? TenantId { get; set; }

    public DateTime? InstallDate { get; set; }

    public string? PartNumber { get; set; }

    public string? ReasonForChange { get; set; }

    public DateTime? LastChangeDate { get; set; }

    public int? ComponentHours { get; set; }

    public string? NewSerialNumber { get; set; }

    public decimal? ComponentPrice { get; set; }

    public string? ComponentStatus { get; set; }

    public DateTime? HoursRemoved { get; set; }

    public int? HoursFitted { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;
}
