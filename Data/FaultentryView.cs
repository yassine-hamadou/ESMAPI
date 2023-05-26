using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class FaultentryView
{
    public string? Month { get; set; }

    public int? Year { get; set; }

    public int? Totaldowntime { get; set; }
}
