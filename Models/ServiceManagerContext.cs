using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceManagerApi.Models
{
    public partial class ServiceManagerContext : DbContext
    {
        public ServiceManagerContext()
        {
        }

        public ServiceManagerContext(DbContextOptions<ServiceManagerContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Icloc> Iclocs { get; set; } = null!;
        public virtual DbSet<Icitem> Icitems { get; set; } = null!;

        public virtual DbSet<Vmcfoc> Vmcfocs { get; set; } = null!;
        public virtual DbSet<Vmcfoh> Vmcfohs { get; set; } = null!;
        public virtual DbSet<Vmcla> Vmclas { get; set; } = null!;
        public virtual DbSet<Vmcodt> Vmcodts { get; set; } = null!;
        public virtual DbSet<Vmcomm> Vmcomms { get; set; } = null!;
        public virtual DbSet<Vmcon> Vmcons { get; set; } = null!;
        public virtual DbSet<Vmconp> Vmconps { get; set; } = null!;
        public virtual DbSet<Vmempl> Vmempls { get; set; } = null!;
        public virtual DbSet<Vmemsk> Vmemsks { get; set; } = null!;
        public virtual DbSet<Vmeodt> Vmeodts { get; set; } = null!;
        public virtual DbSet<Vmeqcm> Vmeqcms { get; set; } = null!;
        public virtual DbSet<Vmequp> Vmequps { get; set; } = null!;
        public virtual DbSet<Vmesum> Vmesums { get; set; } = null!;
        public virtual DbSet<Vmfalt> Vmfalts { get; set; } = null!;
        public virtual DbSet<Vmmodc> Vmmodcs { get; set; } = null!;
        public virtual DbSet<Vmmodl> Vmmodls { get; set; } = null!;
        public virtual DbSet<Vmmodm> Vmmodms { get; set; } = null!;
        public virtual DbSet<Vmmodum> Vmmoda { get; set; } = null!;
        

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //       {
        //          if (!optionsBuilder.IsConfigured)
        //           {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=173.248.129.77,1439;Database=Tarkwa;User ID=sa;Password=Pa$$w0rd@21;");
        //            }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Icloc>(entity =>
            {
                entity.HasKey(e => e.Location)
                    .HasName("ICLOC_KEY_0");

                entity.ToTable("ICLOC");

                entity.Property(e => e.Location)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION")
                    .IsFixedLength();

                entity.Property(e => e.Address1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Address2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS2")
                    .IsFixedLength();

                entity.Property(e => e.Address3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS3")
                    .IsFixedLength();

                entity.Property(e => e.Address4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS4")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY")
                    .IsFixedLength();

                entity.Property(e => e.Contact)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.Dateinactv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATEINACTV");

                entity.Property(e => e.Datelastmn)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATELASTMN");

                entity.Property(e => e.Desc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESC")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL")
                    .IsFixedLength();

                entity.Property(e => e.Emailc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAILC")
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FAX")
                    .IsFixedLength();

                entity.Property(e => e.Faxc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FAXC")
                    .IsFixedLength();

                entity.Property(e => e.Inactive).HasColumnName("INACTIVE");

                entity.Property(e => e.Loctype).HasColumnName("LOCTYPE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PHONE")
                    .IsFixedLength();

                entity.Property(e => e.Phonec)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PHONEC")
                    .IsFixedLength();

                entity.Property(e => e.Segnum1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM1")
                    .IsFixedLength();

                entity.Property(e => e.Segnum2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM2")
                    .IsFixedLength();

                entity.Property(e => e.Segnum3)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM3")
                    .IsFixedLength();

                entity.Property(e => e.Segnum4)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM4")
                    .IsFixedLength();

                entity.Property(e => e.Segnum5)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM5")
                    .IsFixedLength();

                entity.Property(e => e.Segnum6)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM6")
                    .IsFixedLength();

                entity.Property(e => e.Segnum7)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM7")
                    .IsFixedLength();

                entity.Property(e => e.Segnum8)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM8")
                    .IsFixedLength();

                entity.Property(e => e.Segnum9)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEGNUM9")
                    .IsFixedLength();

                entity.Property(e => e.Segoverrd).HasColumnName("SEGOVERRD");

                entity.Property(e => e.Segval1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL1")
                    .IsFixedLength();

                entity.Property(e => e.Segval2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL2")
                    .IsFixedLength();

                entity.Property(e => e.Segval3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL3")
                    .IsFixedLength();

                entity.Property(e => e.Segval4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL4")
                    .IsFixedLength();

                entity.Property(e => e.Segval5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL5")
                    .IsFixedLength();

                entity.Property(e => e.Segval6)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL6")
                    .IsFixedLength();

                entity.Property(e => e.Segval7)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL7")
                    .IsFixedLength();

                entity.Property(e => e.Segval8)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL8")
                    .IsFixedLength();

                entity.Property(e => e.Segval9)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SEGVAL9")
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STATE")
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ZIP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Icitem>(entity =>
            {
                entity.HasKey(e => e.Itemno)
                    .HasName("ICITEM_KEY_0");

                entity.ToTable("ICITEM");

                entity.HasIndex(e => new { e.Category, e.Itemno }, "KEY_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.Altset, e.Itemno }, "KEY_2")
                    .IsUnique();

                entity.HasIndex(e => e.Fmtitemno, "KEY_3")
                    .IsUnique();

                entity.HasIndex(e => new { e.Desc, e.Itemno }, "KEY_4")
                    .IsUnique();

                entity.HasIndex(e => new { e.Allowonweb, e.Itemno }, "KEY_5")
                    .IsUnique();

                entity.Property(e => e.Itemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNO")
                    .IsFixedLength();

                entity.Property(e => e.Allowonweb).HasColumnName("ALLOWONWEB");

                entity.Property(e => e.Altset).HasColumnName("ALTSET");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Category)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY")
                    .IsFixedLength();

                entity.Property(e => e.Cntlacct)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CNTLACCT")
                    .IsFixedLength();

                entity.Property(e => e.Comment1)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT1")
                    .IsFixedLength();

                entity.Property(e => e.Comment2)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT2")
                    .IsFixedLength();

                entity.Property(e => e.Comment3)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT3")
                    .IsFixedLength();

                entity.Property(e => e.Comment4)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT4")
                    .IsFixedLength();

                entity.Property(e => e.Commodim)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("COMMODIM")
                    .IsFixedLength();

                entity.Property(e => e.Dateinactv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATEINACTV");

                entity.Property(e => e.Datelastmn)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATELASTMN");

                entity.Property(e => e.Defbomno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFBOMNO")
                    .IsFixedLength();

                entity.Property(e => e.Defkitno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFKITNO")
                    .IsFixedLength();

                entity.Property(e => e.Defpriclst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFPRICLST")
                    .IsFixedLength();

                entity.Property(e => e.Desc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESC")
                    .IsFixedLength();

                entity.Property(e => e.Fmtitemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("FMTITEMNO")
                    .IsFixedLength();

                entity.Property(e => e.Inactive).HasColumnName("INACTIVE");

                entity.Property(e => e.Itembrkid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ITEMBRKID")
                    .IsFixedLength();

                entity.Property(e => e.Kitting).HasColumnName("KITTING");

                entity.Property(e => e.Lcontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LCONTCODE")
                    .IsFixedLength();

                entity.Property(e => e.Lcontrece).HasColumnName("LCONTRECE");

                entity.Property(e => e.Ldifqtyok).HasColumnName("LDIFQTYOK");

                entity.Property(e => e.Lexpdays).HasColumnName("LEXPDAYS");

                entity.Property(e => e.Lotitem).HasColumnName("LOTITEM");

                entity.Property(e => e.Lotmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LOTMASK")
                    .IsFixedLength();

                entity.Property(e => e.Lqrndays).HasColumnName("LQRNDAYS");

                entity.Property(e => e.Luseexpday).HasColumnName("LUSEEXPDAY");

                entity.Property(e => e.Luseqrnday).HasColumnName("LUSEQRNDAY");

                entity.Property(e => e.Lvalues).HasColumnName("LVALUES");

                entity.Property(e => e.Lwarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LWARYCODE")
                    .IsFixedLength();

                entity.Property(e => e.Lwarysold).HasColumnName("LWARYSOLD");

                entity.Property(e => e.Nextlotfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NEXTLOTFMT")
                    .IsFixedLength();

                entity.Property(e => e.Nextserfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSERFMT")
                    .IsFixedLength();

                entity.Property(e => e.Pickingseq)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PICKINGSEQ")
                    .IsFixedLength();

                entity.Property(e => e.Prevendty).HasColumnName("PREVENDTY");

                entity.Property(e => e.Scontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SCONTCODE")
                    .IsFixedLength();

                entity.Property(e => e.Scontrece).HasColumnName("SCONTRECE");

                entity.Property(e => e.Sdifqtyok).HasColumnName("SDIFQTYOK");

                entity.Property(e => e.Seasonal).HasColumnName("SEASONAL");

                entity.Property(e => e.Segment1)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT1")
                    .IsFixedLength();

                entity.Property(e => e.Segment10)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT10")
                    .IsFixedLength();

                entity.Property(e => e.Segment2)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT2")
                    .IsFixedLength();

                entity.Property(e => e.Segment3)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT3")
                    .IsFixedLength();

                entity.Property(e => e.Segment4)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT4")
                    .IsFixedLength();

                entity.Property(e => e.Segment5)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT5")
                    .IsFixedLength();

                entity.Property(e => e.Segment6)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT6")
                    .IsFixedLength();

                entity.Property(e => e.Segment7)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT7")
                    .IsFixedLength();

                entity.Property(e => e.Segment8)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT8")
                    .IsFixedLength();

                entity.Property(e => e.Segment9)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT9")
                    .IsFixedLength();

                entity.Property(e => e.Sellable).HasColumnName("SELLABLE");

                entity.Property(e => e.Serialmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SERIALMASK")
                    .IsFixedLength();

                entity.Property(e => e.Serialno).HasColumnName("SERIALNO");

                entity.Property(e => e.Sexpdays).HasColumnName("SEXPDAYS");

                entity.Property(e => e.Stockitem).HasColumnName("STOCKITEM");

                entity.Property(e => e.Stockunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STOCKUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Suseexpday).HasColumnName("SUSEEXPDAY");

                entity.Property(e => e.Svalues).HasColumnName("SVALUES");

                entity.Property(e => e.Swarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SWARYCODE")
                    .IsFixedLength();

                entity.Property(e => e.Swaryreg).HasColumnName("SWARYREG");

                entity.Property(e => e.Swarysold).HasColumnName("SWARYSOLD");

                entity.Property(e => e.Tariffcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TARIFFCODE")
                    .IsFixedLength();

                entity.Property(e => e.Unitwgt)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("UNITWGT");

                entity.Property(e => e.Values).HasColumnName("VALUES");

                entity.Property(e => e.Weightunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("WEIGHTUNIT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vmcfoh>(entity =>
            {
                entity.HasKey(e => new { e.Wdtype, e.Txcfov })
                    .HasName("VMCFOH_KEY_0");

                entity.ToTable("VMCFOH");

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");

                entity.Property(e => e.Txcfov)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCFOV")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Wdnextseq).HasColumnName("WDNEXTSEQ");
            });

            modelBuilder.Entity<Vmcomm>(entity =>
            {
                entity.HasKey(e => new { e.Nmpstid, e.Wdpstline, e.Txempl })
                    .HasName("VMCOMM_KEY_0");

                entity.ToTable("VMCOMM");

                entity.HasIndex(e => new { e.Nmdocid, e.Wddocline, e.Txempl }, "KEY_1");

                entity.HasIndex(e => new { e.Txempl, e.Nmpstid, e.Wdpstline }, "KEY_2")
                    .IsUnique();

                entity.Property(e => e.Nmpstid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMPSTID");

                entity.Property(e => e.Wdpstline).HasColumnName("WDPSTLINE");

                entity.Property(e => e.Txempl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEMPL")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtposted)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTPOSTED");

                entity.Property(e => e.Mncommamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNCOMMAMT");

                entity.Property(e => e.Mncost)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNCOST");

                entity.Property(e => e.Mnmargin)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMARGIN");

                entity.Property(e => e.Mnrev)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNREV");

                entity.Property(e => e.Mnspltcost)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSPLTCOST");

                entity.Property(e => e.Mnspltmarg)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSPLTMARG");

                entity.Property(e => e.Mnspltrev)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSPLTREV");

                entity.Property(e => e.Nmcommrate)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMMRATE");

                entity.Property(e => e.Nmdocid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMDOCID");

                entity.Property(e => e.Nmsplitper)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMSPLITPER");

                entity.Property(e => e.Swpayable).HasColumnName("SWPAYABLE");

                entity.Property(e => e.Txcategory)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCATEGORY")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Txitem)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("TXITEM")
                    .IsFixedLength();

                entity.Property(e => e.Txlocation)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXLOCATION")
                    .IsFixedLength();

                entity.Property(e => e.Txpstid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXPSTID")
                    .IsFixedLength();

                entity.Property(e => e.Txsctr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSCTR")
                    .IsFixedLength();

                entity.Property(e => e.Txserv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSERV")
                    .IsFixedLength();

                entity.Property(e => e.Txsite)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSITE")
                    .IsFixedLength();

                entity.Property(e => e.Txsitename)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXSITENAME")
                    .IsFixedLength();

                entity.Property(e => e.Txzone)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXZONE")
                    .IsFixedLength();

                entity.Property(e => e.Wdcommcalc).HasColumnName("WDCOMMCALC");

                entity.Property(e => e.Wdcommrate).HasColumnName("WDCOMMRATE");

                entity.Property(e => e.Wddocline).HasColumnName("WDDOCLINE");

                entity.Property(e => e.Wdlinetype).HasColumnName("WDLINETYPE");

                entity.Property(e => e.Wdpsttype).HasColumnName("WDPSTTYPE");

                entity.Property(e => e.Wdservtype).HasColumnName("WDSERVTYPE");
            });

            modelBuilder.Entity<Vmcon>(entity =>
            {
                entity.HasKey(e => new { e.Nmcont, e.Txsite })
                    .HasName("VMCONS_KEY_0");

                entity.ToTable("VMCONS");

                entity.HasIndex(e => new { e.Txsite, e.Nmcont }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Nmcont)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCONT");

                entity.Property(e => e.Txsite)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSITE")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Swcpenable).HasColumnName("SWCPENABLE");

                entity.Property(e => e.Txarea3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXAREA3")
                    .IsFixedLength();

                entity.Property(e => e.Txarea4)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXAREA4")
                    .IsFixedLength();

                entity.Property(e => e.Wdarea1).HasColumnName("WDAREA1");

                entity.Property(e => e.Wdarea2).HasColumnName("WDAREA2");
            });

            modelBuilder.Entity<Vmconp>(entity =>
            {
                entity.HasKey(e => e.Nmcont)
                    .HasName("VMCONP_KEY_0");

                entity.ToTable("VMCONP");

                entity.HasIndex(e => e.Txname, "KEY_1");

                entity.HasIndex(e => e.Txphone, "KEY_2");

                entity.HasIndex(e => e.Txmobile, "KEY_3");

                entity.HasIndex(e => e.Txemail, "KEY_4");

                entity.HasIndex(e => e.Txcpuser, "KEY_5");

                entity.Property(e => e.Nmcont)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCONT");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtlastcont)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTCONT");

                entity.Property(e => e.Swactive).HasColumnName("SWACTIVE");

                entity.Property(e => e.Swallowjob).HasColumnName("SWALLOWJOB");

                entity.Property(e => e.Swevent1).HasColumnName("SWEVENT1");

                entity.Property(e => e.Swevent2).HasColumnName("SWEVENT2");

                entity.Property(e => e.Swevent3).HasColumnName("SWEVENT3");

                entity.Property(e => e.Swevent4).HasColumnName("SWEVENT4");

                entity.Property(e => e.Swevent5).HasColumnName("SWEVENT5");

                entity.Property(e => e.Swusepic).HasColumnName("SWUSEPIC");

                entity.Property(e => e.Txcppword)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCPPWORD")
                    .IsFixedLength();

                entity.Property(e => e.Txcpuser)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCPUSER")
                    .IsFixedLength();

                entity.Property(e => e.Txemail)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TXEMAIL")
                    .IsFixedLength();

                entity.Property(e => e.Txemailpr)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TXEMAILPR")
                    .IsFixedLength();

                entity.Property(e => e.Txext)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TXEXT")
                    .IsFixedLength();

                entity.Property(e => e.Txfax)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXFAX")
                    .IsFixedLength();

                entity.Property(e => e.Txloc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXLOC")
                    .IsFixedLength();

                entity.Property(e => e.Txmobile)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXMOBILE")
                    .IsFixedLength();

                entity.Property(e => e.Txname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXNAME")
                    .IsFixedLength();

                entity.Property(e => e.Txpager)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXPAGER")
                    .IsFixedLength();

                entity.Property(e => e.Txphone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPHONE")
                    .IsFixedLength();

                entity.Property(e => e.Txphonepr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPHONEPR")
                    .IsFixedLength();

                entity.Property(e => e.Txpicfile)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPICFILE")
                    .IsFixedLength();

                entity.Property(e => e.Txposition)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXPOSITION")
                    .IsFixedLength();

                entity.Property(e => e.Txrole)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXROLE")
                    .IsFixedLength();

                entity.Property(e => e.Txskilllev)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXSKILLLEV")
                    .IsFixedLength();

                entity.Property(e => e.Wdcpoption).HasColumnName("WDCPOPTION");
            });
            modelBuilder.Entity<Vmcodt>(entity =>
            {
                entity.HasKey(e => new { e.Nmpstid, e.Wdtrannum, e.Nmcomm, e.Nmseqnum })
                    .HasName("VMCODT_KEY_0");

                entity.ToTable("VMCODT");

                entity.Property(e => e.Nmpstid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMPSTID");

                entity.Property(e => e.Wdtrannum).HasColumnName("WDTRANNUM");

                entity.Property(e => e.Nmcomm)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCOMM");

                entity.Property(e => e.Nmseqnum)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("NMSEQNUM");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Txcomment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMMENT")
                    .IsFixedLength();

                entity.Property(e => e.Txobjcapt)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXOBJCAPT")
                    .IsFixedLength();

                entity.Property(e => e.Txpathcls)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXPATHCLS")
                    .IsFixedLength();

                entity.Property(e => e.Wdobjtype).HasColumnName("WDOBJTYPE");

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");
            });

            modelBuilder.Entity<Vmcla>(entity =>
            {
                entity.HasKey(e => new { e.Wdtype, e.Txclass })
                    .HasName("VMCLAS_KEY_0");

                entity.ToTable("VMCLAS");

                entity.HasIndex(e => new { e.Txclass, e.Wdtype }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");

                entity.Property(e => e.Txclass)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCLASS")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Nmescperc)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMESCPERC");

                entity.Property(e => e.Nmstat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMSTAT");

                entity.Property(e => e.Txcomments)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMMENTS")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Wdperiod).HasColumnName("WDPERIOD");

                entity.Property(e => e.Wdpertype).HasColumnName("WDPERTYPE");
            });

            modelBuilder.Entity<Vmequp>(entity =>
            {
                entity.HasKey(e => e.Txequp)
                    .HasName("VMEQUP_KEY_0");

                entity.ToTable("VMEQUP");

                entity.HasIndex(e => new { e.Txsite, e.Txequp }, "KEY_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.Wdtrkmaint, e.Txsite, e.Txequp }, "KEY_10");

                entity.HasIndex(e => new { e.Txsite, e.Txmodl, e.Txequp }, "KEY_11")
                    .IsUnique();

                entity.HasIndex(e => new { e.Wdtype, e.Txsite, e.Txequp }, "KEY_12")
                    .IsUnique();

                entity.HasIndex(e => new { e.Txunformsn, e.Txmodl }, "KEY_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.Txmodl, e.Txequp }, "KEY_3")
                    .IsUnique();

                entity.HasIndex(e => new { e.Wdtype, e.Txequp }, "KEY_4")
                    .IsUnique();

                entity.HasIndex(e => new { e.Swtrkmaint, e.Txequp }, "KEY_5")
                    .IsUnique();

                entity.HasIndex(e => new { e.Swtrkmtr, e.Txequp }, "KEY_6")
                    .IsUnique();

                entity.HasIndex(e => e.Nmcfoc, "KEY_7");

                entity.HasIndex(e => new { e.Txsite, e.Wdarea1, e.Wdarea2, e.Txarea3, e.Txarea4, e.Txequp }, "KEY_8");

                entity.HasIndex(e => e.Txregono, "KEY_9");

                entity.Property(e => e.Txequp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEQUP")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtcustom1)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCUSTOM1");

                entity.Property(e => e.Dtcustom2)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCUSTOM2");

                entity.Property(e => e.Dtcustom3)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCUSTOM3");

                entity.Property(e => e.Dteol)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTEOL");

                entity.Property(e => e.Dtinstall)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTINSTALL");

                entity.Property(e => e.Dtinv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTINV");

                entity.Property(e => e.Dtlastlev1)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV1");

                entity.Property(e => e.Dtlastlev2)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV2");

                entity.Property(e => e.Dtlastlev3)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV3");

                entity.Property(e => e.Dtlastlev4)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV4");

                entity.Property(e => e.Dtlastlev5)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV5");

                entity.Property(e => e.Dtlastlev6)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV6");

                entity.Property(e => e.Dtlastlev7)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV7");

                entity.Property(e => e.Dtlastlev8)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV8");

                entity.Property(e => e.Dtlastlev9)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLEV9");

                entity.Property(e => e.Dtlastlv10)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV10");

                entity.Property(e => e.Dtlastlv11)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV11");

                entity.Property(e => e.Dtlastlv12)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV12");

                entity.Property(e => e.Dtlastlv13)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV13");

                entity.Property(e => e.Dtlastlv14)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV14");

                entity.Property(e => e.Dtlastlv15)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTLV15");

                entity.Property(e => e.Dtlastmain)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTMAIN");

                entity.Property(e => e.Dtlastserv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTLASTSERV");

                entity.Property(e => e.Dtnextadvm)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTNEXTADVM");

                entity.Property(e => e.Dtnextserv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTNEXTSERV");

                entity.Property(e => e.Dtpo)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTPO");

                entity.Property(e => e.Dtwarren)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTWARREN");

                entity.Property(e => e.Dtwarrst)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTWARRST");

                entity.Property(e => e.Lnltuniq).HasColumnName("LNLTUNIQ");

                entity.Property(e => e.Mninvcost)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNINVCOST");

                entity.Property(e => e.Mninvprice)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNINVPRICE");

                entity.Property(e => e.Nmcfoc)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCFOC");

                entity.Property(e => e.Nmcont)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCONT");

                entity.Property(e => e.Nmlastjob)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMLASTJOB");

                entity.Property(e => e.Nmlat)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("NMLAT");

                entity.Property(e => e.Nmlong)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("NMLONG");

                entity.Property(e => e.Nmmtrwen)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMMTRWEN");

                entity.Property(e => e.Nmmtrwst)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMMTRWST");

                entity.Property(e => e.Nmparenteq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMPARENTEQ");

                entity.Property(e => e.Nmstat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMSTAT");

                entity.Property(e => e.Nmtrfdocid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMTRFDOCID");

                entity.Property(e => e.Swactive).HasColumnName("SWACTIVE");

                entity.Property(e => e.Swallowsch).HasColumnName("SWALLOWSCH");

                entity.Property(e => e.Swsegovrd).HasColumnName("SWSEGOVRD");

                entity.Property(e => e.Swshowcp).HasColumnName("SWSHOWCP");

                entity.Property(e => e.Swsnumber).HasColumnName("SWSNUMBER");

                entity.Property(e => e.Swtrkmaint).HasColumnName("SWTRKMAINT");

                entity.Property(e => e.Swtrkmtr).HasColumnName("SWTRKMTR");

                entity.Property(e => e.Swtrkwar).HasColumnName("SWTRKWAR");

                entity.Property(e => e.Swusecfld).HasColumnName("SWUSECFLD");

                entity.Property(e => e.Txarea3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXAREA3")
                    .IsFixedLength();

                entity.Property(e => e.Txarea4)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXAREA4")
                    .IsFixedLength();

                entity.Property(e => e.Txcont)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TXCONT")
                    .IsFixedLength();

                entity.Property(e => e.Txinsenv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXINSENV")
                    .IsFixedLength();

                entity.Property(e => e.Txintsite)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXINTSITE")
                    .IsFixedLength();

                entity.Property(e => e.Txinv)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXINV")
                    .IsFixedLength();

                entity.Property(e => e.Txitem)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("TXITEM")
                    .IsFixedLength();

                entity.Property(e => e.Txitemloc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXITEMLOC")
                    .IsFixedLength();

                entity.Property(e => e.Txlastjob)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXLASTJOB")
                    .IsFixedLength();

                entity.Property(e => e.Txltdoc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLTDOC")
                    .IsFixedLength();

                entity.Property(e => e.Txmodl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXMODL")
                    .IsFixedLength();

                entity.Property(e => e.Txpo)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXPO")
                    .IsFixedLength();

                entity.Property(e => e.Txregono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXREGONO")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM1")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM2")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum3)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM3")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum4)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM4")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum5)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM5")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum6)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM6")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum7)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM7")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum8)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM8")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum9)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM9")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL1")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL2")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL3")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL4")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL5")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval6)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL6")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval7)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL7")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval8)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL8")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval9)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL9")
                    .IsFixedLength();

                entity.Property(e => e.Txserv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSERV")
                    .IsFixedLength();

                entity.Property(e => e.Txsite)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSITE")
                    .IsFixedLength();

                entity.Property(e => e.Txunformsn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TXUNFORMSN")
                    .IsFixedLength();

                entity.Property(e => e.Txvend)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXVEND")
                    .IsFixedLength();

                entity.Property(e => e.Txvendname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXVENDNAME")
                    .IsFixedLength();

                entity.Property(e => e.Txwarrmtr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXWARRMTR")
                    .IsFixedLength();

                entity.Property(e => e.Wdarea1).HasColumnName("WDAREA1");

                entity.Property(e => e.Wdarea2).HasColumnName("WDAREA2");

                entity.Property(e => e.Wdlastjobt).HasColumnName("WDLASTJOBT");

                entity.Property(e => e.Wdlevcnt1).HasColumnName("WDLEVCNT1");

                entity.Property(e => e.Wdlevcnt10).HasColumnName("WDLEVCNT10");

                entity.Property(e => e.Wdlevcnt11).HasColumnName("WDLEVCNT11");

                entity.Property(e => e.Wdlevcnt12).HasColumnName("WDLEVCNT12");

                entity.Property(e => e.Wdlevcnt13).HasColumnName("WDLEVCNT13");

                entity.Property(e => e.Wdlevcnt14).HasColumnName("WDLEVCNT14");

                entity.Property(e => e.Wdlevcnt15).HasColumnName("WDLEVCNT15");

                entity.Property(e => e.Wdlevcnt2).HasColumnName("WDLEVCNT2");

                entity.Property(e => e.Wdlevcnt3).HasColumnName("WDLEVCNT3");

                entity.Property(e => e.Wdlevcnt4).HasColumnName("WDLEVCNT4");

                entity.Property(e => e.Wdlevcnt5).HasColumnName("WDLEVCNT5");

                entity.Property(e => e.Wdlevcnt6).HasColumnName("WDLEVCNT6");

                entity.Property(e => e.Wdlevcnt7).HasColumnName("WDLEVCNT7");

                entity.Property(e => e.Wdlevcnt8).HasColumnName("WDLEVCNT8");

                entity.Property(e => e.Wdlevcnt9).HasColumnName("WDLEVCNT9");

                entity.Property(e => e.Wdmtrwarr).HasColumnName("WDMTRWARR");

                entity.Property(e => e.Wdmtrwmeth).HasColumnName("WDMTRWMETH");

                entity.Property(e => e.Wdresper).HasColumnName("WDRESPER");

                entity.Property(e => e.Wdresperty).HasColumnName("WDRESPERTY");

                entity.Property(e => e.Wdstatus).HasColumnName("WDSTATUS");

                entity.Property(e => e.Wdtrkmaint).HasColumnName("WDTRKMAINT");

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");
            });

            modelBuilder.Entity<Vmmodl>(entity =>
            {
                entity.HasKey(e => e.Txmodl)
                    .HasName("VMMODL_KEY_0");

                entity.ToTable("VMMODL");

                entity.HasIndex(e => new { e.Txmanf, e.Txmodel }, "KEY_1");

                entity.HasIndex(e => e.Txmodlgrp, "KEY_2");

                entity.HasIndex(e => new { e.Txmodel, e.Txmanf }, "KEY_3");

                entity.Property(e => e.Txmodl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXMODL")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtmtbfcalc)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTMTBFCALC");

                entity.Property(e => e.Dtrelease)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTRELEASE");

                entity.Property(e => e.Lnequpcnt1).HasColumnName("LNEQUPCNT1");

                entity.Property(e => e.Lnequpcnt2).HasColumnName("LNEQUPCNT2");

                entity.Property(e => e.Lnequpcnt3).HasColumnName("LNEQUPCNT3");

                entity.Property(e => e.Lnequpcnt4).HasColumnName("LNEQUPCNT4");

                entity.Property(e => e.Lnequpcnt5).HasColumnName("LNEQUPCNT5");

                entity.Property(e => e.Lnfailcnt1).HasColumnName("LNFAILCNT1");

                entity.Property(e => e.Lnfailcnt2).HasColumnName("LNFAILCNT2");

                entity.Property(e => e.Lnfailcnt3).HasColumnName("LNFAILCNT3");

                entity.Property(e => e.Lnfailcnt4).HasColumnName("LNFAILCNT4");

                entity.Property(e => e.Lnfailcnt5).HasColumnName("LNFAILCNT5");

                entity.Property(e => e.Lnfailpd1).HasColumnName("LNFAILPD1");

                entity.Property(e => e.Lnfailpd2).HasColumnName("LNFAILPD2");

                entity.Property(e => e.Lnfailpd3).HasColumnName("LNFAILPD3");

                entity.Property(e => e.Lnfailpd4).HasColumnName("LNFAILPD4");

                entity.Property(e => e.Lnfailpd5).HasColumnName("LNFAILPD5");

                entity.Property(e => e.Lnfaltcnt1).HasColumnName("LNFALTCNT1");

                entity.Property(e => e.Lnfaltcnt2).HasColumnName("LNFALTCNT2");

                entity.Property(e => e.Lnfaltcnt3).HasColumnName("LNFALTCNT3");

                entity.Property(e => e.Lnfaltcnt4).HasColumnName("LNFALTCNT4");

                entity.Property(e => e.Lnfaltcnt5).HasColumnName("LNFALTCNT5");

                entity.Property(e => e.Mnagreprc)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("MNAGREPRC");

                entity.Property(e => e.Mnestrepl)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("MNESTREPL");

                entity.Property(e => e.Nmstat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMSTAT");

                entity.Property(e => e.Swagreprc).HasColumnName("SWAGREPRC");

                entity.Property(e => e.Swprocmtr).HasColumnName("SWPROCMTR");

                entity.Property(e => e.Swreset).HasColumnName("SWRESET");

                entity.Property(e => e.Swshowcp).HasColumnName("SWSHOWCP");

                entity.Property(e => e.Swtrkcomp).HasColumnName("SWTRKCOMP");

                entity.Property(e => e.Swtrkmaint).HasColumnName("SWTRKMAINT");

                entity.Property(e => e.Swtrkmeter).HasColumnName("SWTRKMETER");

                entity.Property(e => e.Swtrkwar).HasColumnName("SWTRKWAR");

                entity.Property(e => e.Swusecfld).HasColumnName("SWUSECFLD");

                entity.Property(e => e.Swusepic).HasColumnName("SWUSEPIC");

                entity.Property(e => e.Swwarn).HasColumnName("SWWARN");

                entity.Property(e => e.Txagreserv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXAGRESERV")
                    .IsFixedLength();

                entity.Property(e => e.Txautosn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TXAUTOSN")
                    .IsFixedLength();

                entity.Property(e => e.Txcfov)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCFOV")
                    .IsFixedLength();

                entity.Property(e => e.Txcomment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMMENT")
                    .IsFixedLength();

                entity.Property(e => e.Txdefenv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXDEFENV")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Txempl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEMPL")
                    .IsFixedLength();

                entity.Property(e => e.Txmanf)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXMANF")
                    .IsFixedLength();

                entity.Property(e => e.Txmodel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXMODEL")
                    .IsFixedLength();

                entity.Property(e => e.Txmodlgrp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXMODLGRP")
                    .IsFixedLength();

                entity.Property(e => e.Txmtrdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXMTRDESC")
                    .IsFixedLength();

                entity.Property(e => e.Txpartnum)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPARTNUM")
                    .IsFixedLength();

                entity.Property(e => e.Txpicfile)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPICFILE")
                    .IsFixedLength();

                entity.Property(e => e.Txschd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSCHD")
                    .IsFixedLength();

                entity.Property(e => e.Txtmpid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXTMPID")
                    .IsFixedLength();

                entity.Property(e => e.Txunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TXUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Wdautosn).HasColumnName("WDAUTOSN");

                entity.Property(e => e.Wdbgtran).HasColumnName("WDBGTRAN");

                entity.Property(e => e.Wddefstat).HasColumnName("WDDEFSTAT");

                entity.Property(e => e.Wdfailpdty).HasColumnName("WDFAILPDTY");

                entity.Property(e => e.Wdmtrpdty).HasColumnName("WDMTRPDTY");

                entity.Property(e => e.Wdmtrper).HasColumnName("WDMTRPER");

                entity.Property(e => e.Wdmtrwarn).HasColumnName("WDMTRWARN");

                entity.Property(e => e.Wdnumfail).HasColumnName("WDNUMFAIL");

                entity.Property(e => e.Wdpertype).HasColumnName("WDPERTYPE");

                entity.Property(e => e.Wdresper).HasColumnName("WDRESPER");

                entity.Property(e => e.Wdresperty).HasColumnName("WDRESPERTY");

                entity.Property(e => e.Wdwarrper).HasColumnName("WDWARRPER");
            });

            modelBuilder.Entity<Vmempl>(entity =>
            {
                entity.HasKey(e => e.Txempl)
                    .HasName("VMEMPL_KEY_0");

                entity.ToTable("VMEMPL");

                entity.HasIndex(e => e.Nmcfoc, "KEY_1");

                entity.Property(e => e.Txempl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEMPL")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtbirthday)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTBIRTHDAY");

                entity.Property(e => e.Dtclrcomm)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCLRCOMM");

                entity.Property(e => e.Dtcommence)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCOMMENCE");

                entity.Property(e => e.Lnbackcol).HasColumnName("LNBACKCOL");

                entity.Property(e => e.Lnforecol).HasColumnName("LNFORECOL");

                entity.Property(e => e.Mnbasecst)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("MNBASECST");

                entity.Property(e => e.Mncommbal)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNCOMMBAL");

                entity.Property(e => e.Mncomsbal)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNCOMSBAL");

                entity.Property(e => e.Mnmaxrate1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMAXRATE1");

                entity.Property(e => e.Mnmaxrate2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMAXRATE2");

                entity.Property(e => e.Mnmaxrate3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMAXRATE3");

                entity.Property(e => e.Mnmaxrate4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMAXRATE4");

                entity.Property(e => e.Mnmaxrate5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNMAXRATE5");

                entity.Property(e => e.Nmcfoc)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCFOC");

                entity.Property(e => e.Nmcomrate1)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMRATE1");

                entity.Property(e => e.Nmcomrate2)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMRATE2");

                entity.Property(e => e.Nmcomrate3)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMRATE3");

                entity.Property(e => e.Nmcomrate4)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMRATE4");

                entity.Property(e => e.Nmcomrate5)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMCOMRATE5");

                entity.Property(e => e.Nmlat)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("NMLAT");

                entity.Property(e => e.Nmlldperc1)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMLLDPERC1");

                entity.Property(e => e.Nmlldperc2)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMLLDPERC2");

                entity.Property(e => e.Nmlldperc3)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMLLDPERC3");

                entity.Property(e => e.Nmlldperc4)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMLLDPERC4");

                entity.Property(e => e.Nmlldperc5)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMLLDPERC5");

                entity.Property(e => e.Nmlong)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("NMLONG");

                entity.Property(e => e.Nmstat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMSTAT");

                entity.Property(e => e.Swactive).HasColumnName("SWACTIVE");

                entity.Property(e => e.Swsctrrstr).HasColumnName("SWSCTRRSTR");

                entity.Property(e => e.Swsegovrd).HasColumnName("SWSEGOVRD");

                entity.Property(e => e.Swusecfld).HasColumnName("SWUSECFLD");

                entity.Property(e => e.Txaddress1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Txaddress2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXADDRESS2")
                    .IsFixedLength();

                entity.Property(e => e.Txaddress3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXADDRESS3")
                    .IsFixedLength();

                entity.Property(e => e.Txaddress4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXADDRESS4")
                    .IsFixedLength();

                entity.Property(e => e.Txcfov)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCFOV")
                    .IsFixedLength();

                entity.Property(e => e.Txcity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXCITY")
                    .IsFixedLength();

                entity.Property(e => e.Txcountry)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXCOUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.Txdept)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TXDEPT")
                    .IsFixedLength();

                entity.Property(e => e.Txemail)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TXEMAIL")
                    .IsFixedLength();

                entity.Property(e => e.Txemplnum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXEMPLNUM")
                    .IsFixedLength();

                entity.Property(e => e.Txhomeph)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXHOMEPH")
                    .IsFixedLength();

                entity.Property(e => e.Txitemloc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXITEMLOC")
                    .IsFixedLength();

                entity.Property(e => e.Txllddesc1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLLDDESC1")
                    .IsFixedLength();

                entity.Property(e => e.Txllddesc2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLLDDESC2")
                    .IsFixedLength();

                entity.Property(e => e.Txllddesc3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLLDDESC3")
                    .IsFixedLength();

                entity.Property(e => e.Txllddesc4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLLDDESC4")
                    .IsFixedLength();

                entity.Property(e => e.Txllddesc5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXLLDDESC5")
                    .IsFixedLength();

                entity.Property(e => e.Txmobile)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXMOBILE")
                    .IsFixedLength();

                entity.Property(e => e.Txname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXNAME")
                    .IsFixedLength();

                entity.Property(e => e.Txpassword)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXPASSWORD")
                    .IsFixedLength();

                entity.Property(e => e.Txpayroll)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXPAYROLL")
                    .IsFixedLength();

                entity.Property(e => e.Txposition)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXPOSITION")
                    .IsFixedLength();

                entity.Property(e => e.Txsctr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSCTR")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM1")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM2")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum3)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM3")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum4)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM4")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum5)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM5")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum6)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM6")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum7)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM7")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum8)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM8")
                    .IsFixedLength();

                entity.Property(e => e.Txsegnum9)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGNUM9")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL1")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL2")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL3")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL4")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL5")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval6)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL6")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval7)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL7")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval8)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL8")
                    .IsFixedLength();

                entity.Property(e => e.Txsegval9)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TXSEGVAL9")
                    .IsFixedLength();

                entity.Property(e => e.Txserv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXSERV")
                    .IsFixedLength();

                entity.Property(e => e.Txstate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXSTATE")
                    .IsFixedLength();

                entity.Property(e => e.Txwkext)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TXWKEXT")
                    .IsFixedLength();

                entity.Property(e => e.Txwkphone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXWKPHONE")
                    .IsFixedLength();

                entity.Property(e => e.Txzip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TXZIP")
                    .IsFixedLength();

                entity.Property(e => e.Wdcommtype).HasColumnName("WDCOMMTYPE");

                entity.Property(e => e.Wdepoption).HasColumnName("WDEPOPTION");

                entity.Property(e => e.Wdnumrates).HasColumnName("WDNUMRATES");

                entity.Property(e => e.Wdpayroll).HasColumnName("WDPAYROLL");
            });

            modelBuilder.Entity<Vmemsk>(entity =>
            {
                entity.HasKey(e => new { e.Wdtype, e.Txcode, e.Txskill })
                    .HasName("VMEMSK_KEY_0");

                entity.ToTable("VMEMSK");

                entity.HasIndex(e => new { e.Txskill, e.Wdtype, e.Txcode }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");

                entity.Property(e => e.Txcode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCODE")
                    .IsFixedLength();

                entity.Property(e => e.Txskill)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSKILL")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtcert)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCERT");

                entity.Property(e => e.Dtexpires)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTEXPIRES");

                entity.Property(e => e.Dtreview)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTREVIEW");

                entity.Property(e => e.Dttraining)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTTRAINING");

                entity.Property(e => e.Nmnote)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMNOTE");

                entity.Property(e => e.Txcertno)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXCERTNO")
                    .IsFixedLength();

                entity.Property(e => e.Txlev)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXLEV")
                    .IsFixedLength();

                entity.Property(e => e.Txver)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXVER")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vmeodt>(entity =>
            {
                entity.HasKey(e => e.Nmpstid)
                    .HasName("VMEODT_KEY_0");

                entity.ToTable("VMEODT");

                entity.HasIndex(e => new { e.Txsctr, e.Nmpstid }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Nmpstid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMPSTID");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtposted)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTPOSTED");

                entity.Property(e => e.Mnsgpamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSGPAMT");

                entity.Property(e => e.Mnsnettot)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSNETTOT");

                entity.Property(e => e.Mnsnettotf)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSNETTOTF");

                entity.Property(e => e.Mnstotcst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSTOTCST");

                entity.Property(e => e.Nmdocid)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMDOCID");

                entity.Property(e => e.Nmsgpperc)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMSGPPERC");

                entity.Property(e => e.Swdenddone).HasColumnName("SWDENDDONE");

                entity.Property(e => e.Swprocess).HasColumnName("SWPROCESS");

                entity.Property(e => e.Tmposted)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("TMPOSTED");

                entity.Property(e => e.Txbillname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXBILLNAME")
                    .IsFixedLength();

                entity.Property(e => e.Txbillto)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXBILLTO")
                    .IsFixedLength();

                entity.Property(e => e.Txcrdapprv)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCRDAPPRV")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Txentryby)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXENTRYBY")
                    .IsFixedLength();

                entity.Property(e => e.Txpstid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXPSTID")
                    .IsFixedLength();

                entity.Property(e => e.Txref)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXREF")
                    .IsFixedLength();

                entity.Property(e => e.Txsctr)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXSCTR")
                    .IsFixedLength();

                entity.Property(e => e.Txsourceid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("TXSOURCEID")
                    .IsFixedLength();

                entity.Property(e => e.Txsrcecurr)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TXSRCECURR")
                    .IsFixedLength();

                entity.Property(e => e.Txtype)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXTYPE")
                    .IsFixedLength();

                entity.Property(e => e.Wddoctype).HasColumnName("WDDOCTYPE");

                entity.Property(e => e.Wdpostmeth).HasColumnName("WDPOSTMETH");
            });

            modelBuilder.Entity<Vmeqcm>(entity =>
            {
                entity.HasKey(e => new { e.Txequp, e.Txcomp })
                    .HasName("VMEQCM_KEY_0");

                entity.ToTable("VMEQCM");

                entity.HasIndex(e => new { e.Txcomp, e.Txequp }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Txequp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEQUP")
                    .IsFixedLength();

                entity.Property(e => e.Txcomp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMP")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();
            });

            

            modelBuilder.Entity<Vmesum>(entity =>
            {
                entity.HasKey(e => new { e.Txempl, e.Txtype })
                    .HasName("VMESUM_KEY_0");

                entity.ToTable("VMESUM");

                entity.HasIndex(e => new { e.Txtype, e.Txempl }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Txempl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXEMPL")
                    .IsFixedLength();

                entity.Property(e => e.Txtype)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXTYPE")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Lncount).HasColumnName("LNCOUNT");

                entity.Property(e => e.Lnduration).HasColumnName("LNDURATION");

                entity.Property(e => e.Lnppn).HasColumnName("LNPPN");

                entity.Property(e => e.Lnsitemcnt).HasColumnName("LNSITEMCNT");

                entity.Property(e => e.Lnslabrcnt).HasColumnName("LNSLABRCNT");

                entity.Property(e => e.Lnsservcnt).HasColumnName("LNSSERVCNT");

                entity.Property(e => e.Lnssubccnt).HasColumnName("LNSSUBCCNT");

                entity.Property(e => e.Lnstimtcnt).HasColumnName("LNSTIMTCNT");

                entity.Property(e => e.Mnbasecst)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("MNBASECST");

                entity.Property(e => e.Mnsitemamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSITEMAMT");

                entity.Property(e => e.Mnsitemcst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSITEMCST");

                entity.Property(e => e.Mnslabramt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSLABRAMT");

                entity.Property(e => e.Mnslabrcst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSLABRCST");

                entity.Property(e => e.Mnsservamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSSERVAMT");

                entity.Property(e => e.Mnsservcst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSSERVCST");

                entity.Property(e => e.Mnssubcamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSSUBCAMT");

                entity.Property(e => e.Mnssubccst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSSUBCCST");

                entity.Property(e => e.Mnstimtamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSTIMTAMT");

                entity.Property(e => e.Mnstimtcst)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MNSTIMTCST");

                entity.Property(e => e.Nmperctot)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("NMPERCTOT");
            });

            modelBuilder.Entity<Vmcfoc>(entity =>
            {
                entity.HasKey(e => new { e.Wdtype, e.Txcfov, e.Nmcfoc, e.Wdlineseq })
                    .HasName("VMCFOC_KEY_0");

                entity.ToTable("VMCFOC");

                entity.HasIndex(e => new { e.Wdtype, e.Txcfov, e.Wdlineseq }, "KEY_1");

                entity.HasIndex(e => new { e.Nmcfoc, e.Txcfov, e.Wdtype, e.Wdlineseq }, "KEY_2")
                    .IsUnique();

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");

                entity.Property(e => e.Txcfov)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXCFOV")
                    .IsFixedLength();

                entity.Property(e => e.Nmcfoc)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMCFOC");

                entity.Property(e => e.Wdlineseq).HasColumnName("WDLINESEQ");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Dtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTDATE");

                entity.Property(e => e.Nmnumber)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("NMNUMBER");

                entity.Property(e => e.Swbool).HasColumnName("SWBOOL");

                entity.Property(e => e.Tmtime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("TMTIME");

                entity.Property(e => e.Txtext)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXTEXT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vmfalt>(entity =>
            {
                entity.HasKey(e => e.Txfault)
                    .HasName("VMFALT_KEY_0");

                entity.ToTable("VMFALT");

                entity.HasIndex(e => new { e.Txmodlgrp, e.Txfault }, "KEY_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.Txfaultgrp, e.Txfault }, "KEY_2")
                    .IsUnique();

                entity.Property(e => e.Txfault)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXFAULT")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Nmstat)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NMSTAT");

                entity.Property(e => e.Swfailure).HasColumnName("SWFAILURE");

                entity.Property(e => e.Swusepic).HasColumnName("SWUSEPIC");

                entity.Property(e => e.Swwarn).HasColumnName("SWWARN");

                entity.Property(e => e.Txcomment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMMENT")
                    .IsFixedLength();

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Txfaultgrp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXFAULTGRP")
                    .IsFixedLength();

                entity.Property(e => e.Txmodlgrp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXMODLGRP")
                    .IsFixedLength();

                entity.Property(e => e.Txpicfile)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TXPICFILE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vmmodc>(entity =>
            {
                entity.HasKey(e => new { e.Txmodl, e.Txcomp })
                    .HasName("VMMODC_KEY_0");

                entity.ToTable("VMMODC");

                entity.HasIndex(e => new { e.Txcomp, e.Txmodl }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Txmodl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXMODL")
                    .IsFixedLength();

                entity.Property(e => e.Txcomp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXCOMP")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Wdcompqty).HasColumnName("WDCOMPQTY");
            });

            

            modelBuilder.Entity<Vmmodm>(entity =>
            {
                entity.HasKey(e => new { e.Txmodl, e.Txmtrtype })
                    .HasName("VMMODM_KEY_0");

                entity.ToTable("VMMODM");

                entity.HasIndex(e => new { e.Txmtrtype, e.Txmodl }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Txmodl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXMODL")
                    .IsFixedLength();

                entity.Property(e => e.Txmtrtype)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXMTRTYPE")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Lnfailcnt1).HasColumnName("LNFAILCNT1");

                entity.Property(e => e.Lnfailcnt2).HasColumnName("LNFAILCNT2");

                entity.Property(e => e.Lnfailcnt3).HasColumnName("LNFAILCNT3");

                entity.Property(e => e.Lnfailcnt4).HasColumnName("LNFAILCNT4");

                entity.Property(e => e.Lnfailcnt5).HasColumnName("LNFAILCNT5");

                entity.Property(e => e.Lnfaltcnt1).HasColumnName("LNFALTCNT1");

                entity.Property(e => e.Lnfaltcnt2).HasColumnName("LNFALTCNT2");

                entity.Property(e => e.Lnfaltcnt3).HasColumnName("LNFALTCNT3");

                entity.Property(e => e.Lnfaltcnt4).HasColumnName("LNFALTCNT4");

                entity.Property(e => e.Lnfaltcnt5).HasColumnName("LNFALTCNT5");

                entity.Property(e => e.Lnmtrcnt1).HasColumnName("LNMTRCNT1");

                entity.Property(e => e.Lnmtrcnt2).HasColumnName("LNMTRCNT2");

                entity.Property(e => e.Lnmtrcnt3).HasColumnName("LNMTRCNT3");

                entity.Property(e => e.Lnmtrcnt4).HasColumnName("LNMTRCNT4");

                entity.Property(e => e.Lnmtrcnt5).HasColumnName("LNMTRCNT5");

                entity.Property(e => e.Nmrng1)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMRNG1");

                entity.Property(e => e.Nmrng2)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMRNG2");

                entity.Property(e => e.Nmrng3)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMRNG3");

                entity.Property(e => e.Nmrng4)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMRNG4");

                entity.Property(e => e.Nmrng5)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("NMRNG5");

                entity.Property(e => e.Swaplycomp).HasColumnName("SWAPLYCOMP");

                entity.Property(e => e.Txdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TXDESC")
                    .IsFixedLength();

                entity.Property(e => e.Wdnumrng).HasColumnName("WDNUMRNG");
            });

            modelBuilder.Entity<Vmmodum>(entity =>
            {
                entity.HasKey(e => new { e.Txmodl, e.Wdtype, e.Txcode })
                    .HasName("VMMODA_KEY_0");

                entity.ToTable("VMMODA");

                entity.HasIndex(e => new { e.Wdtype, e.Txcode, e.Txmodl }, "KEY_1")
                    .IsUnique();

                entity.Property(e => e.Txmodl)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TXMODL")
                    .IsFixedLength();

                entity.Property(e => e.Wdtype).HasColumnName("WDTYPE");

                entity.Property(e => e.Txcode)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("TXCODE")
                    .IsFixedLength();

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Qtdefqtyd)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("QTDEFQTYD");

                entity.Property(e => e.Swspecloc).HasColumnName("SWSPECLOC");

                entity.Property(e => e.Txlocation)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TXLOCATION")
                    .IsFixedLength();
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
