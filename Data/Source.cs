using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Source
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }
}
