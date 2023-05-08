namespace ServiceManagerApi.Dtos.HoursEntries
{
    public record HoursEntriesPutDto
    {
        public int Id { get; set; }
        public string? FleetId { get; set; }
        public DateTime? Date { get; set; }
        public double? PreviousReading { get; set; }
        public double? CurrentReading { get; set; }
    }
}
