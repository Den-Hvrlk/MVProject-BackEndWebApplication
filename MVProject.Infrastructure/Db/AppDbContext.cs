using System;
using System.Collections.Generic;
using MVProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MVProject.Domain.Entities.Views;
using MVProject.API.MVProject.Domain.Entities;

namespace MVProject.Infrastructure.Db;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CompleteFundraising> CompleteFundraisings { get; set; }

    public virtual DbSet<CompleteRequest> CompleteRequests { get; set; }

    public virtual DbSet<FundImage> FundImages { get; set; }

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

    public virtual DbSet<MilitaryRequest> MilitaryRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerFund> VolunteerFunds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.ID_Role).HasName("PK__Role__43DCD32D2F63D41B");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B6160BCE80CCF").IsUnique();

            entity.Property(e => e.ID_Role)
                .ValueGeneratedNever()
                .HasColumnName("ID_Role");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ID_Category).HasName("PK__Category__6DB3A68A945F22AD");

            entity.ToTable("Category");

            entity.Property(e => e.ID_Category)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<CompleteFundraising>(entity =>
        {
            entity.HasKey(e => new { e.ID_Fundraising, e.ID_Fund }).HasName("PK__Complete__051378062B187F3E");

            entity.ToTable("CompleteFundraising");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundsRaised).HasColumnType("money");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteF__ID_Fu__68487DD7");

            entity.HasOne(d => d.ID_FundraisingNavigation).WithMany(p => p.CompleteFundraisings)
                .HasForeignKey(d => d.ID_Fundraising)
                .HasConstraintName("FK__CompleteF__ID_Fu__6754599E");
        });

        modelBuilder.Entity<CompleteRequest>(entity =>
        {
            entity.HasKey(e => new { e.ID_Request, e.ID_Fund }).HasName("PK__Complete__24CC0365AFB7C735");

            entity.ToTable("CompleteRequest");

            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__CompleteR__ID_Fu__6D0D32F4");

            entity.HasOne(d => d.ID_RequestNavigation).WithMany(p => p.CompleteRequests)
                .HasForeignKey(d => d.ID_Request)
                .HasConstraintName("FK__CompleteR__ID_Re__6C190EBB");
        });

        modelBuilder.Entity<FundImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Fund }).HasName("PK__FundImag__C078C1CF663F880A");

            entity.ToTable("FundImage");

            entity.Property(e => e.ID_Image).HasMaxLength(20);
            entity.Property(e => e.FundImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundImages)
                .HasForeignKey(d => d.ID_Fund)
                .HasConstraintName("FK__FundImage__ID_Fu__3E52440B");
        });

        modelBuilder.Entity<FundProject>(entity =>
        {
            entity.HasKey(e => e.ID_Project).HasName("PK__FundProj__D310AEBF52415695");

            entity.ToTable("FundProject");

            entity.Property(e => e.ID_Project).ValueGeneratedNever();
            entity.Property(e => e.ProjectCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProjectName).HasMaxLength(255);

            entity.HasOne(d => d.ID_FundNavigation).WithMany(p => p.FundProjects)
                .HasForeignKey(d => d.ID_Fund)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FundProje__ID_Fu__4F7CD00D");
        });

        modelBuilder.Entity<FundProjectImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Project }).HasName("PK__FundProj__DCD550C1138391D5");

            entity.ToTable("FundProjectImage");

            entity.Property(e => e.ID_Image).HasMaxLength(20);
            entity.Property(e => e.ProjectImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_ProjectNavigation).WithMany(p => p.FundProjectImages)
                .HasForeignKey(d => d.ID_Project)
                .HasConstraintName("FK__FundProje__ID_Pr__52593CB8");
        });

        modelBuilder.Entity<Fundraising>(entity =>
        {
            entity.HasKey(e => e.ID_Fundraising).HasName("PK__Fundrais__F48FE3E3A47DB2DF");

            entity.ToTable("Fundraising");

            entity.Property(e => e.ID_Fundraising).ValueGeneratedNever();
            entity.Property(e => e.FundrCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundrHeader).HasMaxLength(255);
            entity.Property(e => e.FundrImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.Fundraisings)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__Fundraisi__ID_Gr__5FB337D6");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Fundraisings)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__Fundraisi__ID_Ca__6383C8BA"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__628FA481"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Category").HasName("PK__Fundrais__4254D98B4F8BE857");
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
                        .HasConstraintName("FK__Fundraisi__ID_Fu__70DDC3D8"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("ID_Fundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__6FE99F9F"),
                    j =>
                    {
                        j.HasKey("ID_Fundraising", "ID_Fund").HasName("PK__Fundrais__051378063A716851");
                        j.ToTable("FundraisingSponsor");
                    });
        });

        modelBuilder.Entity<GroupImage>(entity =>
        {
            entity.HasKey(e => new { e.ID_Image, e.ID_Group }).HasName("PK__GroupIma__A8857FF7D6436757");

            entity.ToTable("GroupImage");

            entity.Property(e => e.ID_Image).HasMaxLength(20);
            entity.Property(e => e.GroupImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.GroupImages)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__GroupImag__ID_Gr__47DBAE45");
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
            entity.HasKey(e => e.ID_Group).HasName("PK__Military__96125DD87387BADF");

            entity.ToTable("MilitaryGroup");

            entity.Property(e => e.ID_Group).ValueGeneratedNever();
            entity.Property(e => e.CreateGroupDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<MilitaryRequest>(entity =>
        {
            entity.HasKey(e => e.ID_Request).HasName("PK__Military__D5509880C0AA5EDB");

            entity.ToTable("MilitaryRequest");

            entity.Property(e => e.ID_Request).ValueGeneratedNever();
            entity.Property(e => e.RequestCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);

            entity.HasOne(d => d.ID_GroupNavigation).WithMany(p => p.MilitaryRequests)
                .HasForeignKey(d => d.ID_Group)
                .HasConstraintName("FK__MilitaryR__ID_Gr__5629CD9C");

            entity.HasMany(d => d.ID_Categories).WithMany(p => p.ID_Requests)
                .UsingEntity<Dictionary<string, object>>(
                    "RequestCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ID_Category")
                        .HasConstraintName("FK__RequestCa__ID_Ca__5BE2A6F2"),
                    l => l.HasOne<MilitaryRequest>().WithMany()
                        .HasForeignKey("ID_Request")
                        .HasConstraintName("FK__RequestCa__ID_Re__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("ID_Request", "ID_Category").HasName("PK__RequestC__638BA2E8103B1269");
                        j.ToTable("RequestCategory");
                        j.IndexerProperty<string>("ID_Category")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__User__ED4DE4420BDC30C6");

            entity.ToTable("User");

            entity.Property(e => e.ID_User)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID_User");
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

            entity.HasMany(d => d.ID_Funds).WithMany(p => p.ID_Users)
                .UsingEntity<Dictionary<string, object>>(
                    "FundMember",
                    r => r.HasOne<VolunteerFund>().WithMany()
                        .HasForeignKey("ID_Fund")
                        .HasConstraintName("FK__FundMembe__ID_Fu__220B0B18"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("ID_User")
                        .HasConstraintName("FK__FundMembe__ID_Us__2116E6DF"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Fund").HasName("PK__FundMemb__1CD17FA7329325C5");
                        j.ToTable("FundMember");
                        j.IndexerProperty<Guid>("ID_User").HasColumnName("ID_User");
                        j.IndexerProperty<Guid>("ID_Fund").HasColumnName("ID_Fund");
                    });

            entity.HasMany(d => d.ID_Groups).WithMany(p => p.ID_Users)
                .UsingEntity<Dictionary<string, object>>(
                    "MilitaryGrpMember",
                    r => r.HasOne<MilitaryGroup>().WithMany()
                        .HasForeignKey("ID_Group")
                        .HasConstraintName("FK__MilitaryG__ID_Gr__2B947552"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("ID_User")
                        .HasConstraintName("FK__MilitaryG__ID_Us__2AA05119"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Group").HasName("PK__Military__742CC19FBB4E920D");
                        j.ToTable("MilitaryGrpMember");
                        j.IndexerProperty<Guid>("ID_User").HasColumnName("ID_User");
                        j.IndexerProperty<Guid>("ID_Group").HasColumnName("ID_Group");
                    });

            entity.HasMany(d => d.ID_Roles).WithMany(p => p.ID_User)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("ID_Role")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRole__ID_Rol__1881A0DE"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("ID_User")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRole__ID_Use__178D7CA5"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Role").HasName("PK__UserRole__297029704210CA37");
                        j.ToTable("UserRole");
                        j.IndexerProperty<Guid>("ID_User").HasColumnName("ID_User");
                        j.IndexerProperty<int>("ID_Role").HasColumnName("ID_Role");
                    });
        });

        modelBuilder.Entity<VolunteerFund>(entity =>
        {
            entity.HasKey(e => e.ID_Fund).HasName("PK__Voluntee__19C9BE5E75928ACD");

            entity.ToTable("VolunteerFund");

            entity.Property(e => e.ID_Fund).ValueGeneratedNever();
            entity.Property(e => e.FundCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
