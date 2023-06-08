using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public string? Gender { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
}
