﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Contact { get; set; }

    public int? Phone { get; set; }

    public string? Code { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
