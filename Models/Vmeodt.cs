using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmeodt
    {
        public decimal Nmpstid { get; set; }
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public short Wddoctype { get; set; }
        public string Txpstid { get; set; } = null!;
        public string Txbillto { get; set; } = null!;
        public string Txbillname { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public string Txtype { get; set; } = null!;
        public string Txref { get; set; } = null!;
        public decimal Dtposted { get; set; }
        public decimal Tmposted { get; set; }
        public string Txentryby { get; set; } = null!;
        public decimal Nmdocid { get; set; }
        public string Txsourceid { get; set; } = null!;
        public string Txcrdapprv { get; set; } = null!;
        public decimal Mnsnettot { get; set; }
        public decimal Mnsnettotf { get; set; }
        public decimal Mnstotcst { get; set; }
        public decimal Mnsgpamt { get; set; }
        public decimal Nmsgpperc { get; set; }
        public string Txsrcecurr { get; set; } = null!;
        public short Swprocess { get; set; }
        public short Swdenddone { get; set; }
        public string Txsctr { get; set; } = null!;
        public short Wdpostmeth { get; set; }
    }
}
