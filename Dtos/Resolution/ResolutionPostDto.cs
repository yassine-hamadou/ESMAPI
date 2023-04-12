namespace ServiceManagerApi.Dtos.Resolution
{
    public class ResolutionPostDto
    {
        public string? FleetId { get; set; }
        public string? Description { get; set; }
        public string? Model { get; set; }
        public string? DownType { get; set; }
        public string? DownStation { get; set; }
        public string? Duration { get; set; }
        public string? Custodian { get; set; }
        public string? Location { get; set; }
        public string? Comment { get; set; }
        public DateTime? TimeStarted { get; set; }
        public DateTime? TimeCompleted { get; set; }
    }
}
