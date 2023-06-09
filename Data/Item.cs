﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int GroupId { get; set; }

    public string? TenantId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<ItemValue> ItemValues { get; set; } = new List<ItemValue>();
}
