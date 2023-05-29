using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceManagerApi.Data;

public partial class EnpDbContext : DbContext
{
    public EnpDbContext()
    {
    }

    public EnpDbContext(DbContextOptions<EnpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agreement> Agreements { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Compartment> Compartments { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Custodian> Custodians { get; set; }

    public virtual DbSet<CycleDetail> CycleDetails { get; set; }

    public virtual DbSet<DefectEntry> DefectEntries { get; set; }

    public virtual DbSet<Eqdatum> Eqdata { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Equipment1> Equipment1s { get; set; }

    public virtual DbSet<FaultEntry> FaultEntries { get; set; }

    public virtual DbSet<FaultentryView> FaultentryViews { get; set; }

    public virtual DbSet<FleetSchedule> FleetSchedules { get; set; }

    public virtual DbSet<GroundEngTool> GroundEngTools { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<HaulerOperator> HaulerOperators { get; set; }

    public virtual DbSet<Hourly> Hourlies { get; set; }

    public virtual DbSet<HoursEntry> HoursEntries { get; set; }

    public virtual DbSet<HoursEntryTemp> HoursEntryTemps { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemValue> ItemValues { get; set; }

    public virtual DbSet<LoaderOperator> LoaderOperators { get; set; }

    public virtual DbSet<LubeBrand> LubeBrands { get; set; }

    public virtual DbSet<LubeConfig> LubeConfigs { get; set; }

    public virtual DbSet<LubeEntry> LubeEntries { get; set; }

    public virtual DbSet<LubeGrade> LubeGrades { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<ModelClass> ModelClasses { get; set; }

    public virtual DbSet<PlannedOutput> PlannedOutputs { get; set; }

    public virtual DbSet<ProActivityDetail> ProActivityDetails { get; set; }

    public virtual DbSet<ProDrill> ProDrills { get; set; }

    public virtual DbSet<ProFuelIntake> ProFuelIntakes { get; set; }

    public virtual DbSet<ProdProcessedMaterial> ProdProcessedMaterials { get; set; }

    public virtual DbSet<ProdRawMaterial> ProdRawMaterials { get; set; }

    public virtual DbSet<ProductionActivity> ProductionActivities { get; set; }

    public virtual DbSet<ProductionDestination> ProductionDestinations { get; set; }

    public virtual DbSet<ProductionMineArea> ProductionMineAreas { get; set; }

    public virtual DbSet<ProductionOrigin> ProductionOrigins { get; set; }

    public virtual DbSet<ProductionPump> ProductionPumps { get; set; }

    public virtual DbSet<ProductionShift> ProductionShifts { get; set; }

    public virtual DbSet<ProhaulerUnit> ProhaulerUnits { get; set; }

    public virtual DbSet<ProloaderUnit> ProloaderUnits { get; set; }

    public virtual DbSet<RefillType> RefillTypes { get; set; }

    public virtual DbSet<Resolution> Resolutions { get; set; }

    public virtual DbSet<ResolutionType> ResolutionTypes { get; set; }

    public virtual DbSet<ScheduleTransaction> ScheduleTransactions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<TarkwaModel> TarkwaModels { get; set; }

    public virtual DbSet<TarkwaModelClass> TarkwaModelClasses { get; set; }

    public virtual DbSet<ViewEquip> ViewEquips { get; set; }

    public virtual DbSet<Vmequp> Vmequps { get; set; }

    public virtual DbSet<Vmmodl> Vmmodls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=208.117.44.15;Database=EnPDB;User ID=sa;Password=Admin@EnP;MultipleActiveResultSets=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agreement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Agreement_pk");

            entity.ToTable("Agreement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgreementDate).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId).HasColumnName("Equipment_id");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Equipment).WithMany(p => p.Agreements)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("Agreement_Equipment_id_fk");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_pk");

            entity.ToTable("Category");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compartment>(entity =>
        {
            entity.ToTable("Compartment");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Componenent_pk");

            entity.ToTable("Component");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.EquipmentId).HasColumnName("Equipment_id");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Equipment).WithMany(p => p.Components)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("Equipement_id_fk");
        });

        modelBuilder.Entity<Custodian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Custodians_pk");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HrCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CycleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CycleDetails_pk");

            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CycleDate).HasColumnType("datetime");
            entity.Property(e => e.CycleTime).HasColumnType("datetime");
            entity.Property(e => e.Hauler)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Loader)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
            entity.Property(e => e.TimeAtLoader).HasColumnType("datetime");

            entity.HasOne(d => d.Destination).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.DestinationId)
                .HasConstraintName("CycleDetails_ProductionDestination_id_fk");

            entity.HasOne(d => d.HaulerNavigation).WithMany(p => p.CycleDetails)
                .HasPrincipalKey(p => p.EmpCode)
                .HasForeignKey(d => d.Hauler)
                .HasConstraintName("CycleDetails_HaulerOperator_EmpCode_fk");

            entity.HasOne(d => d.HaulerUnit).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.HaulerUnitId)
                .HasConstraintName("CycleDetails_PROHaulerUnits_id_fk");

            entity.HasOne(d => d.LoaderNavigation).WithMany(p => p.CycleDetails)
                .HasPrincipalKey(p => p.EmpCode)
                .HasForeignKey(d => d.Loader)
                .HasConstraintName("CycleDetails_LoaderOperator_EmpCode_fk");

            entity.HasOne(d => d.LoaderUnit).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.LoaderUnitId)
                .HasConstraintName("CycleDetails_PROLoaderUnits_id_fk");

            entity.HasOne(d => d.Material).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("CycleDetails_ProdRawMaterial_id_fk");

            entity.HasOne(d => d.Origin).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.OriginId)
                .HasConstraintName("CycleDetails_ProductionOrigin_id_fk");

            entity.HasOne(d => d.Shift).WithMany(p => p.CycleDetails)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("CycleDetails_ProductionShift_Id_fk");
        });

        modelBuilder.Entity<DefectEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Defect_pk");

            entity.ToTable("DefectEntry");

            entity.Property(e => e.Comment)
                .HasMaxLength(250)
                .HasColumnName("comment");
            entity.Property(e => e.DefectEquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("defect_equipment_Id");
            entity.Property(e => e.EquipmentDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Equipment_description");
            entity.Property(e => e.ExpectedDate)
                .HasColumnType("datetime")
                .HasColumnName("expected_date");
            entity.Property(e => e.Item).HasMaxLength(250);
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.DefectEquipment).WithMany(p => p.DefectEntries)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.DefectEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DefectEntry_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<Eqdatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQDATA");

            entity.Property(e => e.Audtdate).HasColumnName("AUDTDATE");
            entity.Property(e => e.Audtorg)
                .HasMaxLength(255)
                .HasColumnName("AUDTORG");
            entity.Property(e => e.Audttime).HasColumnName("AUDTTIME");
            entity.Property(e => e.Audtuser)
                .HasMaxLength(255)
                .HasColumnName("AUDTUSER");
            entity.Property(e => e.Dtmtbfcalc).HasColumnName("DTMTBFCALC");
            entity.Property(e => e.Dtrelease).HasColumnName("DTRELEASE");
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
            entity.Property(e => e.Mnagreprc).HasColumnName("MNAGREPRC");
            entity.Property(e => e.Mnestrepl).HasColumnName("MNESTREPL");
            entity.Property(e => e.Nmstat).HasColumnName("NMSTAT");
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
                .HasMaxLength(255)
                .HasColumnName("TXAGRESERV");
            entity.Property(e => e.Txautosn)
                .HasMaxLength(255)
                .HasColumnName("TXAUTOSN");
            entity.Property(e => e.Txcfov)
                .HasMaxLength(255)
                .HasColumnName("TXCFOV");
            entity.Property(e => e.Txcomment)
                .HasMaxLength(255)
                .HasColumnName("TXCOMMENT");
            entity.Property(e => e.Txdefenv)
                .HasMaxLength(255)
                .HasColumnName("TXDEFENV");
            entity.Property(e => e.Txdesc)
                .HasMaxLength(255)
                .HasColumnName("TXDESC");
            entity.Property(e => e.Txempl)
                .HasMaxLength(255)
                .HasColumnName("TXEMPL");
            entity.Property(e => e.Txmanf)
                .HasMaxLength(255)
                .HasColumnName("TXMANF");
            entity.Property(e => e.Txmodel)
                .HasMaxLength(255)
                .HasColumnName("TXMODEL");
            entity.Property(e => e.Txmodl)
                .HasMaxLength(255)
                .HasColumnName("TXMODL");
            entity.Property(e => e.Txmodlgrp)
                .HasMaxLength(255)
                .HasColumnName("TXMODLGRP");
            entity.Property(e => e.Txmtrdesc)
                .HasMaxLength(255)
                .HasColumnName("TXMTRDESC");
            entity.Property(e => e.Txpartnum)
                .HasMaxLength(255)
                .HasColumnName("TXPARTNUM");
            entity.Property(e => e.Txpicfile)
                .HasMaxLength(255)
                .HasColumnName("TXPICFILE");
            entity.Property(e => e.Txschd)
                .HasMaxLength(255)
                .HasColumnName("TXSCHD");
            entity.Property(e => e.Txtmpid)
                .HasMaxLength(255)
                .HasColumnName("TXTMPID");
            entity.Property(e => e.Txunit)
                .HasMaxLength(255)
                .HasColumnName("TXUNIT");
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

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Equipment_pk");

            entity.HasIndex(e => e.EquipmentId, "Equipment_pk2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndOfLifeDate).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Equipment_id");
            entity.Property(e => e.Facode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FACode");
            entity.Property(e => e.ManufactureDate).HasColumnType("datetime");
            entity.Property(e => e.MeterType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.Note).HasMaxLength(1);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UniversalCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");
            entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Model).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("Model_id_fk");
        });

        modelBuilder.Entity<Equipment1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Equipment_pk1");

            entity.ToTable("Equipment1");

            entity.HasIndex(e => e.EquipmentId, "Equipment_pk21").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndOfLifeDate).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Equipment_id");
            entity.Property(e => e.Facode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FACode");
            entity.Property(e => e.ManufactureDate).HasColumnType("datetime");
            entity.Property(e => e.MeterType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.Note).HasMaxLength(1);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UniversalCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");
            entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Model).WithMany(p => p.Equipment1s)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("Model_id_fk1");
        });

        modelBuilder.Entity<FaultEntry>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.ToTable("FaultEntry");

            entity.Property(e => e.EntryId)
                .ValueGeneratedNever()
                .HasColumnName("EntryID");
            entity.Property(e => e.Comment).HasMaxLength(300);
            entity.Property(e => e.Custodian)
                .HasMaxLength(50)
                .HasColumnName("custodian");
            entity.Property(e => e.DownStatus).HasMaxLength(50);
            entity.Property(e => e.DownType).HasMaxLength(50);
            entity.Property(e => e.Downtime).HasColumnType("datetime");
            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .HasColumnName("FleetID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .HasColumnName("LocationID");
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("referenceId");
            entity.Property(e => e.ResolutionId)
                .HasMaxLength(50)
                .HasColumnName("ResolutionID");
            entity.Property(e => e.ResolutionType).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VmClass).HasMaxLength(50);
            entity.Property(e => e.VmModel).HasMaxLength(50);
            entity.Property(e => e.WtimeEnd)
                .HasColumnType("datetime")
                .HasColumnName("WTimeEnd");
            entity.Property(e => e.WtimeStart)
                .HasColumnType("datetime")
                .HasColumnName("WTimeStart");
        });

        modelBuilder.Entity<FaultentryView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("faultentry_view");

            entity.Property(e => e.Month)
                .HasMaxLength(30)
                .HasColumnName("month");
            entity.Property(e => e.Totaldowntime).HasColumnName("totaldowntime");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<FleetSchedule>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.ToTable("FleetSchedule");

            entity.Property(e => e.EntryId).HasColumnName("EntryID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .HasColumnName("FleetID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .HasColumnName("LocationID");
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Responsible).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.VmClass).HasMaxLength(50);
            entity.Property(e => e.VmModel).HasMaxLength(50);

            entity.HasOne(d => d.ServiceType).WithMany(p => p.FleetSchedules)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("FK_FleetSchedule_Services");
        });

        modelBuilder.Entity<GroundEngTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("GroundEngTools_pk");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("equipmentID");
            entity.Property(e => e.Reason).HasMaxLength(250);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Equipment).WithMany(p => p.GroundEngTools)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroundEngTools_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Section).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Groups_Section");
        });

        modelBuilder.Entity<HaulerOperator>(entity =>
        {
            entity.ToTable("HaulerOperator");

            entity.HasIndex(e => e.EmpCode, "HaulerOperator_pk").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<Hourly>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.ToTable("Hourly");

            entity.Property(e => e.EntryId).HasColumnName("EntryID");
            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .HasColumnName("FleetID");
            entity.Property(e => e.ReadingDate).HasColumnType("datetime");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HoursEntry>(entity =>
        {
            entity.ToTable("HoursEntry");

            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FleetID");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Fleet).WithMany(p => p.HoursEntries)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.FleetId)
                .HasConstraintName("HoursEntry_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<HoursEntryTemp>(entity =>
        {
            entity.ToTable("HoursEntryTemp");

            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FleetID");
            entity.Property(e => e.PreviousDate)
                .HasColumnType("datetime")
                .HasColumnName("Previous_Date");

            entity.HasOne(d => d.Fleet).WithMany(p => p.HoursEntryTemps)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.FleetId)
                .HasConstraintName("HoursEntryTemp_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Group).WithMany(p => p.Items)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Groups");
        });

        modelBuilder.Entity<ItemValue>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemValues)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("ItemValues_Item_Id_fk");
        });

        modelBuilder.Entity<LoaderOperator>(entity =>
        {
            entity.ToTable("LoaderOperator");

            entity.HasIndex(e => e.EmpCode, "LoaderOperator_pk").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<LubeBrand>(entity =>
        {
            entity.ToTable("LubeBrand");
        });

        modelBuilder.Entity<LubeConfig>(entity =>
        {
            entity.ToTable("LubeConfig");

            entity.Property(e => e.Model)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Compartment).WithMany(p => p.LubeConfigs)
                .HasForeignKey(d => d.CompartmentId)
                .HasConstraintName("FK_LubeConfig_Compartment");
        });

        modelBuilder.Entity<LubeEntry>(entity =>
        {
            entity.ToTable("LubeEntry");

            entity.Property(e => e.FleetId)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Brand).WithMany(p => p.LubeEntries)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_LubeEntry_LubeBrand");

            entity.HasOne(d => d.Compartment).WithMany(p => p.LubeEntries)
                .HasForeignKey(d => d.CompartmentId)
                .HasConstraintName("FK_LubeEntry_Compartment");

            entity.HasOne(d => d.Grade).WithMany(p => p.LubeEntries)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_LubeEntry_LubeGrade");

            entity.HasOne(d => d.RefillType).WithMany(p => p.LubeEntries)
                .HasForeignKey(d => d.RefillTypeId)
                .HasConstraintName("FK_LubeEntry_RefillType");
        });

        modelBuilder.Entity<LubeGrade>(entity =>
        {
            entity.ToTable("LubeGrade");

            entity.HasOne(d => d.Brand).WithMany(p => p.LubeGrades)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_LubeGrade_LubeBrand");

            entity.HasOne(d => d.LubeConfig).WithMany(p => p.LubeGrades)
                .HasForeignKey(d => d.LubeConfigId)
                .HasConstraintName("FK_LubeGrade_LubeConfig");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufact__163F69B0B7AACBA8");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("Model_pk");

            entity.ToTable("Model");

            entity.HasIndex(e => e.Code, "Model_pk2").IsUnique();

            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_id");
            entity.Property(e => e.ModelClassId).HasColumnName("ModelClass_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Models)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("manufacturer_fk_id");

            entity.HasOne(d => d.ModelClass).WithMany(p => p.Models)
                .HasForeignKey(d => d.ModelClassId)
                .HasConstraintName("modelClass_fk_id");
        });

        modelBuilder.Entity<ModelClass>(entity =>
        {
            entity.HasKey(e => e.ModelClassId).HasName("ModelClass_pk");

            entity.ToTable("ModelClass");

            entity.Property(e => e.ModelClassId).HasColumnName("ModelClass_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlannedOutput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PlannedOutput_pk");

            entity.ToTable("PlannedOutput");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity).WithMany(p => p.PlannedOutputs)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("PlannedOutput_ProductionActivity_Id_fk");

            entity.HasOne(d => d.Destination).WithMany(p => p.PlannedOutputs)
                .HasForeignKey(d => d.DestinationId)
                .HasConstraintName("PlannedOutput___fk");
        });

        modelBuilder.Entity<ProActivityDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProActivityDetails_pk");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity).WithMany(p => p.ProActivityDetails)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("ProActivityDetails_ProductionActivity_Id_fk");
        });

        modelBuilder.Entity<ProDrill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProDrill_pk");

            entity.ToTable("ProDrill");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Equipment).WithMany(p => p.ProDrills)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("ProDrill_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<ProFuelIntake>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProFuelIntake_pk");

            entity.ToTable("ProFuelIntake");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batchNumber");
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("equipmentId");
            entity.Property(e => e.IntakeDate)
                .HasColumnType("datetime")
                .HasColumnName("intakeDate");
            entity.Property(e => e.PumpId).HasColumnName("pumpId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transactionType");

            entity.HasOne(d => d.Equipment).WithMany(p => p.ProFuelIntakes)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("ProFuelIntake_Equipment_Equipment_id_fk");

            entity.HasOne(d => d.Pump).WithMany(p => p.ProFuelIntakes)
                .HasForeignKey(d => d.PumpId)
                .HasConstraintName("ProFuelIntake___fk");
        });

        modelBuilder.Entity<ProdProcessedMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProdProcessedMaterial_pk");

            entity.ToTable("ProdProcessedMaterial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProdRawMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProdRawMaterial_pk");

            entity.ToTable("ProdRawMaterial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionActivity>(entity =>
        {
            entity.ToTable("ProductionActivity");

            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionDestination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProductionDestination_pk");

            entity.ToTable("ProductionDestination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionMineArea>(entity =>
        {
            entity.ToTable("ProductionMineArea");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionOrigin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProductionOrigin_pk");

            entity.ToTable("ProductionOrigin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionPump>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProductionPump_pk");

            entity.ToTable("ProductionPump");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProductionShift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shift");

            entity.ToTable("ProductionShift");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");
        });

        modelBuilder.Entity<ProhaulerUnit>(entity =>
        {
            entity.ToTable("PROHaulerUnits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");

            entity.HasOne(d => d.Equipment).WithMany(p => p.ProhaulerUnits)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("PROHaulerUnits_Equipment_Equipment_id_fk");
        });

        modelBuilder.Entity<ProloaderUnit>(entity =>
        {
            entity.ToTable("PROLoaderUnits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenantId");

            entity.HasOne(d => d.Equipment).WithMany(p => p.ProloaderUnits)
                .HasPrincipalKey(p => p.EquipmentId)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_PROLoaderUnits_Equipment");
        });

        modelBuilder.Entity<RefillType>(entity =>
        {
            entity.ToTable("RefillType");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Resolution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resoluti__3214EC079AF79474");

            entity.ToTable("Resolution");

            entity.Property(e => e.Custodian).HasMaxLength(80);
            entity.Property(e => e.DownStation)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DownType).HasMaxLength(50);
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FleetId)
                .HasMaxLength(50)
                .HasColumnName("FleetID");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResolutionType>(entity =>
        {
            entity.ToTable("ResolutionType");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ScheduleTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ScheduleTransaction_pk");

            entity.ToTable("ScheduleTransaction");

            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ItemValue).WithMany(p => p.ScheduleTransactions)
                .HasForeignKey(d => d.ItemValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ScheduleTransaction_ItemValues_Id_fk");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Section__3214EC0733B5DB02");

            entity.ToTable("Section");

            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Service).WithMany(p => p.Sections)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Section_Services");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ModelNavigation).WithMany(p => p.Services)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.Model)
                .HasConstraintName("Services_Model_Code_fk");
        });

        modelBuilder.Entity<TarkwaModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TarkwaModel");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_id");
            entity.Property(e => e.ModelClassId).HasColumnName("ModelClass_id");
            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TarkwaModelClass>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TarkwaModelClass");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelClassId).HasColumnName("ModelClass_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewEquip>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_equip");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndOfLifeDate).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Equipment_id");
            entity.Property(e => e.ManufactureDate).HasColumnType("datetime");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.Modelclass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");
            entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Vmequp>(entity =>
        {
            entity.HasKey(e => e.Txequp).HasName("VMEQUP_KEY_0");

            entity.ToTable("VMEQUP");

            entity.Property(e => e.Txequp)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXEQUP");
            entity.Property(e => e.Audtdate)
                .HasColumnType("decimal(9, 0)")
                .HasColumnName("AUDTDATE");
            entity.Property(e => e.Audtorg)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUDTORG");
            entity.Property(e => e.Audttime)
                .HasColumnType("decimal(9, 0)")
                .HasColumnName("AUDTTIME");
            entity.Property(e => e.Audtuser)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUDTUSER");
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
                .IsFixedLength()
                .HasColumnName("TXAREA3");
            entity.Property(e => e.Txarea4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXAREA4");
            entity.Property(e => e.Txcont)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXCONT");
            entity.Property(e => e.Txinsenv)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXINSENV");
            entity.Property(e => e.Txintsite)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXINTSITE");
            entity.Property(e => e.Txinv)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXINV");
            entity.Property(e => e.Txitem)
                .HasMaxLength(24)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXITEM");
            entity.Property(e => e.Txitemloc)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXITEMLOC");
            entity.Property(e => e.Txlastjob)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXLASTJOB");
            entity.Property(e => e.Txltdoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXLTDOC");
            entity.Property(e => e.Txmodl)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMODL");
            entity.Property(e => e.Txpo)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXPO");
            entity.Property(e => e.Txregono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXREGONO");
            entity.Property(e => e.Txsegnum1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM1");
            entity.Property(e => e.Txsegnum2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM2");
            entity.Property(e => e.Txsegnum3)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM3");
            entity.Property(e => e.Txsegnum4)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM4");
            entity.Property(e => e.Txsegnum5)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM5");
            entity.Property(e => e.Txsegnum6)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM6");
            entity.Property(e => e.Txsegnum7)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM7");
            entity.Property(e => e.Txsegnum8)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM8");
            entity.Property(e => e.Txsegnum9)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGNUM9");
            entity.Property(e => e.Txsegval1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL1");
            entity.Property(e => e.Txsegval2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL2");
            entity.Property(e => e.Txsegval3)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL3");
            entity.Property(e => e.Txsegval4)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL4");
            entity.Property(e => e.Txsegval5)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL5");
            entity.Property(e => e.Txsegval6)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL6");
            entity.Property(e => e.Txsegval7)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL7");
            entity.Property(e => e.Txsegval8)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL8");
            entity.Property(e => e.Txsegval9)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSEGVAL9");
            entity.Property(e => e.Txserv)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSERV");
            entity.Property(e => e.Txsite)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSITE");
            entity.Property(e => e.Txunformsn)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXUNFORMSN");
            entity.Property(e => e.Txvend)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXVEND");
            entity.Property(e => e.Txvendname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXVENDNAME");
            entity.Property(e => e.Txwarrmtr)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXWARRMTR");
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
            entity.HasKey(e => e.Txmodl).HasName("VMMODL_KEY_0");

            entity.ToTable("VMMODL");

            entity.Property(e => e.Txmodl)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMODL");
            entity.Property(e => e.Audtdate)
                .HasColumnType("decimal(9, 0)")
                .HasColumnName("AUDTDATE");
            entity.Property(e => e.Audtorg)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUDTORG");
            entity.Property(e => e.Audttime)
                .HasColumnType("decimal(9, 0)")
                .HasColumnName("AUDTTIME");
            entity.Property(e => e.Audtuser)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AUDTUSER");
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
                .IsFixedLength()
                .HasColumnName("TXAGRESERV");
            entity.Property(e => e.Txautosn)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXAUTOSN");
            entity.Property(e => e.Txcfov)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXCFOV");
            entity.Property(e => e.Txcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXCOMMENT");
            entity.Property(e => e.Txdefenv)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXDEFENV");
            entity.Property(e => e.Txdesc)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXDESC");
            entity.Property(e => e.Txempl)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXEMPL");
            entity.Property(e => e.Txmanf)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMANF");
            entity.Property(e => e.Txmodel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMODEL");
            entity.Property(e => e.Txmodlgrp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMODLGRP");
            entity.Property(e => e.Txmtrdesc)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXMTRDESC");
            entity.Property(e => e.Txpartnum)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXPARTNUM");
            entity.Property(e => e.Txpicfile)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXPICFILE");
            entity.Property(e => e.Txschd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXSCHD");
            entity.Property(e => e.Txtmpid)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXTMPID");
            entity.Property(e => e.Txunit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXUNIT");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
