using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Compup
{
    public string? FleetComponent { get; set; }

    public string? DateFitted { get; set; }

    public double? HrsFitted { get; set; }

    public double? CompoHrsAlreadyWorked { get; set; }

    public DateTime? DateRemoved { get; set; }

    public double? HrsRemoved { get; set; }

    public string? ReasonForRemoval { get; set; }

    public string? SerialNoOld { get; set; }

    public string? SerialNoNew { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public decimal? ComponentPrice { get; set; }
}
