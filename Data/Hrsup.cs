using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Hrsup
{
    public string? FleetId { get; set; }

    public DateTime? ReadingDate { get; set; }

    public double Reading { get; set; }

    public double PrevReading { get; set; }

    public double AdjustHrsBy1 { get; set; }

    public double AdjustHrsBy2 { get; set; }

    public double AdjustHrsBy3 { get; set; }

    public string Comment { get; set; } = null!;

    public double? TotMachineHrs { get; set; }

    public double? TotPrevHrs { get; set; }
}
