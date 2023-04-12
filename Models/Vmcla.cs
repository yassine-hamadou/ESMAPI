using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcla
    {
        public short Wdtype { get; set; }
        public string Txclass { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public string Txcomments { get; set; } = null!;
        public decimal Nmstat { get; set; }
        public short Wdperiod { get; set; }
        public short Wdpertype { get; set; }
        public decimal Nmescperc { get; set; }
    }
}
