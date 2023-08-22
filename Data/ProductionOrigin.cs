using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProductionOrigin
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<CycleDetail> CycleDetails { get; set; } = new List<CycleDetail>();

    public virtual ICollection<ProBlast> ProBlasts { get; set; } = new List<ProBlast>();
}
