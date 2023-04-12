using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Models
{
    public partial class Vmfalt
    {
        public string Txfault { get; set; } = null!;
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Audtuser { get; set; } = null!;
        public string Audtorg { get; set; } = null!;
        public string Txdesc { get; set; } = null!;
        public string Txcomment { get; set; } = null!;
        public short Swwarn { get; set; }
        public short Swusepic { get; set; }
        public string Txpicfile { get; set; } = null!;
        public string Txmodlgrp { get; set; } = null!;
        public short Swfailure { get; set; }
        public string Txfaultgrp { get; set; } = null!;
        public decimal Nmstat { get; set; }
    }
}
