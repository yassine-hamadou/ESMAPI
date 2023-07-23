using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Group
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SectionId { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Section? Section { get; set; }
}
