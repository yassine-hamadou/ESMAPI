namespace ServiceManagerApi.Data;

public partial class PlannedOutput
{
    public int Id { get; set; }

    public int? DestinationId { get; set; }

    public int? ActivityId { get; set; }

    public int? Quantity { get; set; }

    public virtual ProductionActivity? Activity { get; set; }

    public virtual ProductionDestination? Destination { get; set; }
}
