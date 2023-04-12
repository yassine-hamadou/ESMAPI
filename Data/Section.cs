using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Section
    {
        public Section()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ServiceId { get; set; }
        public short? Status { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
