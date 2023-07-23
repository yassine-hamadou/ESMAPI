using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ScheduleTransaction
{
    public string? EquipmentId { get; set; }

    public int ItemValueId { get; set; }

    public int Id { get; set; }

    public string? ReferenceId { get; set; }

    public string? TenantId { get; set; }

    public virtual ItemValue ItemValue { get; set; } = null!;
}
