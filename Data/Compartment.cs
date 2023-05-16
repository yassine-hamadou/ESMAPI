using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Compartment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<LubeConfig> LubeConfigs { get; set; } = new List<LubeConfig>();

    public virtual ICollection<LubeEntry> LubeEntries { get; set; } = new List<LubeEntry>();
}
