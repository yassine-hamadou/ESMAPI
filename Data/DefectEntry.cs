using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class DefectEntry
{
    public int Id { get; set; }

    public string DefectEquipmentId { get; set; } = null!;

    public DateTime? ExpectedDate { get; set; }

    public string? Item { get; set; }

    public string? Comment { get; set; }

    public string? TenantId { get; set; }

    public string? ReferenceId { get; set; }

    public string? EquipmentDescription { get; set; }

    public virtual Equipment DefectEquipment { get; set; } = null!;
}
