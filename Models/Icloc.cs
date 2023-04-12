using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Icloc
    {
        public string Location { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string Address3 { get; set; } = null!;
        public string Address4 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public short Segoverrd { get; set; }
        public decimal Datelastmn { get; set; }
        public short Inactive { get; set; }
        public decimal Dateinactv { get; set; }
        public string Segnum1 { get; set; } = null!;
        public string Segval1 { get; set; } = null!;
        public string Segnum2 { get; set; } = null!;
        public string Segval2 { get; set; } = null!;
        public string Segnum3 { get; set; } = null!;
        public string Segval3 { get; set; } = null!;
        public string Segnum4 { get; set; } = null!;
        public string Segval4 { get; set; } = null!;
        public string Segnum5 { get; set; } = null!;
        public string Segval5 { get; set; } = null!;
        public string Segnum6 { get; set; } = null!;
        public string Segval6 { get; set; } = null!;
        public string Segnum7 { get; set; } = null!;
        public string Segval7 { get; set; } = null!;
        public string Segnum8 { get; set; } = null!;
        public string Segval8 { get; set; } = null!;
        public string Segnum9 { get; set; } = null!;
        public string Segval9 { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phonec { get; set; } = null!;
        public string Faxc { get; set; } = null!;
        public string Emailc { get; set; } = null!;
        public short Loctype { get; set; }
    }
}
