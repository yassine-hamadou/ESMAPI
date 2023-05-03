using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Agreement
{
    public int Id { get; set; }

    public int? EquipmentId { get; set; }

    public int? Description { get; set; }

    public DateTime? AgreementDate { get; set; }

    public int? Status { get; set; }

    public virtual Equipment? Equipment { get; set; }
}
