using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Faultsm
{
    public DateTime? Date { get; set; }

    public string? Fleet { get; set; }

    public string? Model { get; set; }

    public string? Machine { get; set; }

    public DateTime? TimeDown { get; set; }

    public string? ReportedTo { get; set; }

    public DateTime? TimeUp { get; set; }

    public string? Responsibility { get; set; }

    public string? DownType { get; set; }

    public string? Location { get; set; }

    public string? Comment { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public decimal? HoursDown { get; set; }
}
