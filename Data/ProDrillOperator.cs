using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProDrillOperator
{
    public int Id { get; set; }

    public string OperatorCode { get; set; } = null!;

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<DrillEntry> DrillEntries { get; set; } = new List<DrillEntry>();
}
