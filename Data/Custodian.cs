using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Custodian
{
    public string? Code { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? HrCode { get; set; }
}
