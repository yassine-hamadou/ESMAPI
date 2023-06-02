namespace ServiceManagerApi.Dtos.PlannedOutput
{
    public class PlannedOutputPostDto
    {
        public string? TenantId { get; set; }

        public int? DestinationId { get; set; }

        public int? ActivityId { get; set; }

        public int? Quantity { get; set; }

    }
}
