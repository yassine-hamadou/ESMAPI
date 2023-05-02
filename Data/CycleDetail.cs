using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class CycleDetail
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Loader { get; set; }
        public string? Hauler { get; set; }
        public string? Origin { get; set; }
        public string? Material { get; set; }
        public string? Destination { get; set; }
        public string? Nominal { get; set; }
        public int? Weight { get; set; }
        public int? PayloadWeight { get; set; }
        public int? ReportedWeight { get; set; }
        public int? Volume { get; set; }
        public int? Loads { get; set; }
        public TimeSpan? TimeAtLoader { get; set; }
        public int? Duration { get; set; }
    }
}
