using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Category
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
