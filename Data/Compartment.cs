using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Compartment
    {
        public Compartment()
        {
            LubeConfigs = new HashSet<LubeConfig>();
            LubeEntries = new HashSet<LubeEntry>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<LubeConfig> LubeConfigs { get; set; }
        public virtual ICollection<LubeEntry> LubeEntries { get; set; }
    }
}
