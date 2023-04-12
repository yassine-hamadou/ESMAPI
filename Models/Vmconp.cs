using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmconp
    {
        public decimal Nmcont { get; set; }
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txname { get; set; } = null!;
        public short Swactive { get; set; }
        public string Txposition { get; set; } = null!;
        public string Txrole { get; set; } = null!;
        public string Txskilllev { get; set; } = null!;
        public string Txloc { get; set; } = null!;
        public string Txphone { get; set; } = null!;
        public string Txext { get; set; } = null!;
        public string Txfax { get; set; } = null!;
        public string Txmobile { get; set; } = null!;
        public string Txemail { get; set; } = null!;
        public string Txphonepr { get; set; } = null!;
        public string Txemailpr { get; set; } = null!;
        public short Swusepic { get; set; }
        public string Txpicfile { get; set; } = null!;
        public decimal Dtlastcont { get; set; }
        public short Swevent1 { get; set; }
        public short Swevent2 { get; set; }
        public short Swevent3 { get; set; }
        public short Swevent4 { get; set; }
        public short Swevent5 { get; set; }
        public string Txpager { get; set; } = null!;
        public short Wdcpoption { get; set; }
        public string Txcpuser { get; set; } = null!;
        public string Txcppword { get; set; } = null!;
        public short Swallowjob { get; set; }
    }
}
