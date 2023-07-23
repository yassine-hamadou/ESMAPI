using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Hrsul
{
    public string? FleetId { get; set; }

    public DateTime? ReadingDate { get; set; }

    public double? TotMachineHrs { get; set; }

    public double? TotPrevHrs { get; set; }
}
