using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class ProductionActivity
{
    public int Id { get; set; }

    public string? Name { get; set; }

<<<<<<< HEAD
    public string? TenantId { get; set; }

=======
>>>>>>> 84a3e3c93f422be3597f76c8d69f336f048292b4
    public virtual ICollection<PlannedOutput> PlannedOutputs { get; set; } = new List<PlannedOutput>();
}
