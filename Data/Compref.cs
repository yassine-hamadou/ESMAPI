using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Compref
{
    public string? Model { get; set; }

    public string? Compartment { get; set; }

    public string? Oilgrade { get; set; }

    public string? Brand { get; set; }

    public double? Interval { get; set; }

    public double? Capacity { get; set; }

    public string F7 { get; set; } = null!;

    public string F8 { get; set; } = null!;

    public string F9 { get; set; } = null!;

    public string F10 { get; set; } = null!;

    public string F11 { get; set; } = null!;

    public string F12 { get; set; } = null!;

    public string F13 { get; set; } = null!;

    public string F14 { get; set; } = null!;
}
