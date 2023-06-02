namespace ServiceManagerApi.Dtos.FuelIntake;

public class ProFuelIssuePostDto
{
    public int? PumpId { get; set; }

    public string? EquipmentId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? IntakeDate { get; set; }
    
    public string? TransactionType { get; set; }
    
    public string? TenantId { get; set; }

    public string? BatchNumber { get; set; }
}