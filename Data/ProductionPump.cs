using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProductionPump
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<ProFuelIntake> ProFuelIntakes { get; set; } = new List<ProFuelIntake>();
}
