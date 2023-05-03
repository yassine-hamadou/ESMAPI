using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Section
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ServiceId { get; set; }

    public short? Status { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual Service? Service { get; set; }
}
