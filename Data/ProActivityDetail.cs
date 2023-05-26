using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProActivityDetail
{
    public int Id { get; set; }

    public int? ActivityId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public virtual ProductionActivity? Activity { get; set; }
}
