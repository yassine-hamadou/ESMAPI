using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmmodc
    {
        public string Txmodl { get; set; } = null!;
        public string Txcomp { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public short Wdcompqty { get; set; }
    }
}
