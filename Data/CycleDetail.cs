using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class CycleDetail
{
    public string? CycleDate { get; set; }

    public string? CycleTime { get; set; }

    public string? Loader { get; set; }

    public string? Hauler { get; set; }

    public int? LoaderUnitId { get; set; }

    public int? HaulerUnitId { get; set; }

    public int? OriginId { get; set; }

    public int? MaterialId { get; set; }

    public int? DestinationId { get; set; }

    public int? NominalWeight { get; set; }

    public int? Weight { get; set; }

    public int? PayloadWeight { get; set; }

    public int? ReportedWeight { get; set; }

    public int? Volumes { get; set; }

    public int? Loads { get; set; }

    public string? TimeAtLoader { get; set; }

    public int Id { get; set; }

    public int? ShiftId { get; set; }

    public string? TenantId { get; set; }

    public int? Duration { get; set; }

    public string? BatchNumber { get; set; }

    public virtual ProductionDestination? Destination { get; set; }

    public virtual HaulerOperator? HaulerNavigation { get; set; }

    public virtual ProhaulerUnit? HaulerUnit { get; set; }

    public virtual LoaderOperator? LoaderNavigation { get; set; }

    public virtual ProloaderUnit? LoaderUnit { get; set; }

    public virtual ProdRawMaterial? Material { get; set; }

    public virtual ProductionOrigin? Origin { get; set; }

    public virtual ProductionShift? Shift { get; set; }
}
