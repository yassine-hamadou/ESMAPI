using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Model
    {
        public Model()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int ModelId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelClassId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? PictureLink { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ModelClass? ModelClass { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
