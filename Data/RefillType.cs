using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class RefillType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<LubeEntry> LubeEntries { get; set; } = new List<LubeEntry>();
}
