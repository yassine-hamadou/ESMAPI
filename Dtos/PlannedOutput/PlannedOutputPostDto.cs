namespace ServiceManagerApi.Dtos.PlannedOutput
{
    public class PlannedOutputPostDto
    {
        public string? TenantId { get; set; }

        public int? Volume { get; set; }

        public DateTime? PlannedDate { get; set; }

        public int? LocationId { get; set; }
        
        public string? PlannedOutputType { get; set; }
    }
}