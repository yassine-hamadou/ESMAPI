using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class PlannedOutput
{
    public int Id { get; set; }

    public string? TenantId { get; set; }

    public int? Volume { get; set; }

    public DateTime? PlannedDate { get; set; }
}
