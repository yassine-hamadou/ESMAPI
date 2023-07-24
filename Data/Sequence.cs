using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Sequence
{
    public int Id { get; set; }

    public string? SequenceName { get; set; }

    public string? EquipModel { get; set; }

    public int? Interval { get; set; }

    public string? TenantId { get; set; }
}
