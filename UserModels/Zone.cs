using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class Zone
{
    public int Id { get; set; }

    public string? RoleId { get; set; }

    public string? Name { get; set; }
}
