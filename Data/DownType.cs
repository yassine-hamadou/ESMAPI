using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class DownType
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public string? TenantId { get; set; }
}
