using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Entities;

public partial class ApertureSilverDevContext : DbContext
{
    public ApertureSilverDevContext()
    {
    }

    public ApertureSilverDevContext(DbContextOptions<ApertureSilverDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlembicVersion> AlembicVersions { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Cpe> Cpes { get; set; }

    public virtual DbSet<Cveproblem> Cveproblems { get; set; }

    public virtual DbSet<Cvereference> Cvereferences { get; set; }

    public virtual DbSet<Cvss> Cvsses { get; set; }

    public virtual DbSet<Cwe> Cwes { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceAdapter> DeviceAdapters { get; set; }

    public virtual DbSet<DeviceIp> DeviceIps { get; set; }

    public virtual DbSet<DeviceLabel> DeviceLabels { get; set; }

    public virtual DbSet<DeviceMac> DeviceMacs { get; set; }

    public virtual DbSet<EnumDevicePhysicalLocation> EnumDevicePhysicalLocations { get; set; }

    public virtual DbSet<EnumDeviceType> EnumDeviceTypes { get; set; }

    public virtual DbSet<EnumSourceTool> EnumSourceTools { get; set; }

    public virtual DbSet<EnumTransformStatus> EnumTransformStatuses { get; set; }

    public virtual DbSet<EnumVulnerability> EnumVulnerabilities { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<FindingVulnerability> FindingVulnerabilities { get; set; }

    public virtual DbSet<Host> Hosts { get; set; }

    public virtual DbSet<KnowledgeBase> KnowledgeBases { get; set; }

    public virtual DbSet<KnowledgeBaseVulnerability> KnowledgeBaseVulnerabilities { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<MasterFinding> MasterFindings { get; set; }

    public virtual DbSet<MasterFindingCve> MasterFindingCves { get; set; }

    public virtual DbSet<MasterFindingCwe> MasterFindingCwes { get; set; }

    public virtual DbSet<OrganizationalChart> OrganizationalCharts { get; set; }

    public virtual DbSet<OrganizationalVulnerability> OrganizationalVulnerabilities { get; set; }

    public virtual DbSet<Plugin> Plugins { get; set; }

    public virtual DbSet<QualysFinding> QualysFindings { get; set; }

    public virtual DbSet<Repository> Repositories { get; set; }

    public virtual DbSet<SerilogLog> SerilogLogs { get; set; }

    public virtual DbSet<Severity> Severities { get; set; }

    public virtual DbSet<Severity1> Severities1 { get; set; }

    public virtual DbSet<Solution> Solutions { get; set; }

    public virtual DbSet<TenableFinding> TenableFindings { get; set; }

    public virtual DbSet<TransformHistory> TransformHistories { get; set; }

    public virtual DbSet<TransformProcessHistory> TransformProcessHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApertureSilverDev;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlembicVersion>(entity =>
        {
            entity.HasKey(e => e.VersionNum).HasName("alembic_version_pkc");

            entity.ToTable("alembic_version");

            entity.Property(e => e.VersionNum)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("version_num");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC274E6C6460");

            entity.ToTable("Application", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Cpe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPE__3214EC27A239801D");

            entity.ToTable("CPE", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpe23uri)
                .IsUnicode(false)
                .HasColumnName("CPE23URI");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkCve)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FK_CVE");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkCveNavigation).WithMany(p => p.Cpes)
                .HasPrincipalKey(p => p.Cve)
                .HasForeignKey(d => d.FkCve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPE__FK_CVE__3E1D39E1");
        });

        modelBuilder.Entity<Cveproblem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CVEProbl__3214EC270BEBF786");

            entity.ToTable("CVEProblem", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkCve)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FK_CVE");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Problem).IsUnicode(false);

            entity.HasOne(d => d.FkCveNavigation).WithMany(p => p.Cveproblems)
                .HasPrincipalKey(p => p.Cve)
                .HasForeignKey(d => d.FkCve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CVEProble__FK_CV__3F115E1A");
        });

        modelBuilder.Entity<Cvereference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CVERefer__3214EC27319C35FB");

            entity.ToTable("CVEReference", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkCve)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FK_CVE");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Source).IsUnicode(false);
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.FkCveNavigation).WithMany(p => p.Cvereferences)
                .HasPrincipalKey(p => p.Cve)
                .HasForeignKey(d => d.FkCve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CVERefere__FK_CV__40058253");
        });

        modelBuilder.Entity<Cvss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CVSS__3214EC27B17A89B8");

            entity.ToTable("CVSS", "core");

            entity.HasIndex(e => e.Cve, "ix_core_CVSS_CVE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccessComplexity).IsUnicode(false);
            entity.Property(e => e.AccessVector).IsUnicode(false);
            entity.Property(e => e.AttackComplexity3).IsUnicode(false);
            entity.Property(e => e.AttackVector3).IsUnicode(false);
            entity.Property(e => e.Authentication).IsUnicode(false);
            entity.Property(e => e.AvailabilityImpact).IsUnicode(false);
            entity.Property(e => e.AvailabilityImpact3).IsUnicode(false);
            entity.Property(e => e.BaseSeverity3).IsUnicode(false);
            entity.Property(e => e.ConfidentialityImpact).IsUnicode(false);
            entity.Property(e => e.ConfidentialityImpact3).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cve)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CVE");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.IntegrityImpact).IsUnicode(false);
            entity.Property(e => e.IntegrityImpact3).IsUnicode(false);
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrivilegesRequired3).IsUnicode(false);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Scope3).IsUnicode(false);
            entity.Property(e => e.Severity).IsUnicode(false);
            entity.Property(e => e.UserInteraction3).IsUnicode(false);
            entity.Property(e => e.VectorString).IsUnicode(false);
            entity.Property(e => e.VectorString3).IsUnicode(false);

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Cvsses)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__CVSS__FK_Process__40F9A68C");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Cvsses)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__CVSS__FK_RunID__41EDCAC5");
        });

        modelBuilder.Entity<Cwe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CWE__3214EC2772A5ED3D");

            entity.ToTable("CWE", "core");

            entity.HasIndex(e => e.Cwe1, "ix_core_CWE_CWE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Abstraction).IsUnicode(false);
            entity.Property(e => e.AffectedResources).IsUnicode(false);
            entity.Property(e => e.AlternateTerms).IsUnicode(false);
            entity.Property(e => e.ApplicablePlatforms).IsUnicode(false);
            entity.Property(e => e.BackgroundDetails).IsUnicode(false);
            entity.Property(e => e.CommonConsequences).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cwe1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CWE");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DetectionMethods).IsUnicode(false);
            entity.Property(e => e.ExploitationFactors).IsUnicode(false);
            entity.Property(e => e.ExtendedDescription).IsUnicode(false);
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.FunctionalAreas).IsUnicode(false);
            entity.Property(e => e.LikelihoodOfExploit).IsUnicode(false);
            entity.Property(e => e.ModesOfIntroduction).IsUnicode(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.ObservedExamples).IsUnicode(false);
            entity.Property(e => e.PotentialMitigations).IsUnicode(false);
            entity.Property(e => e.RelatedAttackPatterns).IsUnicode(false);
            entity.Property(e => e.RelatedWeaknesses).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.TaxonomyMappings).IsUnicode(false);
            entity.Property(e => e.Weakness).IsUnicode(false);
            entity.Property(e => e.WeaknessOrdinalities).IsUnicode(false);

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Cwes)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__CWE__FK_ProcessI__42E1EEFE");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Cwes)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__CWE__FK_RunID__43D61337");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Device__3214EC2792C8C1E6");

            entity.ToTable("Device", "asset");

            entity.HasIndex(e => e.FirstIp, "ix_asset_Device_FirstIP");

            entity.HasIndex(e => e.FirstMacaddress, "ix_asset_Device_FirstMACAddress");

            entity.HasIndex(e => e.HostNameFqdn, "ix_asset_Device_HostNameFQDN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedTo).IsUnicode(false);
            entity.Property(e => e.AssignedToEmail).IsUnicode(false);
            entity.Property(e => e.AssignedToManagerEmail).IsUnicode(false);
            entity.Property(e => e.AssignedToUserName).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstIp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("FirstIP");
            entity.Property(e => e.FirstMacaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FirstMACAddress");
            entity.Property(e => e.FkDeviceTypeId).HasColumnName("FK_DeviceTypeID");
            entity.Property(e => e.FkPhysicalLocationId).HasColumnName("FK_PhysicalLocationID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.HostNameFqdn)
                .HasMaxLength(253)
                .IsUnicode(false)
                .HasColumnName("HostNameFQDN");
            entity.Property(e => e.InternalAxonId)
                .IsUnicode(false)
                .HasColumnName("InternalAxonID");
            entity.Property(e => e.Labels).IsUnicode(false);
            entity.Property(e => e.LastUsedUsersDepartmentsAssociation).IsUnicode(false);
            entity.Property(e => e.LatestUsedUser).IsUnicode(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.NetworkInterfacesIps)
                .IsUnicode(false)
                .HasColumnName("NetworkInterfacesIPS");
            entity.Property(e => e.NetworkInterfacesMac)
                .IsUnicode(false)
                .HasColumnName("NetworkInterfacesMAC");
            entity.Property(e => e.Ostype)
                .IsUnicode(false)
                .HasColumnName("OSType");
            entity.Property(e => e.OstypeDistribution)
                .IsUnicode(false)
                .HasColumnName("OSTypeDistribution");
            entity.Property(e => e.Owner).IsUnicode(false);
            entity.Property(e => e.SupportGroup).IsUnicode(false);
            entity.Property(e => e.Umanager)
                .IsUnicode(false)
                .HasColumnName("UManager");

            entity.HasOne(d => d.FkDeviceType).WithMany(p => p.Devices)
                .HasForeignKey(d => d.FkDeviceTypeId)
                .HasConstraintName("FK__Device__FK_Devic__367C1819");

            entity.HasOne(d => d.FkPhysicalLocation).WithMany(p => p.Devices)
                .HasForeignKey(d => d.FkPhysicalLocationId)
                .HasConstraintName("FK__Device__FK_Physi__37703C52");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Devices)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Device__FK_Proce__3864608B");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Devices)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Device__FK_RunID__395884C4");
        });

        modelBuilder.Entity<DeviceAdapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeviceAd__3214EC27F45EDE87");

            entity.ToTable("DeviceAdapter", "asset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adapter).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkDeviceId).HasColumnName("FK_DeviceID");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkDevice).WithMany(p => p.DeviceAdapters)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK__DeviceAda__FK_De__3A4CA8FD");
        });

        modelBuilder.Entity<DeviceIp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeviceIP__3214EC278A5A1B12");

            entity.ToTable("DeviceIP", "asset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkDeviceId).HasColumnName("FK_DeviceID");
            entity.Property(e => e.Ip)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkDevice).WithMany(p => p.DeviceIps)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK__DeviceIP__FK_Dev__3B40CD36");
        });

        modelBuilder.Entity<DeviceLabel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeviceLa__3214EC2743546C23");

            entity.ToTable("DeviceLabel", "asset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkDeviceId).HasColumnName("FK_DeviceID");
            entity.Property(e => e.Label).IsUnicode(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkDevice).WithMany(p => p.DeviceLabels)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK__DeviceLab__FK_De__3C34F16F");
        });

        modelBuilder.Entity<DeviceMac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeviceMa__3214EC2799120168");

            entity.ToTable("DeviceMac", "asset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkDeviceId).HasColumnName("FK_DeviceID");
            entity.Property(e => e.Mac)
                .IsUnicode(false)
                .HasColumnName("MAC");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkDevice).WithMany(p => p.DeviceMacs)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK__DeviceMac__FK_De__3D2915A8");
        });

        modelBuilder.Entity<EnumDevicePhysicalLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EnumDevi__3214EC2774D6C85F");

            entity.ToTable("EnumDevicePhysicalLocation", "asset");

            entity.HasIndex(e => e.Name, "UQ__EnumDevi__737584F64F5E01DC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EnumDeviceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EnumDevi__3214EC2742CE764B");

            entity.ToTable("EnumDeviceType", "asset");

            entity.HasIndex(e => e.Name, "UQ__EnumDevi__737584F62025D4FB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EnumSourceTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EnumSour__3214EC27EEFF5BD3");

            entity.ToTable("EnumSourceTool", "core");

            entity.HasIndex(e => e.EnumName, "UQ__EnumSour__A09BB80AFAE31E5D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnumName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EnumTransformStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EnumTran__3214EC2736C6EA73");

            entity.ToTable("EnumTransformStatus", "core");

            entity.HasIndex(e => e.Status, "UQ__EnumTran__3A15923F5BAF9995").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EnumVulnerability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EnumVuln__3214EC2708003C1C");

            entity.ToTable("EnumVulnerability", "core");

            entity.HasIndex(e => e.EnumName, "UQ__EnumVuln__A09BB80A5E95C6BC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnumName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK__Family__41D82F4B68E6E6FE");

            entity.ToTable("Family", "tenable");

            entity.Property(e => e.FamilyId).HasColumnName("FamilyID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<FindingVulnerability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FindingV__3214EC27AE8B9561");

            entity.ToTable("FindingVulnerability", "tenable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkTenableFinding).HasColumnName("FK_TenableFinding");
            entity.Property(e => e.FkVulnerabilityId).HasColumnName("FK_VulnerabilityID");
            entity.Property(e => e.Value).IsUnicode(false);

            entity.HasOne(d => d.FkTenableFindingNavigation).WithMany(p => p.FindingVulnerabilities)
                .HasForeignKey(d => d.FkTenableFinding)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FindingVu__FK_Te__5F7E2DAC");

            entity.HasOne(d => d.FkVulnerability).WithMany(p => p.FindingVulnerabilities)
                .HasForeignKey(d => d.FkVulnerabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FindingVu__FK_Vu__607251E5");
        });

        modelBuilder.Entity<Host>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Host__3214EC274B4ED819");

            entity.ToTable("Host", "core");

            entity.HasIndex(e => e.Dns, "ix_core_Host_DNS");

            entity.HasIndex(e => e.HostUuid, "ix_core_Host_HostUUID").IsUnique();

            entity.HasIndex(e => e.Ipv4address, "ix_core_Host_IPV4Address");

            entity.HasIndex(e => e.Macaddress, "ix_core_Host_MACAddress");

            entity.HasIndex(e => e.NetBios, "ix_core_Host_NetBios");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dns)
                .HasMaxLength(253)
                .IsUnicode(false)
                .HasColumnName("DNS");
            entity.Property(e => e.Domain).IsUnicode(false);
            entity.Property(e => e.FkApplicationId).HasColumnName("FK_ApplicationID");
            entity.Property(e => e.FkDeviceId).HasColumnName("FK_DeviceID");
            entity.Property(e => e.FkLocationId).HasColumnName("FK_LocationID");
            entity.Property(e => e.FkSourceToolId).HasColumnName("FK_SourceToolID");
            entity.Property(e => e.HostName).IsUnicode(false);
            entity.Property(e => e.HostUniqueness).IsUnicode(false);
            entity.Property(e => e.HostUuid)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("HostUUID");
            entity.Property(e => e.Ipv4address)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IPV4Address");
            entity.Property(e => e.Ipv6address)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("IPV6Address");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MACAddress");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NetBios)
                .HasMaxLength(253)
                .IsUnicode(false);
            entity.Property(e => e.OperatingSystem).IsUnicode(false);
            entity.Property(e => e.Ssl)
                .IsUnicode(false)
                .HasColumnName("SSL");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.FkApplication).WithMany(p => p.Hosts)
                .HasForeignKey(d => d.FkApplicationId)
                .HasConstraintName("FK__Host__FK_Applica__44CA3770");

            entity.HasOne(d => d.FkDevice).WithMany(p => p.Hosts)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK__Host__FK_DeviceI__45BE5BA9");

            entity.HasOne(d => d.FkLocation).WithMany(p => p.Hosts)
                .HasForeignKey(d => d.FkLocationId)
                .HasConstraintName("FK__Host__FK_Locatio__46B27FE2");

            entity.HasOne(d => d.FkSourceTool).WithMany(p => p.Hosts)
                .HasForeignKey(d => d.FkSourceToolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Host__FK_SourceT__47A6A41B");
        });

        modelBuilder.Entity<KnowledgeBase>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Knowledg__CAB147CB4A1162FC");

            entity.ToTable("KnowledgeBase", "qualys");

            entity.Property(e => e.Qid).HasColumnName("QID");
            entity.Property(e => e.Category).IsUnicode(false);
            entity.Property(e => e.Consequence).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cvss)
                .IsUnicode(false)
                .HasColumnName("CVSS");
            entity.Property(e => e.Cvssv3)
                .IsUnicode(false)
                .HasColumnName("CVSSV3");
            entity.Property(e => e.Diagnosis).IsUnicode(false);
            entity.Property(e => e.Discovery).IsUnicode(false);
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.SoftwareList).IsUnicode(false);
            entity.Property(e => e.Solution).IsUnicode(false);
            entity.Property(e => e.ThreatIntelligence).IsUnicode(false);
            entity.Property(e => e.Title).IsUnicode(false);
            entity.Property(e => e.VulnType).IsUnicode(false);

            entity.HasOne(d => d.FkProcess).WithMany(p => p.KnowledgeBases)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Knowledge__FK_Pr__56E8E7AB");

            entity.HasOne(d => d.FkRun).WithMany(p => p.KnowledgeBases)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Knowledge__FK_Ru__57DD0BE4");
        });

        modelBuilder.Entity<KnowledgeBaseVulnerability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Knowledg__3214EC271CF94BC3");

            entity.ToTable("KnowledgeBaseVulnerability", "qualys");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkQid).HasColumnName("FK_QID");
            entity.Property(e => e.FkVulnerabilityId).HasColumnName("FK_VulnerabilityID");
            entity.Property(e => e.Value).IsUnicode(false);

            entity.HasOne(d => d.FkQ).WithMany(p => p.KnowledgeBaseVulnerabilities)
                .HasForeignKey(d => d.FkQid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Knowledge__FK_QI__58D1301D");

            entity.HasOne(d => d.FkVulnerability).WithMany(p => p.KnowledgeBaseVulnerabilities)
                .HasForeignKey(d => d.FkVulnerabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Knowledge__FK_Vu__59C55456");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC27AED4698C");

            entity.ToTable("Location", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("pk_logs");

            entity.Property(e => e.Callsite).IsUnicode(false);
            entity.Property(e => e.Exception).IsUnicode(false);
            entity.Property(e => e.Level).IsUnicode(false);
            entity.Property(e => e.Logged)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Logger).IsUnicode(false);
            entity.Property(e => e.MachineName).IsUnicode(false);
            entity.Property(e => e.Message).IsUnicode(false);
        });

        modelBuilder.Entity<MasterFinding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterFi__3214EC2791936A2E");

            entity.ToTable("MasterFinding", "core");

            entity.HasIndex(e => e.CreatedAtDate, "ix_core_MasterFinding_CreatedAtDate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAtDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkHostId).HasColumnName("FK_HostID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.FkSeverityId).HasColumnName("FK_SeverityID");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.FkHost).WithMany(p => p.MasterFindings)
                .HasForeignKey(d => d.FkHostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MasterFin__FK_Ho__489AC854");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.MasterFindings)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__MasterFin__FK_Pr__498EEC8D");

            entity.HasOne(d => d.FkRun).WithMany(p => p.MasterFindings)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__MasterFin__FK_Ru__4A8310C6");

            entity.HasOne(d => d.FkSeverity).WithMany(p => p.MasterFindings)
                .HasForeignKey(d => d.FkSeverityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MasterFin__FK_Se__4B7734FF");
        });

        modelBuilder.Entity<MasterFindingCve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterFi__3214EC278F6CCE54");

            entity.ToTable("MasterFindingCVE", "core");

            entity.HasIndex(e => e.Cve, "ix_core_MasterFindingCVE_CVE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cve)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CVE");
            entity.Property(e => e.FkCveid).HasColumnName("FK_CVEID");
            entity.Property(e => e.FkFindingId).HasColumnName("FK_FindingID");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkCve).WithMany(p => p.MasterFindingCves)
                .HasForeignKey(d => d.FkCveid)
                .HasConstraintName("FK__MasterFin__FK_CV__4C6B5938");

            entity.HasOne(d => d.FkFinding).WithMany(p => p.MasterFindingCves)
                .HasForeignKey(d => d.FkFindingId)
                .HasConstraintName("FK__MasterFin__FK_Fi__4D5F7D71");
        });

        modelBuilder.Entity<MasterFindingCwe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterFi__3214EC27D628C909");

            entity.ToTable("MasterFindingCWE", "core");

            entity.HasIndex(e => e.Cwe, "ix_core_MasterFindingCWE_CWE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cwe)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CWE");
            entity.Property(e => e.FkCweid).HasColumnName("FK_CWEID");
            entity.Property(e => e.FkFindingId).HasColumnName("FK_FindingID");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FkCwe).WithMany(p => p.MasterFindingCwes)
                .HasForeignKey(d => d.FkCweid)
                .HasConstraintName("FK__MasterFin__FK_CW__4E53A1AA");

            entity.HasOne(d => d.FkFinding).WithMany(p => p.MasterFindingCwes)
                .HasForeignKey(d => d.FkFindingId)
                .HasConstraintName("FK__MasterFin__FK_Fi__4F47C5E3");
        });

        modelBuilder.Entity<OrganizationalChart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organiza__3214EC273C8CCA1E");

            entity.ToTable("OrganizationalChart", "org");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.Fullname).IsUnicode(false);
            entity.Property(e => e.GivenName).IsUnicode(false);
            entity.Property(e => e.JobTitle).IsUnicode(false);
            entity.Property(e => e.Manager).IsUnicode(false);
            entity.Property(e => e.ManagerFullName).IsUnicode(false);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SamAccountName).IsUnicode(false);
            entity.Property(e => e.Surname).IsUnicode(false);
            entity.Property(e => e.UserPrincipalName).IsUnicode(false);

            entity.HasOne(d => d.FkProcess).WithMany(p => p.OrganizationalCharts)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Organizat__FK_Pr__55009F39");

            entity.HasOne(d => d.FkRun).WithMany(p => p.OrganizationalCharts)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Organizat__FK_Ru__55F4C372");
        });

        modelBuilder.Entity<OrganizationalVulnerability>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Organizational_Vulnerability");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Plugin>(entity =>
        {
            entity.HasKey(e => e.PluginId).HasName("PK__Plugin__7C10E5017EC29CDC");

            entity.ToTable("Plugin", "tenable");

            entity.Property(e => e.PluginId).HasColumnName("PluginID");
            entity.Property(e => e.CheckType).IsUnicode(false);
            entity.Property(e => e.Cpe)
                .IsUnicode(false)
                .HasColumnName("CPE");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cvssv3baseScore).HasColumnName("CVSSV3BaseScore");
            entity.Property(e => e.Cvssv3temporalScore).HasColumnName("CVSSV3TemporalScore");
            entity.Property(e => e.Cvssv3vector)
                .IsUnicode(false)
                .HasColumnName("CVSSV3Vector");
            entity.Property(e => e.Cvssv3vectorBf).HasColumnName("CVSSV3VectorBf");
            entity.Property(e => e.Cvssvector)
                .IsUnicode(false)
                .HasColumnName("CVSSVector");
            entity.Property(e => e.CvssvectorBf).HasColumnName("CVSSVectorBf");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Dstport)
                .IsUnicode(false)
                .HasColumnName("DSTPort");
            entity.Property(e => e.ExploitEase).IsUnicode(false);
            entity.Property(e => e.ExploitFrameworks).IsUnicode(false);
            entity.Property(e => e.FkFamilyId).HasColumnName("FK_FamilyID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Protocol).IsUnicode(false);
            entity.Property(e => e.RequiredPorts).IsUnicode(false);
            entity.Property(e => e.RequiredUdpports)
                .IsUnicode(false)
                .HasColumnName("RequiredUDPPorts");
            entity.Property(e => e.SeeAlso).IsUnicode(false);
            entity.Property(e => e.Solution).IsUnicode(false);
            entity.Property(e => e.Srcport)
                .IsUnicode(false)
                .HasColumnName("SRCPort");
            entity.Property(e => e.StigSeverity).IsUnicode(false);
            entity.Property(e => e.Synopsis).IsUnicode(false);
            entity.Property(e => e.VprContext).IsUnicode(false);

            entity.HasOne(d => d.FkFamily).WithMany(p => p.Plugins)
                .HasForeignKey(d => d.FkFamilyId)
                .HasConstraintName("FK__Plugin__FK_Famil__6166761E");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Plugins)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Plugin__FK_Proce__625A9A57");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Plugins)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Plugin__FK_RunID__634EBE90");
        });

        modelBuilder.Entity<QualysFinding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QualysFi__3214EC275A874AB9");

            entity.ToTable("QualysFinding", "qualys");

            entity.HasIndex(e => e.CreatedAtDate, "ix_qualys_QualysFinding_CreatedAtDate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAtDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FirstFoundDatetime).HasColumnType("datetime");
            entity.Property(e => e.FkHostId).HasColumnName("FK_HostID");
            entity.Property(e => e.FkMasterFindingId).HasColumnName("FK_MasterFindingID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkQid).HasColumnName("FK_QID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.LastFoundDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastProcessedDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastTestDatetime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDatetime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Results).IsUnicode(false);
            entity.Property(e => e.Source).IsUnicode(false);
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.UniqueVulnId).HasColumnName("UniqueVulnID");

            entity.HasOne(d => d.FkHost).WithMany(p => p.QualysFindings)
                .HasForeignKey(d => d.FkHostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QualysFin__FK_Ho__5AB9788F");

            entity.HasOne(d => d.FkMasterFinding).WithMany(p => p.QualysFindings)
                .HasForeignKey(d => d.FkMasterFindingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QualysFin__FK_Ma__5BAD9CC8");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.QualysFindings)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__QualysFin__FK_Pr__5CA1C101");

            entity.HasOne(d => d.FkQ).WithMany(p => p.QualysFindings)
                .HasForeignKey(d => d.FkQid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QualysFin__FK_QI__5D95E53A");

            entity.HasOne(d => d.FkRun).WithMany(p => p.QualysFindings)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__QualysFin__FK_Ru__5E8A0973");
        });

        modelBuilder.Entity<Repository>(entity =>
        {
            entity.HasKey(e => e.RepositoryId).HasName("PK__Reposito__B9BA86F1A58530B9");

            entity.ToTable("Repository", "tenable");

            entity.Property(e => e.RepositoryId).HasColumnName("RepositoryID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("UUID");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Repositories)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Repositor__FK_Pr__6442E2C9");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Repositories)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Repositor__FK_Ru__65370702");
        });

        modelBuilder.Entity<SerilogLog>(entity =>
        {
            entity.ToTable("Serilog_Logs");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Severity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Severity__3214EC277E19723E");

            entity.ToTable("Severity", "core");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Severity1>(entity =>
        {
            entity.HasKey(e => e.SeverityId).HasName("PK__Severity__C618A95154FACEF6");

            entity.ToTable("Severity", "tenable");

            entity.Property(e => e.SeverityId).HasColumnName("SeverityID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.HasKey(e => e.SolutionId).HasName("PK__Solution__6B633AF0C9CFD308");

            entity.ToTable("Solution", "tenable");

            entity.HasIndex(e => e.SolutionId, "UQ__Solution__6B633AF1E61C36E3").IsUnique();

            entity.Property(e => e.SolutionId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("SolutionID");
            entity.Property(e => e.Cpe)
                .IsUnicode(false)
                .HasColumnName("CPE");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Cvetotal).HasColumnName("CVETotal");
            entity.Property(e => e.Cvssv3baseScore).HasColumnName("CVSSV3BaseScore");
            entity.Property(e => e.FkPluginId).HasColumnName("FK_PluginID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.MsbulletInTotal).HasColumnName("MSBulletInTotal");
            entity.Property(e => e.RemediationList).IsUnicode(false);
            entity.Property(e => e.ScorePctg).IsUnicode(false);
            entity.Property(e => e.Solution1)
                .IsUnicode(false)
                .HasColumnName("Solution");
            entity.Property(e => e.TotalPctg).IsUnicode(false);
            entity.Property(e => e.Vprscore).HasColumnName("VPRScore");

            entity.HasOne(d => d.FkPlugin).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.FkPluginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solution__FK_Plu__662B2B3B");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__Solution__FK_Pro__671F4F74");

            entity.HasOne(d => d.FkRun).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__Solution__FK_Run__681373AD");
        });

        modelBuilder.Entity<TenableFinding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TenableF__3214EC27681441DA");

            entity.ToTable("TenableFinding", "tenable");

            entity.HasIndex(e => e.CreatedAtDate, "ix_tenable_TenableFinding_CreatedAtDate");

            entity.HasIndex(e => e.LastSeenDate, "ix_tenable_TenableFinding_LastSeenDate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcceptRiskRuleComment).IsUnicode(false);
            entity.Property(e => e.AssetExposureScore).IsUnicode(false);
            entity.Property(e => e.Bid).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAtDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Cve)
                .IsUnicode(false)
                .HasColumnName("CVE");
            entity.Property(e => e.FirstSeenDateTime).HasColumnType("datetime");
            entity.Property(e => e.FkFamilyId).HasColumnName("FK_FamilyID");
            entity.Property(e => e.FkHostId).HasColumnName("FK_HostID");
            entity.Property(e => e.FkMasterFindingId).HasColumnName("FK_MasterFindingID");
            entity.Property(e => e.FkPluginId).HasColumnName("FK_PluginID");
            entity.Property(e => e.FkProcessId).HasColumnName("FK_ProcessID");
            entity.Property(e => e.FkRepositoryId).HasColumnName("FK_RepositoryID");
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.FkTenableSeverityId).HasColumnName("FK_TenableSeverityID");
            entity.Property(e => e.Hash)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.HashUniqueness).IsUnicode(false);
            entity.Property(e => e.KeyDrivers).IsUnicode(false);
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PluginInfo).IsUnicode(false);
            entity.Property(e => e.Protocol).IsUnicode(false);
            entity.Property(e => e.RecastRiskRuleComment).IsUnicode(false);
            entity.Property(e => e.RiskFactor).IsUnicode(false);
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("UUID");
            entity.Property(e => e.Version).IsUnicode(false);
            entity.Property(e => e.Xref).IsUnicode(false);

            entity.HasOne(d => d.FkFamily).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkFamilyId)
                .HasConstraintName("FK__TenableFi__FK_Fa__690797E6");

            entity.HasOne(d => d.FkHost).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkHostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TenableFi__FK_Ho__69FBBC1F");

            entity.HasOne(d => d.FkMasterFinding).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkMasterFindingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TenableFi__FK_Ma__6AEFE058");

            entity.HasOne(d => d.FkPlugin).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkPluginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TenableFi__FK_Pl__6BE40491");

            entity.HasOne(d => d.FkProcess).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkProcessId)
                .HasConstraintName("FK__TenableFi__FK_Pr__6CD828CA");

            entity.HasOne(d => d.FkRepository).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkRepositoryId)
                .HasConstraintName("FK__TenableFi__FK_Re__6DCC4D03");

            entity.HasOne(d => d.FkRun).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkRunId)
                .HasConstraintName("FK__TenableFi__FK_Ru__6EC0713C");

            entity.HasOne(d => d.FkTenableSeverity).WithMany(p => p.TenableFindings)
                .HasForeignKey(d => d.FkTenableSeverityId)
                .HasConstraintName("FK__TenableFi__FK_Te__6FB49575");
        });

        modelBuilder.Entity<TransformHistory>(entity =>
        {
            entity.HasKey(e => e.RunId).HasName("PK__Transfor__A259D53D72E36138");

            entity.ToTable("TransformHistory", "core");

            entity.Property(e => e.RunId).HasColumnName("RunID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDatetime).HasColumnType("datetime");
            entity.Property(e => e.FkSourceToolId).HasColumnName("FK_SourceToolID");
            entity.Property(e => e.FkStatus).HasColumnName("FK_Status");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.FkSourceTool).WithMany(p => p.TransformHistories)
                .HasForeignKey(d => d.FkSourceToolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transform__FK_So__503BEA1C");

            entity.HasOne(d => d.FkStatusNavigation).WithMany(p => p.TransformHistories)
                .HasForeignKey(d => d.FkStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transform__FK_St__51300E55");
        });

        modelBuilder.Entity<TransformProcessHistory>(entity =>
        {
            entity.HasKey(e => e.ProcessId).HasName("PK__Transfor__1B39A976F133E8A2");

            entity.ToTable("TransformProcessHistory", "core");

            entity.Property(e => e.ProcessId).HasColumnName("ProcessID");
            entity.Property(e => e.BlobLastModified).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDatetime).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.FileHash).IsUnicode(false);
            entity.Property(e => e.FileName).IsUnicode(false);
            entity.Property(e => e.FilePrefix).IsUnicode(false);
            entity.Property(e => e.FkRunId).HasColumnName("FK_RunID");
            entity.Property(e => e.FkSourceToolId).HasColumnName("FK_SourceToolID");
            entity.Property(e => e.FkStatus).HasColumnName("FK_Status");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProcessName).IsUnicode(false);
            entity.Property(e => e.StartDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.FkRun).WithMany(p => p.TransformProcessHistories)
                .HasForeignKey(d => d.FkRunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transform__FK_Ru__5224328E");

            entity.HasOne(d => d.FkSourceTool).WithMany(p => p.TransformProcessHistories)
                .HasForeignKey(d => d.FkSourceToolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transform__FK_So__531856C7");

            entity.HasOne(d => d.FkStatusNavigation).WithMany(p => p.TransformProcessHistories)
                .HasForeignKey(d => d.FkStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transform__FK_St__540C7B00");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
