using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmemsk
    {
        public short Wdtype { get; set; }
        public string Txcode { get; set; } = null!;
        public string Txskill { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txcertno { get; set; } = null!;
        public string Txver { get; set; } = null!;
        public string Txlev { get; set; } = null!;
        public decimal Dtcert { get; set; }
        public decimal Dtexpires { get; set; }
        public decimal Dtreview { get; set; }
        public decimal Dttraining { get; set; }
        public decimal Nmnote { get; set; }
    }
}
