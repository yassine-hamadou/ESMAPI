using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class LubeBrand
    {
        public LubeBrand()
        {
            LubeEntries = new HashSet<LubeEntry>();
            LubeGrades = new HashSet<LubeGrade>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<LubeEntry> LubeEntries { get; set; }
        public virtual ICollection<LubeGrade> LubeGrades { get; set; }
    }
}
