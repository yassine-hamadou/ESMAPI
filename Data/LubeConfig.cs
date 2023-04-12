using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class LubeConfig
    {
        public LubeConfig()
        {
            LubeGrades = new HashSet<LubeGrade>();
        }

        public int Id { get; set; }
        public string? Model { get; set; }
        public int? CompartmentId { get; set; }
        public double? ChangeOutInterval { get; set; }
        public double? Capacity { get; set; }

        public virtual Compartment? Compartment { get; set; }
        public virtual ICollection<LubeGrade> LubeGrades { get; set; }
    }
}
