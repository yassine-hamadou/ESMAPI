using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class DrillEntry
{
    public int Id { get; set; }

    public int? ShiftId { get; set; }

    public string? EquipmentId { get; set; }

    public int? OperatorId { get; set; }

    public string? PitLocation { get; set; }

    public string? BlastNumber { get; set; }

    public decimal? TotalMeters { get; set; }

    public decimal? RedrillMeters { get; set; }

    public decimal? SmuHours { get; set; }

    public decimal? DownHours { get; set; }

    public decimal? EffectiveDrillingHours { get; set; }

    public decimal? OperatingHours { get; set; }

    public decimal? StandByHours { get; set; }

    public decimal? Availability { get; set; }

    public decimal? Uoa { get; set; }

    public decimal? PenRateEffHrs { get; set; }

    public decimal? PenRateOpHrs { get; set; }

    public decimal? UtilizationEffectiveHours { get; set; }

    public string? TenantId { get; set; }

    public string? BatchNumber { get; set; }

    public DateTime? DrillDate { get; set; }

    public virtual Equipment? Equipment { get; set; }

    public virtual ProDrillOperator? Operator { get; set; }

    public virtual ProductionShift? Shift { get; set; }
}
