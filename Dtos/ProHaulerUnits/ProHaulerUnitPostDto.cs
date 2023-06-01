namespace ServiceManagerApi.Dtos.ProHaulerUnits
{
    public record ProHaulerUnitPostDto
    {
        public string? EquipmentId { get; set; }
        public string? ModelName { get; set; }
        public string? Description { get; set; }
        public string? TenantId { get; set; }
    }
}
