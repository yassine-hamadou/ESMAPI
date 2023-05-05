<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;
=======
﻿namespace ServiceManagerApi.Data;
>>>>>>> 84a3e3c93f422be3597f76c8d69f336f048292b4

public partial class PlannedOutput
{
    public int Id { get; set; }

    public int? DestinationId { get; set; }

    public int? ActivityId { get; set; }

    public int? Quantity { get; set; }

<<<<<<< HEAD
    public string? TenantId { get; set; }

=======
>>>>>>> 84a3e3c93f422be3597f76c8d69f336f048292b4
    public virtual ProductionActivity? Activity { get; set; }

    public virtual ProductionDestination? Destination { get; set; }
}
