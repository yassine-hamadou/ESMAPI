namespace ServiceManagerApi.Dtos.PlannedOutput
{
    public class PlannedOutputPostDto
    {
        public int? DestinationId { get; set; }

        public int? ActivityId { get; set; }

        public int? Quantity { get; set; }
        public string? TenantId { get; set; }

    }
}
