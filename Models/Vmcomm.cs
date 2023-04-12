using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmcomm
    {
        public decimal Nmpstid { get; set; }
        public short Wdpstline { get; set; }
        public string Txempl { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public decimal Nmdocid { get; set; }
        public short Wddocline { get; set; }
        public short Wdpsttype { get; set; }
        public string Txpstid { get; set; } = null!;
        public string Txsite { get; set; } = null!;
        public string Txsitename { get; set; } = null!;
        public string Txzone { get; set; } = null!;
        public decimal Dtposted { get; set; }
        public short Wdlinetype { get; set; }
        public short Wdservtype { get; set; }
        public string Txserv { get; set; } = null!;
        public string Txitem { get; set; } = null!;
        public string Txlocation { get; set; } = null!;
        public string Txcategory { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public decimal Mnrev { get; set; }
        public decimal Mncost { get; set; }
        public decimal Mnmargin { get; set; }
        public short Wdcommcalc { get; set; }
        public decimal Nmsplitper { get; set; }
        public decimal Mnspltrev { get; set; }
        public decimal Mnspltcost { get; set; }
        public decimal Mnspltmarg { get; set; }
        public short Wdcommrate { get; set; }
        public decimal Nmcommrate { get; set; }
        public decimal Mncommamt { get; set; }
        public short Swpayable { get; set; }
        public string Txsctr { get; set; } = null!;
    }
}
