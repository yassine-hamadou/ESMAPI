using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class LubeEntry
{
    public int Id { get; set; }

    public string? FleetId { get; set; }

    public int? CompartmentId { get; set; }

    public double? ChangeOutInterval { get; set; }

    public double? Capacity { get; set; }

    public int? RefillTypeId { get; set; }

    public double? Volume { get; set; }

    public double? PreviousHour { get; set; }

    public double? CurrentHour { get; set; }

    public DateTime? RefillDate { get; set; }

    public int? GradeId { get; set; }

    public int? BrandId { get; set; }

    public virtual LubeBrand? Brand { get; set; }

    public virtual Compartment? Compartment { get; set; }

    public virtual LubeGrade? Grade { get; set; }

    public virtual RefillType? RefillType { get; set; }
}
