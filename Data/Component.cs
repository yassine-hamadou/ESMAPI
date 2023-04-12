using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Component
    {
        public int Id { get; set; }
        public int? EquipmentId { get; set; }
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }
        public int? Quantity { get; set; }

        public virtual Equipment? Equipment { get; set; }
    }
}
