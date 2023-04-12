namespace ServiceManagerApi.Dtos.HoursEntries
{
    public class HoursEntriesPostDto
    {
        public string? FleetId { get; set; }
        public DateTime? Date { get; set; }
        public double? PreviousReading { get; set; }
        public double? CurrentReading { get; set; }
    }
}
