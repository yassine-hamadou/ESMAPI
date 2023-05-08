namespace ServiceManagerApi.Dtos.HoursEntriesTemp
{
    public class HoursEntriesTempPostDto
    {
        public string? FleetId { get; set; }
        public DateTime? Date { get; set; }
        public double? PreviousReading { get; set; }
        public double? CurrentReading { get; set; }
    }
}
