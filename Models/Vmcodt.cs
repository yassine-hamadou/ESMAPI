using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcodt
    {
        public decimal Nmpstid { get; set; }
        public short Wdtrannum { get; set; }
        public decimal Nmcomm { get; set; }
        public decimal Nmseqnum { get; set; }
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txcomment { get; set; } = null!;
        public short Wdtype { get; set; }
        public short Wdobjtype { get; set; }
        public string Txobjcapt { get; set; } = null!;
        public string Txpathcls { get; set; } = null!;
    }
}
