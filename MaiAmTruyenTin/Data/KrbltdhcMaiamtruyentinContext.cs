using MaiAmTruyenTin.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class KrbltdhcMaiamtruyentinContext : DbContext
{
    public KrbltdhcMaiamtruyentinContext()
    {
    }

    public KrbltdhcMaiamtruyentinContext(DbContextOptions<KrbltdhcMaiamtruyentinContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityVolunteer> ActivityVolunteers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Founder> Founders { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsImage> NewsImages { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<SponsorDonation> SponsorDonations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("krbltdhc_samatt");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activiti__45F4A791155C9173");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ActivityCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Activitie__Creat__73BA3083");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.ActivityDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Activitie__Delet__778AC167");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ActivityUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Activitie__Updat__75A278F5");
        });

        modelBuilder.Entity<ActivityVolunteer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC078D277701");

            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityVolunteers)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ActivityV__Activ__14270015");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.ActivityVolunteers)
                .HasForeignKey(d => d.VolunteerId)
                .HasConstraintName("FK__ActivityV__Volun__151B244E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B40CF0496");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__C5082EFBEE85D9CC");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Donations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Donations__UserI__0B91BA14");
        });

        modelBuilder.Entity<Founder>(entity =>
        {
            entity.HasKey(e => e.FounderId).HasName("PK__Founders__CC808F81D2688E27");

            entity.Property(e => e.Contribution).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.FounderCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Founders__Create__3D2915A8");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.FounderDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Founders__Delete__40F9A68C");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.FounderUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Founders__Update__3F115E1A");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__954EBDF3D4526F46");

            entity.Property(e => e.ApprovedAt).HasColumnType("datetime");
            entity.Property(e => e.CoverImage).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ViewCount).HasDefaultValue(0);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.NewsApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__News__ApprovedBy__05D8E0BE");

            entity.HasOne(d => d.Author).WithMany(p => p.NewsAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__News__AuthorId__7C4F7684");

            entity.HasOne(d => d.Category).WithMany(p => p.News)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__News__CategoryId__7B5B524B");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NewsCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__News__CreatedBy__00200768");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.NewsDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__News__DeletedBy__03F0984C");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.NewsUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__News__UpdatedBy__02084FDA");
        });

        modelBuilder.Entity<NewsImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__NewsImag__7516F70CEC29ABED");

            entity.Property(e => e.Caption).HasMaxLength(255);
            entity.Property(e => e.ImagePath).HasMaxLength(255);

            entity.HasOne(d => d.News).WithMany(p => p.NewsImages)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__NewsImage__NewsI__08B54D69");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.SponsorId).HasName("PK__Sponsors__3B609ED5FE5B0AA5");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Logo).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Representative).HasMaxLength(100);
            entity.Property(e => e.SponsorType).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SponsorCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Sponsors__Create__44CA3770");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.SponsorDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Sponsors__Delete__489AC854");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SponsorUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Sponsors__Update__46B27FE2");
        });

        modelBuilder.Entity<SponsorDonation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__SponsorD__C5082EFBD7F74A31");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(255);

            entity.HasOne(d => d.Sponsor).WithMany(p => p.SponsorDonations)
                .HasForeignKey(d => d.SponsorId)
                .HasConstraintName("FK__SponsorDo__Spons__4B7734FF");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99F51FCAEF");

            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.GuardianName).HasMaxLength(100);
            entity.Property(e => e.HealthStatus).HasMaxLength(255);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.StudentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Students__Create__619B8048");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.StudentDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Students__Delete__656C112C");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.StudentUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Students__Update__6383C8BA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C432E38E4");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053436BFD651").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Users__CreatedBy__5629CD9C");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.InverseDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Users__DeletedBy__59FA5E80");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Users__UpdatedBy__5812160E");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__UserToke__658FEEEAF1F5DF1D");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsRevoked).HasDefaultValue(false);
            entity.Property(e => e.RefreshToken).HasMaxLength(500);

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserToken__UserI__0F624AF8");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.VolunteerId).HasName("PK__Voluntee__716F6F2CE8EA7D1C");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Skills).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VolunteerCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Volunteer__Creat__6B24EA82");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.VolunteerDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Volunteer__Delet__6EF57B66");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.VolunteerUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Volunteer__Updat__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
