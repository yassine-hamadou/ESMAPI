using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Model
{
    public int ModelId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? ModelClassId { get; set; }

    public string? Name { get; set; }

    public string Code { get; set; } = null!;

    public string? PictureLink { get; set; }

    public string? TenantId { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Equipment1> Equipment1s { get; set; } = new List<Equipment1>();

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ModelClass? ModelClass { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
