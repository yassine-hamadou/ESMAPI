using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class FleetSchedule
{
    public long EntryId { get; set; }

    public string FleetId { get; set; } = null!;

    public string VmModel { get; set; } = null!;

    public string VmClass { get; set; } = null!;

    public int? ServiceTypeId { get; set; }

    public string LocationId { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public string? Responsible { get; set; }

    public string? ReferenceId { get; set; }

    public string? TenantId { get; set; }

    public string? Status { get; set; }

    public virtual Service? ServiceType { get; set; }
}
