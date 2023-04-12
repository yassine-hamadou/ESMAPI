using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmmodm
    {
        public string Txmodl { get; set; } = null!;
        public string Txmtrtype { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public short Wdnumrng { get; set; }
        public decimal Nmrng1 { get; set; }
        public decimal Nmrng2 { get; set; }
        public decimal Nmrng3 { get; set; }
        public decimal Nmrng4 { get; set; }
        public decimal Nmrng5 { get; set; }
        public int Lnmtrcnt1 { get; set; }
        public int Lnmtrcnt2 { get; set; }
        public int Lnmtrcnt3 { get; set; }
        public int Lnmtrcnt4 { get; set; }
        public int Lnmtrcnt5 { get; set; }
        public int Lnfaltcnt1 { get; set; }
        public int Lnfaltcnt2 { get; set; }
        public int Lnfaltcnt3 { get; set; }
        public int Lnfaltcnt4 { get; set; }
        public int Lnfaltcnt5 { get; set; }
        public int Lnfailcnt1 { get; set; }
        public int Lnfailcnt2 { get; set; }
        public int Lnfailcnt3 { get; set; }
        public int Lnfailcnt4 { get; set; }
        public int Lnfailcnt5 { get; set; }
        public short Swaplycomp { get; set; }
    }
}
