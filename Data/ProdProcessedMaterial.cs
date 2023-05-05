using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProdProcessedMaterial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }
}
