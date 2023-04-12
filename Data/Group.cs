using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Group
    {
        public Group()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SectionId { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
