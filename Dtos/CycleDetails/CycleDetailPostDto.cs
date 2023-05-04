using ServiceManagerApi.Data;

namespace ServiceManagerApi.Dtos.CycleDetails
{
    public class CycleDetailPostDto
    {
        public DateTime? CycleDate { get; set; }

        public TimeSpan? CycleTime { get; set; }

        public string? Loader { get; set; }

        public string? Hauler { get; set; }

        public int? LoaderUnitId { get; set; }

        public int? HaulerUnitId { get; set; }

        public int? OriginId { get; set; }

        public int? MaterialId { get; set; }

        public int? DestinationId { get; set; }

        public int? NominalWeight { get; set; }

        public int? Weight { get; set; }

        public int? PayloadWeight { get; set; }

        public int? ReportedWeight { get; set; }

        public int? Volumes { get; set; }

        public int? Loads { get; set; }

        public TimeSpan? TimeAtLoader { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? ShiftId { get; set; }

    }
}
