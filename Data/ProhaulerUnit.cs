using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class ProhaulerUnit
    {
        public int Id { get; set; }
        public string? EquipmentId { get; set; }
        public string? ModelName { get; set; }
        public string? Description { get; set; }

        public virtual Equipment? DescriptionNavigation { get; set; }
    }
}
