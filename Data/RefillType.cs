using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class RefillType
    {
        public RefillType()
        {
            LubeEntries = new HashSet<LubeEntry>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<LubeEntry> LubeEntries { get; set; }
    }
}
