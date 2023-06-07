using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
