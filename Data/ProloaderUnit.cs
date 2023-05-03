using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProloaderUnit
{
    public int Id { get; set; }

    public string? EquipmentId { get; set; }

    public string? Description { get; set; }

    public string? ModelName { get; set; }

    public virtual ICollection<CycleDetail> CycleDetails { get; set; } = new List<CycleDetail>();

    public virtual Equipment? Equipment { get; set; }
}
