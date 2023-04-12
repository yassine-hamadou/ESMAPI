using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Icitem
    {
        public string Itemno { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public int Altset { get; set; }
        public string Desc { get; set; } = null!;
        public decimal Datelastmn { get; set; }
        public short Inactive { get; set; }
        public string Itembrkid { get; set; } = null!;
        public string Fmtitemno { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Cntlacct { get; set; } = null!;
        public short Stockitem { get; set; }
        public string Stockunit { get; set; } = null!;
        public string Defpriclst { get; set; } = null!;
        public decimal Unitwgt { get; set; }
        public string Pickingseq { get; set; } = null!;
        public short Serialno { get; set; }
        public string Commodim { get; set; } = null!;
        public decimal Dateinactv { get; set; }
        public string Segment1 { get; set; } = null!;
        public string Segment2 { get; set; } = null!;
        public string Segment3 { get; set; } = null!;
        public string Segment4 { get; set; } = null!;
        public string Segment5 { get; set; } = null!;
        public string Segment6 { get; set; } = null!;
        public string Segment7 { get; set; } = null!;
        public string Segment8 { get; set; } = null!;
        public string Segment9 { get; set; } = null!;
        public string Segment10 { get; set; } = null!;
        public string Comment1 { get; set; } = null!;
        public string Comment2 { get; set; } = null!;
        public string Comment3 { get; set; } = null!;
        public string Comment4 { get; set; } = null!;
        public short Allowonweb { get; set; }
        public short Kitting { get; set; }
        public int Values { get; set; }
        public string Defkitno { get; set; } = null!;
        public short Sellable { get; set; }
        public string Weightunit { get; set; } = null!;
        public string Serialmask { get; set; } = null!;
        public string Nextserfmt { get; set; } = null!;
        public short Suseexpday { get; set; }
        public short Sexpdays { get; set; }
        public short Sdifqtyok { get; set; }
        public int Svalues { get; set; }
        public string Swarycode { get; set; } = null!;
        public string Scontcode { get; set; } = null!;
        public short Scontrece { get; set; }
        public short Swarysold { get; set; }
        public short Swaryreg { get; set; }
        public short Lotitem { get; set; }
        public string Lotmask { get; set; } = null!;
        public string Nextlotfmt { get; set; } = null!;
        public short Luseexpday { get; set; }
        public short Lexpdays { get; set; }
        public short Luseqrnday { get; set; }
        public short Lqrndays { get; set; }
        public short Ldifqtyok { get; set; }
        public int Lvalues { get; set; }
        public string Lwarycode { get; set; } = null!;
        public string Lcontcode { get; set; } = null!;
        public short Lcontrece { get; set; }
        public short Lwarysold { get; set; }
        public short Prevendty { get; set; }
        public string Defbomno { get; set; } = null!;
        public short Seasonal { get; set; }
        public string Tariffcode { get; set; } = null!;
    }
}
