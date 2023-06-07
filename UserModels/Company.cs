using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class Company
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ApplicationId { get; set; }

    public virtual Application? Application { get; set; }
}
