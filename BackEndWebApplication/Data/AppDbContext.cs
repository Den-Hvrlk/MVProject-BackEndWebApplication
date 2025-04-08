using System;
using System.Collections.Generic;
using BackEndWebApplication.Models;
using BackEndWebApplication.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace BackEndWebApplication.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<CompleteFundraising> CompleteFundraising { get; set; }

    public virtual DbSet<CompleteRequest> CompleteRequest { get; set; }

    public virtual DbSet<FundImage> FundImage { get; set; }

    public virtual DbSet<FundProject> FundProject { get; set; }

    public virtual DbSet<FundProjectImage> FundProjectImage { get; set; }

    public virtual DbSet<Fundraising> Fundraising { get; set; }

    public virtual DbSet<GroupImage> GroupImage { get; set; }

    public virtual DbSet<ListOfActiveFundraising> ListOfActiveFundraising { get; set; }

    public virtual DbSet<ListOfActiveRequest> ListOfActiveRequest { get; set; }

    public virtual DbSet<ListOfCategories> ListOfCategories { get; set; }

    public virtual DbSet<ListOfCompleteFundraising> ListOfCompleteFundraising { get; set; }

    public virtual DbSet<ListOfCompleteRequest> ListOfCompleteRequest { get; set; }

    public virtual DbSet<MilitaryGroup> MilitaryGroup { get; set; }

    public virtual DbSet<MilitaryRequest> MilitaryRequest { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<VolunteerFund> VolunteerFund { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__6DB3A68AE23CA32F");

            entity.Property(e => e.IdCategory)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_Category");
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<CompleteFundraising>(entity =>
        {
            entity.HasKey(e => new { e.IdFundraising, e.IdFund }).HasName("PK__Complete__05137806273474F8");

            entity.Property(e => e.IdFundraising).HasColumnName("ID_Fundraising");
            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundsRaised).HasColumnType("money");

            entity.HasOne(d => d.IdFundNavigation).WithMany(p => p.CompleteFundraising)
                .HasForeignKey(d => d.IdFund)
                .HasConstraintName("FK__CompleteF__ID_Fu__68487DD7");

            entity.HasOne(d => d.IdFundraisingNavigation).WithMany(p => p.CompleteFundraising)
                .HasForeignKey(d => d.IdFundraising)
                .HasConstraintName("FK__CompleteF__ID_Fu__6754599E");
        });

        modelBuilder.Entity<CompleteRequest>(entity =>
        {
            entity.HasKey(e => new { e.IdRequest, e.IdFund }).HasName("PK__Complete__24CC0365AA141808");

            entity.Property(e => e.IdRequest).HasColumnName("ID_Request");
            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.CompleteDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdFundNavigation).WithMany(p => p.CompleteRequest)
                .HasForeignKey(d => d.IdFund)
                .HasConstraintName("FK__CompleteR__ID_Fu__6D0D32F4");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.CompleteRequest)
                .HasForeignKey(d => d.IdRequest)
                .HasConstraintName("FK__CompleteR__ID_Re__6C190EBB");
        });

        modelBuilder.Entity<FundImage>(entity =>
        {
            entity.HasKey(e => new { e.IdImage, e.IdFund }).HasName("PK__FundImag__C078C1CFC4D6FFBD");

            entity.Property(e => e.IdImage)
                .HasMaxLength(20)
                .HasColumnName("ID_Image");
            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.FundImagePath).HasMaxLength(255);

            entity.HasOne(d => d.IdFundNavigation).WithMany(p => p.FundImage)
                .HasForeignKey(d => d.IdFund)
                .HasConstraintName("FK__FundImage__ID_Fu__3E52440B");
        });

        modelBuilder.Entity<FundProject>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PK__FundProj__D310AEBFD5878E88");

            entity.Property(e => e.IdProject)
                .ValueGeneratedNever()
                .HasColumnName("ID_Project");
            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.ProjectCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProjectName).HasMaxLength(255);

            entity.HasOne(d => d.IdFundNavigation).WithMany(p => p.FundProject)
                .HasForeignKey(d => d.IdFund)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FundProje__ID_Fu__4F7CD00D");
        });

        modelBuilder.Entity<FundProjectImage>(entity =>
        {
            entity.HasKey(e => new { e.IdImage, e.IdProject }).HasName("PK__FundProj__DCD550C1E4EF0C5F");

            entity.Property(e => e.IdImage)
                .HasMaxLength(20)
                .HasColumnName("ID_Image");
            entity.Property(e => e.IdProject).HasColumnName("ID_Project");
            entity.Property(e => e.ProjectImagePath).HasMaxLength(255);

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.FundProjectImage)
                .HasForeignKey(d => d.IdProject)
                .HasConstraintName("FK__FundProje__ID_Pr__52593CB8");
        });

        modelBuilder.Entity<Fundraising>(entity =>
        {
            entity.HasKey(e => e.IdFundraising).HasName("PK__Fundrais__F48FE3E3308FB74C");

            entity.Property(e => e.IdFundraising)
                .ValueGeneratedNever()
                .HasColumnName("ID_Fundraising");
            entity.Property(e => e.FundrCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundrGoal).HasColumnType("money");
            entity.Property(e => e.FundrHeader).HasMaxLength(255);
            entity.Property(e => e.FundrImagePath).HasMaxLength(255);
            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Fundraising)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK__Fundraisi__ID_Gr__5FB337D6");

            entity.HasMany(d => d.IdCategory).WithMany(p => p.IdFundraising)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK__Fundraisi__ID_Ca__6383C8BA"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("IdFundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__628FA481"),
                    j =>
                    {
                        j.HasKey("IdFundraising", "IdCategory").HasName("PK__Fundrais__4254D98BFEA35F06");
                        j.IndexerProperty<Guid>("IdFundraising").HasColumnName("ID_Fundraising");
                        j.IndexerProperty<string>("IdCategory")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("ID_Category");
                    });

            entity.HasMany(d => d.IdFund).WithMany(p => p.IdFundraising)
                .UsingEntity<Dictionary<string, object>>(
                    "FundraisingSponsor",
                    r => r.HasOne<VolunteerFund>().WithMany()
                        .HasForeignKey("IdFund")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__70DDC3D8"),
                    l => l.HasOne<Fundraising>().WithMany()
                        .HasForeignKey("IdFundraising")
                        .HasConstraintName("FK__Fundraisi__ID_Fu__6FE99F9F"),
                    j =>
                    {
                        j.HasKey("IdFundraising", "IdFund").HasName("PK__Fundrais__05137806DDBB7D7D");
                        j.IndexerProperty<Guid>("IdFundraising").HasColumnName("ID_Fundraising");
                        j.IndexerProperty<Guid>("IdFund").HasColumnName("ID_Fund");
                    });
        });

        modelBuilder.Entity<GroupImage>(entity =>
        {
            entity.HasKey(e => new { e.IdImage, e.IdGroup }).HasName("PK__GroupIma__A8857FF78A0326D8");

            entity.Property(e => e.IdImage)
                .HasMaxLength(20)
                .HasColumnName("ID_Image");
            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
            entity.Property(e => e.GroupImagePath).HasMaxLength(255);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.GroupImage)
                .HasForeignKey(d => d.IdGroup)
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
            entity.Property(e => e.IdFundraising).HasColumnName("ID_Fundraising");
            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
        });

        modelBuilder.Entity<ListOfActiveRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfActiveRequest");

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
            entity.Property(e => e.IdRequest).HasColumnName("ID_Request");
            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);
        });

        modelBuilder.Entity<ListOfCategories>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCategories");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.IdCategory)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_Category");
        });

        modelBuilder.Entity<ListOfCompleteFundraising>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCompleteFundraising");

            entity.Property(e => e.FundsRaised).HasColumnType("money");
            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.IdFundraising).HasColumnName("ID_Fundraising");
        });

        modelBuilder.Entity<ListOfCompleteRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListOfCompleteRequest");

            entity.Property(e => e.IdFund).HasColumnName("ID_Fund");
            entity.Property(e => e.IdRequest).HasColumnName("ID_Request");
        });

        modelBuilder.Entity<MilitaryGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroup).HasName("PK__Military__96125DD8D930B465");

            entity.Property(e => e.IdGroup)
                .ValueGeneratedNever()
                .HasColumnName("ID_Group");
            entity.Property(e => e.CreateGroupDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<MilitaryRequest>(entity =>
        {
            entity.HasKey(e => e.IdRequest).HasName("PK__Military__D5509880F327074E");

            entity.Property(e => e.IdRequest)
                .ValueGeneratedNever()
                .HasColumnName("ID_Request");
            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
            entity.Property(e => e.RequestCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequestHeader).HasMaxLength(255);
            entity.Property(e => e.RequestImagePath).HasMaxLength(255);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.MilitaryRequest)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK__MilitaryR__ID_Gr__5629CD9C");

            entity.HasMany(d => d.IdCategory).WithMany(p => p.IdRequest)
                .UsingEntity<Dictionary<string, object>>(
                    "RequestCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK__RequestCa__ID_Ca__5BE2A6F2"),
                    l => l.HasOne<MilitaryRequest>().WithMany()
                        .HasForeignKey("IdRequest")
                        .HasConstraintName("FK__RequestCa__ID_Re__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("IdRequest", "IdCategory").HasName("PK__RequestC__638BA2E8318201DA");
                        j.IndexerProperty<Guid>("IdRequest").HasColumnName("ID_Request");
                        j.IndexerProperty<string>("IdCategory")
                            .HasMaxLength(6)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("ID_Category");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__ED4DE4428ABFD6C8");

            entity.Property(e => e.IdUser)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID_User");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserAvatarPath).HasMaxLength(255);

            entity.HasMany(d => d.UserFunds).WithMany(p => p.IdUser)
                .UsingEntity<Dictionary<string, object>>(
                    "FundMember",
                    r => r.HasOne<VolunteerFund>().WithMany()
                        .HasForeignKey("IdFund")
                        .HasConstraintName("FK__FundMembe__ID_Fu__4222D4EF"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__FundMembe__ID_Us__412EB0B6"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdFund").HasName("PK__FundMemb__1CD17FA7F95EED59");
                        j.IndexerProperty<Guid>("IdUser").HasColumnName("ID_User");
                        j.IndexerProperty<Guid>("IdFund").HasColumnName("ID_Fund");
                    });

            entity.HasMany(d => d.UserGroups).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "MilitaryGrpMember",
                    r => r.HasOne<MilitaryGroup>().WithMany()
                        .HasForeignKey("IdGroup")
                        .HasConstraintName("FK__MilitaryG__ID_Gr__4BAC3F29"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__MilitaryG__ID_Us__4AB81AF0"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdGroup").HasName("PK__Military__742CC19F1DEDF273");
                        j.IndexerProperty<Guid>("IdUser").HasColumnName("ID_User");
                        j.IndexerProperty<Guid>("IdGroup").HasColumnName("ID_Group");
                    });
        });

        modelBuilder.Entity<VolunteerFund>(entity =>
        {
            entity.HasKey(e => e.IdFund).HasName("PK__Voluntee__19C9BE5E542AC323");

            entity.Property(e => e.IdFund)
                .ValueGeneratedNever()
                .HasColumnName("ID_Fund");
            entity.Property(e => e.FundCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FundName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
