using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcon
    {
        public decimal Nmcont { get; set; }
        public string Txsite { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public short Wdarea1 { get; set; }
        public short Wdarea2 { get; set; }
        public string Txarea3 { get; set; } = null!;
        public string Txarea4 { get; set; } = null!;
        public short Swcpenable { get; set; }
    }
}
