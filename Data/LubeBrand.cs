using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class LubeBrand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<LubeEntry> LubeEntries { get; set; } = new List<LubeEntry>();

    public virtual ICollection<LubeGrade> LubeGrades { get; set; } = new List<LubeGrade>();
}
