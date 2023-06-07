using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class Application
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
}
