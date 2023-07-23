using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class TarkwaModelClass
{
    public int? ModelClassId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }
}
