using System;
using System.Collections.Generic;

namespace ServiceManagerApi.UserModels;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }
}
