using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ItemValue
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual ICollection<ScheduleTransaction> ScheduleTransactions { get; set; } = new List<ScheduleTransaction>();
}
