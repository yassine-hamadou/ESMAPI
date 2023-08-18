namespace ServiceManagerApi.Dtos.ProductionBlast;

public class ProductionBlastDto
{
    public DateTime? BlastDate { get; set; }

    public string? PitLocation { get; set; }

    public int? BenchLevel { get; set; }

    public int? Depth { get; set; }

    public string? PatternSize { get; set; }

    public int? ExpansionFactor { get; set; }

    public int? NumberOfHoles { get; set; }

    public int? SurveyProductionHoles { get; set; }

    public double? Area { get; set; }

    public double? SurveyVol { get; set; }

    public double? CummulativeBlastVol { get; set; }

    public string? LostRodGet { get; set; }

    public string? TenantId { get; set; }
}