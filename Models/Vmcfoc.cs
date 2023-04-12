using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcfoc
    {
        public short Wdtype { get; set; }
        public string Txcfov { get; set; } = null!;
        public decimal Nmcfoc { get; set; }
        public short Wdlineseq { get; set; }
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txtext { get; set; } = null!;
        public decimal Nmnumber { get; set; }
        public decimal Dtdate { get; set; }
        public decimal Tmtime { get; set; }
        public short Swbool { get; set; }
    }
}
