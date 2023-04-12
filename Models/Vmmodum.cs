using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmmodum
    {
        public string Txmodl { get; set; } = null!;
        public short Wdtype { get; set; }
        public string Txcode { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public short Swspecloc { get; set; }
        public string Txlocation { get; set; } = null!;
        public decimal Qtdefqtyd { get; set; }
    }
}
