namespace ServiceManagerApi.Dtos.PlannedOutput
{
    public class PlannedOutputPostDto
    {
        public int? DestinationId { get; set; }

        public int? ActivityId { get; set; }

        public int? Quantity { get; set; }

        public virtual Data.ProductionActivity? Activity { get; set; }

        public virtual Data.ProductionDestination? Destination { get; set; }
    }
}
