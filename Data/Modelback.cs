using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Modelback
{
    public int ModelId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? ModelClassId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? PictureLink { get; set; }

    public string? TenantId { get; set; }
}
