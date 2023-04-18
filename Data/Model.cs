using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class Model
    {
        public Model()
        {
            Equipment = new HashSet<Equipment>();
            Services = new HashSet<Service>();
        }

        public int ModelId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelClassId { get; set; }
        public string? Name { get; set; }
        public string Code { get; set; } = null!;
        public string? PictureLink { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ModelClass? ModelClass { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
