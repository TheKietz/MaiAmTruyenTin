using MaiAmTruyenTin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.Data;

public partial class MaiamtruyentinContext : DbContext
{
    public MaiamtruyentinContext()
    {
    }

    public MaiamtruyentinContext(DbContextOptions<MaiamtruyentinContext> options)
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
    public virtual DbSet<Event> Events { get; set; }
    public DbSet<StaticPage> StaticPages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        base.OnModelCreating(modelBuilder);

    }
}
