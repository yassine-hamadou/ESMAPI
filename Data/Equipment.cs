using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Equipment
{
    public int Id { get; set; }

    public int? ModelId { get; set; }

    public string EquipmentId { get; set; } = null!;

    public string? Description { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? ManufactureDate { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public DateTime? EndOfLifeDate { get; set; }

    public string? Facode { get; set; }

    public string? Note { get; set; }

    public DateTime? WarrantyStartDate { get; set; }

    public DateTime? WarrantyEndDate { get; set; }

    public string? UniversalCode { get; set; }

    public string? MeterType { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();

    public virtual ICollection<DefectEntry> DefectEntries { get; set; } = new List<DefectEntry>();

    public virtual ICollection<GroundEngTool> GroundEngTools { get; set; } = new List<GroundEngTool>();

    public virtual ICollection<HoursEntry> HoursEntries { get; set; } = new List<HoursEntry>();

    public virtual ICollection<HoursEntryTemp> HoursEntryTemps { get; set; } = new List<HoursEntryTemp>();

    public virtual Model? Model { get; set; }

    public virtual ICollection<ProhaulerUnit> ProhaulerUnits { get; set; } = new List<ProhaulerUnit>();

    public virtual ICollection<ProloaderUnit> ProloaderUnits { get; set; } = new List<ProloaderUnit>();
}
