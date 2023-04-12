using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcfoh
    {
        public short Wdtype { get; set; }
        public string Txcfov { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public short Wdnextseq { get; set; }
    }
}
