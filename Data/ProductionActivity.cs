using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProductionActivity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public string? Code { get; set; }

    public string? ActivityType { get; set; }

    public virtual ICollection<PlannedOutput> PlannedOutputs { get; set; } = new List<PlannedOutput>();

    public virtual ICollection<ProActivityDetail> ProActivityDetails { get; set; } = new List<ProActivityDetail>();
}
