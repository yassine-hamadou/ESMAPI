using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class ModelClass
    {
        public ModelClass()
        {
            Models = new HashSet<Model>();
        }

        public int ModelClassId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
