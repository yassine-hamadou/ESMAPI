using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class UserActivity
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? DataItem { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime? RequestTime { get; set; }

    public string? Url { get; set; }
}
