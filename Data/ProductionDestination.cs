using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProductionDestination
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<CycleDetail> CycleDetails { get; set; } = new List<CycleDetail>();

    public virtual ICollection<PlannedOutput> PlannedOutputs { get; set; } = new List<PlannedOutput>();
}
