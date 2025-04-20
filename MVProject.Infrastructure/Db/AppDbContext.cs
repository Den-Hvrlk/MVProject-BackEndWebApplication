using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVProject.Domain.Entities.Views;
using MVProject.Domain.Entities;

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

    public virtual DbSet<Fundraising> Fundraisings { get; set; }

    public virtual DbSet<GroupImage> GroupImages { get; set; }

    public virtual DbSet<ListOfActiveFundraising> ListOfActiveFundraisings { get; set; }

    public virtual DbSet<ListOfActiveRequest> ListOfActiveRequests { get; set; }

    public virtual DbSet<ListOfCategory> ListOfCategories { get; set; }

    public virtual DbSet<ListOfCompleteFundraising> ListOfCompleteFundraisings { get; set; }

    public virtual DbSet<ListOfCompleteRequest> ListOfCompleteRequests { get; set; }

    public virtual DbSet<MilitaryGroup> MilitaryGroups { get; set; }

    public virtual DbSet<MilitaryGrpMember> MilitaryGrpMembers { get; set; }

    public virtual DbSet<MilitaryRequest> MilitaryRequests { get; set; }

    public virtual DbSet<RegisterFundRequest> RegisterFundRequests { get; set; }

    public virtual DbSet<RegisterGroupRequest> RegisterGroupRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerFund> VolunteerFunds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ID_Category).HasName("PK__Category__6DB3A68AA51DEC14");

            entity.ToTable("Category");

            entity.Property(e => e.ID_Category)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<CompleteFundraising>(entity =>
        {
            entity.HasKey(e => new { e.ID_Fundraising, e.ID_Fund }).HasName("PK__Complete__05137806DB31F012");

            entity.ToTable("CompleteFundraising");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundsRaised).HasColumnType("money");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteF__ID_Fu__1486F2C8");

            entity.HasOne(d => d.ID_FundraisingNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fundraising)
                .HasConstraintName("FK__CompleteF__ID_Fu__1392CE8F");
        });

        modelBuilder.Entity<CompleteRequest>(entity =>
        {
            entity.HasKey(e => new { e.ID_Request, e.ID_Fund }).HasName("PK__Complete__24CC03652905CE54");

            entity.ToTable("CompleteRequest");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteR__ID_Fu__194BA7E5");

            entity.HasOne(d => d.ID_RequestNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Request)
                .HasConstraintName("FK__CompleteR__ID_Re__185783AC");
        });

        modelBuilder.Entity<FundImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Fund }).HasName("PK__FundImag__C078C1CFE76F35E1");

            entity.ToTable("FundImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FundImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundImages)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__FundImage__ID_Fu__68A8708A");
        });

        modelBuilder.Entity<FundMember>(entity =>
        {
            entity.HasKey(e => new { e.ID_User, e.ID_Fund }).HasName("PK__FundMemb__1CD17FA743701EAD");

            entity.ToTable("FundMember");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundMembers)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__FundMembe__ID_Fu__6D6D25A7");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.FundMembers)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__FundMembe__ID_Us__6C79016E");
        });

        modelBuilder.Entity<FundProject>(entity =>
        {
            entity.HasKey(e => e.ID_Project).HasName("PK__FundProj__D310AEBFABEDC3D8");

            entity.ToTable("FundProject");

            entity.Property(e => e.ID_Project).ValueGeneratedNever();
            entity.Property(e => e.ProjectCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProjectName).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundProjects)
                .HasForeignKey(d => d.ID_Fund)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FundProje__ID_Fu__7BBB44FE");
        });

        modelBuilder.Entity<FundProjectImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Project }).HasName("PK__FundProj__DCD550C1297D01FD");

            entity.ToTable("FundProjectImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProjectImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_ProjectNavigation).WithMany(p => p.FundProjectImages)
                .HasForeignKey(d => d.ID_Project)
                .HasConstraintName("FK__FundProje__ID_Pr__7E97B1A9");
        });

        modelBuilder.Entity<Fundraising>(entity =>
        {
            entity.HasKey(e => e.ID_Fundraising).HasName("PK__Fundrais__F48FE3E3C11F4043");

            entity.ToTable("Fundraising");

            entity.Property(e => e.ID_Fundraising).ValueGeneratedNever();
            entity.Property(e => e.FundrCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundrHeader).HasMaxLength(255);
            entity.Property(e => e.FundrImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.Fundraisings)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__Fundraisi__ID_Gr__0BF1ACC7");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Fundraisings)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__Fundraisi__ID_Ca__0FC23DAB"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__0ECE1972"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Category").HasName("PK__Fundrais__4254D98B5B344AA8");
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
                        .HasConstraintName("FK__Fundraisi__ID_Fu__1D1C38C9"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__1C281490"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Fund").HasName("PK__Fundrais__051378067CCA41BF");
                        j.ToTable("FundraisingSponsor");
                    });
        });

        modelBuilder.Entity<GroupImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Group }).HasName("PK__GroupIma__A8857FF734918B15");

            entity.ToTable("GroupImage");

            entity.Property(e => e.ID_Image)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GroupImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.GroupImages)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__GroupImag__ID_Gr__7325FEFD");
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

        modelBuilder.Entity<MilitaryGroup>(entity =>
        {
            entity.HasKey(e => e.ID_Group).HasName("PK__Military__96125DD8CF344951");

            entity.ToTable("MilitaryGroup");

            entity.Property(e => e.ID_Group).ValueGeneratedNever();
            entity.Property(e => e.CreateGroupDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<MilitaryGrpMember>(entity =>
        {
            entity.HasKey(e => new { e.ID_User, e.ID_Group }).HasName("PK__Military__742CC19FF368E919");

            entity.ToTable("MilitaryGrpMember");

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.MilitaryGrpMembers)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__MilitaryG__ID_Gr__77EAB41A");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.MilitaryGrpMembers)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__MilitaryG__ID_Us__76F68FE1");
        });

        modelBuilder.Entity<MilitaryRequest>(entity =>
        {
            entity.HasKey(e => e.ID_Request).HasName("PK__Military__D5509880153A23E9");

            entity.ToTable("MilitaryRequest");

            entity.Property(e => e.ID_Request).ValueGeneratedNever();
            entity.Property(e => e.RequestCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.MilitaryRequests)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__MilitaryR__ID_Gr__0268428D");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Requests)
                .UsingEntity<Dictionary<string, object>>(
                    "RequestCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__RequestCa__ID_Ca__08211BE3"),
                    l => l.HasOne<MilitaryRequest>().WithMany()
                        .HasForeignKey("ID_Request")
                        .HasConstraintName("FK__RequestCa__ID_Re__072CF7AA"),
                    j =>
                    {
                        j.HasKey("ID_Request", "ID_Category").HasName("PK__RequestC__638BA2E8167D4A97");
                        j.ToTable("RequestCategory");
                        j.IndexerProperty<string>("ID_Category")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<RegisterFundRequest>(entity =>
        {
            entity.HasKey(e => e.ID_RegisterFundRequest).HasName("PK__Register__B5AB7372AB8C9D2B");

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
                .HasConstraintName("FK__RegisterF__ID_Us__5D36BDDE");
        });

        modelBuilder.Entity<RegisterGroupRequest>(entity =>
        {
            entity.HasKey(e => e.ID_RegisterGroupRequest).HasName("PK__Register__C9BB981AC42E3C8E");

            entity.ToTable("RegisterGroupRequest");

            entity.Property(e => e.ID_RegisterGroupRequest).HasDefaultValueSql("(newid())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
            entity.Property(e => e.RegisterGroupRequestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RegisterGroupRequestStatus).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.RegisterGroupRequests)
                .HasForeignKey(d => d.ID_User)
                .HasConstraintName("FK__RegisterG__ID_Us__62EF9734");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.ID_Role).HasName("PK__Role__43DCD32D6C8A475C");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B61606C8F4BC2").IsUnique();

            entity.Property(e => e.ID_Role).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__User__ED4DE44234324CB7");

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
                        .HasConstraintName("FK__UserRole__ID_Rol__577DE488"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("ID_User")
                        .HasConstraintName("FK__UserRole__ID_Use__5689C04F"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Role").HasName("PK__UserRole__29702970010BCA26");
                        j.ToTable("UserRole");
                    });
        });

        modelBuilder.Entity<VolunteerFund>(entity =>
        {
            entity.HasKey(e => e.ID_Fund).HasName("PK__Voluntee__19C9BE5E85CEA3B9");

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
