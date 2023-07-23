using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Vmmodl
{
    public string Txmodl { get; set; } = null!;

    public decimal Audtdate { get; set; }

    public decimal Audttime { get; set; }

    public string Audtuser { get; set; } = null!;

    public string Audtorg { get; set; } = null!;

    public string Txmanf { get; set; } = null!;

    public string Txmodel { get; set; } = null!;

    public string Txdesc { get; set; } = null!;

    public string Txpartnum { get; set; } = null!;

    public decimal Dtrelease { get; set; }

    public string Txmodlgrp { get; set; } = null!;

    public string Txcomment { get; set; } = null!;

    public short Swwarn { get; set; }

    public short Swusecfld { get; set; }

    public string Txcfov { get; set; } = null!;

    public short Swusepic { get; set; }

    public string Txpicfile { get; set; } = null!;

    public short Swtrkwar { get; set; }

    public short Wdwarrper { get; set; }

    public short Wdpertype { get; set; }

    public short Swtrkmaint { get; set; }

    public short Swtrkmeter { get; set; }

    public string Txmtrdesc { get; set; } = null!;

    public string Txunit { get; set; } = null!;

    public short Swreset { get; set; }

    public string Txschd { get; set; } = null!;

    public short Wdmtrper { get; set; }

    public short Wdmtrpdty { get; set; }

    public string Txempl { get; set; } = null!;

    public short Swprocmtr { get; set; }

    public short Wdmtrwarn { get; set; }

    public short Swtrkcomp { get; set; }

    public decimal Nmstat { get; set; }

    public short Wdresper { get; set; }

    public short Wdresperty { get; set; }

    public short Wddefstat { get; set; }

    public string Txtmpid { get; set; } = null!;

    public short Wdbgtran { get; set; }

    public short Wdautosn { get; set; }

    public string Txautosn { get; set; } = null!;

    public short Wdnumfail { get; set; }

    public short Wdfailpdty { get; set; }

    public int Lnfailpd1 { get; set; }

    public int Lnfailpd2 { get; set; }

    public int Lnfailpd3 { get; set; }

    public int Lnfailpd4 { get; set; }

    public int Lnfailpd5 { get; set; }

    public int Lnequpcnt1 { get; set; }

    public int Lnequpcnt2 { get; set; }

    public int Lnequpcnt3 { get; set; }

    public int Lnequpcnt4 { get; set; }

    public int Lnequpcnt5 { get; set; }

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

    public decimal Dtmtbfcalc { get; set; }

    public short Swagreprc { get; set; }

    public string Txagreserv { get; set; } = null!;

    public decimal Mnagreprc { get; set; }

    public decimal Mnestrepl { get; set; }

    public string Txdefenv { get; set; } = null!;

    public short Swshowcp { get; set; }
}
