using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProFuelIntake
{
    public int Id { get; set; }

    public int? PumpId { get; set; }

    public string? EquipmentId { get; set; }

    public int? Quantity { get; set; }

    public string? IntakeDate { get; set; }

    public string? TransactionType { get; set; }

    public string? TenantId { get; set; }

    public string? BatchNumber { get; set; }

    public virtual Equipment? Equipment { get; set; }

    public virtual ProductionPump? Pump { get; set; }
}
