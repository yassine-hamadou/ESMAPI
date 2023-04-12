using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Hourly
    {
        public long EntryId { get; set; }
        public string FleetId { get; set; } = null!;
        public long? PreviousReading { get; set; }
        public long? Reading { get; set; }
        public int? DailyHoursWorked { get; set; }
        public DateTime? ReadingDate { get; set; }
    }
}
