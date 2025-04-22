using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVProject.Domain.Entities;
using MVProject.Domain.Entities.Views;

namespace MVProject.Infrastructure.Db;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CompleteFundraising> CompleteFundraisings { get; set; }

    public virtual DbSet<CompleteRequest> CompleteRequests { get; set; }

    public virtual DbSet<FundImage> FundImages { get; set; }

    public virtual DbSet<FundMember> FundMembers { get; set; }

    public virtual DbSet<FundProject> FundProjects { get; set; }

    public virtual DbSet<FundProjectImage> FundProjectImages { get; set; }

    public virtual DbSet<FundReport> FundReports { get; set; }

    public virtual DbSet<Fundraising> Fundraisings { get; set; }

    public virtual DbSet<GroupImage> GroupImages { get; set; }

    public virtual DbSet<GroupReport> GroupReports { get; set; }

    public virtual DbSet<ListOfActiveFundraising> ListOfActiveFundraisings { get; set; }

    public virtual DbSet<ListOfActiveRequest> ListOfActiveRequests { get; set; }

    public virtual DbSet<ListOfCategory> ListOfCategories { get; set; }

    public virtual DbSet<ListOfCompleteFundraising> ListOfCompleteFundraisings { get; set; }

    public virtual DbSet<ListOfCompleteRequest> ListOfCompleteRequests { get; set; }

    public virtual DbSet<ListOfFundrWithGroup> ListOfFundrWithGroups { get; set; }

    public virtual DbSet<MilitaryGroup> MilitaryGroups { get; set; }

    public virtual DbSet<MilitaryGrpMember> MilitaryGrpMembers { get; set; }

    public virtual DbSet<MilitaryRequest> MilitaryRequests { get; set; }

    public virtual DbSet<RegisterFundRequest> RegisterFundRequests { get; set; }

    public virtual DbSet<RegisterGroupRequest> RegisterGroupRequests { get; set; }

    public virtual DbSet<ReportForCompletedRequestsByFund> ReportForCompletedRequestsByFunds { get; set; }

    public virtual DbSet<ReportForFundRecievedFund> ReportForFundRecievedFunds { get; set; }

    public virtual DbSet<ReportForGroupRecievedFund> ReportForGroupRecievedFunds { get; set; }

    public virtual DbSet<ReportForGroupRequest> ReportForGroupRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerFund> VolunteerFunds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ID_Category).HasName("PK__Category__6DB3A68AD392C929");

            entity.ToTable("Category");

            entity.Property(e => e.ID_Category)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<CompleteFundraising>(entity =>
        {
            entity.HasKey(e => new { e.ID_Fundraising, e.ID_Fund }).HasName("PK__Complete__051378063EABC5D8");

            entity.ToTable("CompleteFundraising");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundsRaised).HasColumnType("money");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteF__ID_Fu__28ADE706");

            entity.HasOne(d => d.ID_FundraisingNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fundraising)
                .HasConstraintName("FK__CompleteF__ID_Fu__27B9C2CD");
        });

        modelBuilder.Entity<CompleteRequest>(entity =>
        {
            entity.HasKey(e => new { e.ID_Request, e.ID_Fund }).HasName("PK__Complete__24CC0365B3A623D2");

            entity.ToTable("CompleteRequest");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteR__ID_Fu__2D729C23");

            entity.HasOne(d => d.ID_RequestNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Request)
                .HasConstraintName("FK__CompleteR__ID_Re__2C7E77EA");
        });

        modelBuilder.Entity<FundImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Fund }).HasName("PK__FundImag__C078C1CFD749224B");

            entity.ToTable("FundImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FundImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundImages)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__FundImage__ID_Fu__7CCF64C8");
        });

        modelBuilder.Entity<FundMember>(entity =>
        {
            entity.HasKey(e => new { e.ID_User, e.ID_Fund }).HasName("PK__FundMemb__1CD17FA727E28572");

            entity.ToTable("FundMember");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundMembers)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__FundMembe__ID_Fu__019419E5");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.FundMembers)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__FundMembe__ID_Us__009FF5AC");
        });

        modelBuilder.Entity<FundProject>(entity =>
        {
            entity.HasKey(e => e.ID_Project).HasName("PK__FundProj__D310AEBFBCEFEAA3");

            entity.ToTable("FundProject");

            entity.Property(e => e.ID_Project).ValueGeneratedNever();
            entity.Property(e => e.ProjectCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProjectName).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundProjects)
                .HasForeignKey(d => d.ID_Fund)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FundProje__ID_Fu__0FE2393C");
        });

        modelBuilder.Entity<FundProjectImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Project }).HasName("PK__FundProj__DCD550C1A56A4152");

            entity.ToTable("FundProjectImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProjectImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_ProjectNavigation).WithMany(p => p.FundProjectImages)
                .HasForeignKey(d => d.ID_Project)
                .HasConstraintName("FK__FundProje__ID_Pr__12BEA5E7");
        });

        modelBuilder.Entity<FundReport>(entity =>
        {
            entity.HasKey(e => e.ID_FundReport).HasName("PK__FundRepo__2E6DCF00A5041C74");

            entity.ToTable("FundReport");

            entity.Property(e => e.ID_FundReport).ValueGeneratedNever();
            entity.Property(e => e.TotalGoals).HasColumnType("money");
            entity.Property(e => e.TotalRaised).HasColumnType("money");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundReports)
                .HasForeignKey(d => d.ID_Fund)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FundRepor__ID_Fu__341F99B2");
        });

        modelBuilder.Entity<Fundraising>(entity =>
        {
            entity.HasKey(e => e.ID_Fundraising).HasName("PK__Fundrais__F48FE3E35CA9F515");

            entity.ToTable("Fundraising");

            entity.Property(e => e.ID_Fundraising).ValueGeneratedNever();
            entity.Property(e => e.FundrCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundrHeader).HasMaxLength(255);
            entity.Property(e => e.FundrImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.Fundraisings)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__Fundraisi__ID_Gr__2018A105");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Fundraisings)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__Fundraisi__ID_Ca__23E931E9"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__22F50DB0"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Category").HasName("PK__Fundrais__4254D98B30D05723");
                        j.ToTable("FundraisingCategory");
                        j.IndexerProperty<string>("ID_Category")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });

            entity.HasMany(d => d.ID_Funds).WithMany(p => p.ID_Fundraisings)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingSponsor",
                    r => r.HasOne<VolunteerFund>().WithMany()
                        .HasForeignKey("ID_Fund")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__31432D07"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__304F08CE"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Fund").HasName("PK__Fundrais__05137806EAB73976");
                        j.ToTable("FundraisingSponsor");
                    });
        });

        modelBuilder.Entity<GroupImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Group }).HasName("PK__GroupIma__A8857FF71C1A3CFF");

            entity.ToTable("GroupImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GroupImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.GroupImages)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__GroupImag__ID_Gr__074CF33B");
        });

        modelBuilder.Entity<GroupReport>(entity =>
        {
            entity.HasKey(e => e.ID_GroupReport).HasName("PK__GroupRep__F29BC1DB2AE42A9F");

            entity.ToTable("GroupReport");

            entity.Property(e => e.ID_GroupReport).ValueGeneratedNever();
            entity.Property(e => e.FundsReceived).HasColumnType("money");
            entity.Property(e => e.GoalToBeRecieved).HasColumnType("money");

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.GroupReports)
                .HasForeignKey(d => d.ID_Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupRepo__ID_Gr__36FC065D");
        });

        modelBuilder.Entity<ListOfActiveFundraising>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfActiveFundraising");

            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundrHeader).HasMaxLength(255);
            entity.Property(e => e.FundrImagePath).HasMaxLength(255);
        });

        modelBuilder.Entity<ListOfActiveRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfActiveRequest");

            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);
        });

        modelBuilder.Entity<ListOfCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCategories");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.ID_Category)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ListOfCompleteFundraising>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCompleteFundraising");

            entity.Property(e => e.FundsRaised).HasColumnType("money");
        });

        modelBuilder.Entity<ListOfCompleteRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCompleteRequest");
        });

        modelBuilder.Entity<ListOfFundrWithGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfFundrWithGroup");

            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundsRaised).HasColumnType("money");
        });

        modelBuilder.Entity<MilitaryGroup>(entity =>
        {
            entity.HasKey(e => e.ID_Group).HasName("PK__Military__96125DD864881FB3");

            entity.ToTable("MilitaryGroup");

            entity.Property(e => e.ID_Group).ValueGeneratedNever();
            entity.Property(e => e.CreateGroupDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<MilitaryGrpMember>(entity =>
        {
            entity.HasKey(e => new { e.ID_User, e.ID_Group }).HasName("PK__Military__742CC19FF00E9F4C");

            entity.ToTable("MilitaryGrpMember");

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.MilitaryGrpMembers)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__MilitaryG__ID_Gr__0C11A858");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.MilitaryGrpMembers)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__MilitaryG__ID_Us__0B1D841F");
        });

        modelBuilder.Entity<MilitaryRequest>(entity =>
        {
            entity.HasKey(e => e.ID_Request).HasName("PK__Military__D55098804E137FA2");

            entity.ToTable("MilitaryRequest");

            entity.Property(e => e.ID_Request).ValueGeneratedNever();
            entity.Property(e => e.RequestCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.MilitaryRequests)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__MilitaryR__ID_Gr__168F36CB");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Requests)
                .UsingEntity<Dictionary<string, object>>(
                    "RequestCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__RequestCa__ID_Ca__1C481021"),
                    l => l.HasOne<MilitaryRequest>().WithMany()
                        .HasForeignKey("ID_Request")
                        .HasConstraintName("FK__RequestCa__ID_Re__1B53EBE8"),
                    j =>
                    {
                        j.HasKey("ID_Request", "ID_Category").HasName("PK__RequestC__638BA2E84A2ED522");
                        j.ToTable("RequestCategory");
                        j.IndexerProperty<string>("ID_Category")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<RegisterFundRequest>(entity =>
        {
            entity.HasKey(e => e.ID_RegisterFundRequest).HasName("PK__Register__B5AB7372E2BB9EAA");

            entity.ToTable("RegisterFundRequest");

            entity.Property(e => e.ID_RegisterFundRequest).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CodeUSR)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FundName).HasMaxLength(255);
            entity.Property(e => e.RegisterFundRequestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisterFundRequestStatus).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.RegisterFundRequests)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__RegisterF__ID_Us__715DB21C");
        });

        modelBuilder.Entity<RegisterGroupRequest>(entity =>
        {
            entity.HasKey(e => e.ID_RegisterGroupRequest).HasName("PK__Register__C9BB981A675C5BF0");

            entity.ToTable("RegisterGroupRequest");

            entity.Property(e => e.ID_RegisterGroupRequest).HasDefaultValueSql("(newid())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
            entity.Property(e => e.RegisterGroupRequestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisterGroupRequestStatus).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.RegisterGroupRequests)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__RegisterG__ID_Us__77168B72");
        });

        modelBuilder.Entity<ReportForCompletedRequestsByFund>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReportForCompletedRequestsByFund");
        });

        modelBuilder.Entity<ReportForFundRecievedFund>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReportForFundRecievedFunds");

            entity.Property(e => e.TotalGoals).HasColumnType("money");
            entity.Property(e => e.TotalRaised).HasColumnType("money");
        });

        modelBuilder.Entity<ReportForGroupRecievedFund>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReportForGroupRecievedFunds");

            entity.Property(e => e.FundsReceived).HasColumnType("money");
            entity.Property(e => e.GoalToBeRecieved).HasColumnType("money");
        });

        modelBuilder.Entity<ReportForGroupRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReportForGroupRequests");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.ID_Role).HasName("PK__Role__43DCD32D2F5DD1C2");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B61602CE48565").IsUnique();

            entity.Property(e => e.ID_Role).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__User__ED4DE4423841A112");

            entity.ToTable("User", tb => tb.HasTrigger("trg_AssignDefaultUserRole"));

            entity.Property(e => e.ID_User).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HashPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.UserAvatarPath).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasMany(d => d.ID_Roles).WithMany(p => p.ID_Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("ID_Role")
                        .HasConstraintName("FK__UserRole__ID_Rol__6BA4D8C6"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("ID_User")
                        .HasConstraintName("FK__UserRole__ID_Use__6AB0B48D"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Role").HasName("PK__UserRole__29702970FA6CDE5E");
                        j.ToTable("UserRole");
                    });
        });

        modelBuilder.Entity<VolunteerFund>(entity =>
        {
            entity.HasKey(e => e.ID_Fund).HasName("PK__Voluntee__19C9BE5EA3E33F72");

            entity.ToTable("VolunteerFund");

            entity.Property(e => e.ID_Fund).ValueGeneratedNever();
            entity.Property(e => e.CodeUSR)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FundCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
