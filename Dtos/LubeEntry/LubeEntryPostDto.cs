namespace ServiceManagerApi.Dtos.LubeEntry
{
    public class LubeEntryPostDto
    {
        public string? FleetId { get; set; }
        public int? CompartmentId { get; set; }
        public string? ChangeOutInterval { get; set; }
        public string? Capacity { get; set; }
        public int? RefillTypeId { get; set; }
        public int? GradeId { get; set; }
        public int? BrandId { get; set; }
        public string? Volume { get; set; }     
        public string? PreviousHour { get; set; }
        public string? CurrentHour { get; set; }
        public DateTime? RefillDate { get; set; }
        
    }
}
