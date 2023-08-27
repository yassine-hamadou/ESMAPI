using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProDrillEntry
{
    public int Id { get; set; }

    public string? RigId { get; set; }

    public int? ShiftId { get; set; }

    public int? ActivityId { get; set; }

    public int? ActivityDetailId { get; set; }

    public DateTime? DrillDate { get; set; }

    public int? MeterValue { get; set; }

    public string? TenantId { get; set; }

    public virtual ProductionActivity? Activity { get; set; }

    public virtual ProActivityDetail? ActivityDetail { get; set; }

    public virtual ProductionShift? Shift { get; set; }
}
