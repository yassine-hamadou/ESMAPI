using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Model { get; set; }

    public string TenantId { get; set; } = null!;

    public int? IntervalForPm { get; set; }

    public virtual ICollection<FleetSchedule> FleetSchedules { get; set; } = new List<FleetSchedule>();

    public virtual Model? ModelNavigation { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
