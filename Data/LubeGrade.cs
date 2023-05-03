using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class LubeGrade
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? BrandId { get; set; }

    public int? LubeConfigId { get; set; }

    public virtual LubeBrand? Brand { get; set; }

    public virtual LubeConfig? LubeConfig { get; set; }

    public virtual ICollection<LubeEntry> LubeEntries { get; set; } = new List<LubeEntry>();
}
