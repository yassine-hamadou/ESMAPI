using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmesum
    {
        public string Txempl { get; set; } = null!;
        public string Txtype { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public int Lncount { get; set; }
        public int Lnppn { get; set; }
        public decimal Nmperctot { get; set; }
        public int Lnduration { get; set; }
        public int Lnsservcnt { get; set; }
        public decimal Mnsservamt { get; set; }
        public decimal Mnsservcst { get; set; }
        public int Lnslabrcnt { get; set; }
        public decimal Mnslabramt { get; set; }
        public decimal Mnslabrcst { get; set; }
        public int Lnssubccnt { get; set; }
        public decimal Mnssubcamt { get; set; }
        public decimal Mnssubccst { get; set; }
        public int Lnsitemcnt { get; set; }
        public decimal Mnsitemamt { get; set; }
        public decimal Mnsitemcst { get; set; }
        public int Lnstimtcnt { get; set; }
        public decimal Mnstimtamt { get; set; }
        public decimal Mnstimtcst { get; set; }
        public decimal Mnbasecst { get; set; }
    }
}
