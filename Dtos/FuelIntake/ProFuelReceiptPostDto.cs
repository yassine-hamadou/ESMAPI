namespace ServiceManagerApi.Dtos.FuelIntake;

public class ProFuelReceiptPostDto
{
    public int? PumpId { get; set; }

    public int? Quantity { get; set; }
    
    public string? TransactionType { get; set; }

    public DateTime? IntakeDate { get; set; }
    
    public string? TenantId { get; set; }

    public string? BatchNumber { get; set; }
}