using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class LubeConfig
{
    public int Id { get; set; }

    public int Model { get; set; }

    public int? CompartmentId { get; set; }

    public double? ChangeOutInterval { get; set; }

    public double? Capacity { get; set; }

    public string? TenantId { get; set; }

    public virtual Compartment? Compartment { get; set; }

    public virtual ICollection<LubeGrade> LubeGrades { get; set; } = new List<LubeGrade>();

    public virtual Model ModelNavigation { get; set; } = null!;
}
