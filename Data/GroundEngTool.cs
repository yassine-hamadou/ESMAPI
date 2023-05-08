using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class GroundEngTool
{
    public string EquipmentId { get; set; } = null!;

    public int Id { get; set; }

    public double? PreviousHours { get; set; }

    public double? CurrentHours { get; set; }

    public int? Quantity { get; set; }

    public string? Reason { get; set; }

    public DateTime? Date { get; set; }

    public string? TenantId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;
}
