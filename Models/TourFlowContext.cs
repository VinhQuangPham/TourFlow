using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourFlowBE.Models;

public partial class TourFlowContext : DbContext
{
    public TourFlowContext()
    {
    }

    public TourFlowContext(DbContextOptions<TourFlowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityDestination> CityDestinations { get; set; }

    public virtual DbSet<CountryDestination> CountryDestinations { get; set; }

    public virtual DbSet<Img> Imgs { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourPlan> TourPlans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  => optionsBuilder.UseSqlServer("Server=localhost;Database=TourFlow;User Id=sa;Password=dockerStrongPwd123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityDestination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CityDest__3214EC274CC83B98");

            entity.ToTable("CityDestination");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(1000);
            entity.Property(e => e.CountryDestinationId).HasColumnName("CountryDestinationID");

            entity.HasOne(d => d.CountryDestination).WithMany(p => p.CityDestinations)
                .HasForeignKey(d => d.CountryDestinationId)
                .HasConstraintName("FK_CountryDestination");
        });

        modelBuilder.Entity<CountryDestination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CountryD__3214EC275EFEB90C");

            entity.ToTable("CountryDestination");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Country).HasMaxLength(1000);
        });

        modelBuilder.Entity<Img>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IMGs__3214EC27CC4BD992");

            entity.ToTable("IMGs");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityDestinationId).HasColumnName("CityDestinationID");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.CityDestination).WithMany(p => p.Imgs)
                .HasForeignKey(d => d.CityDestinationId)
                .HasConstraintName("FK_IMGsTourID");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tour__3214EC27247FE0A7");

            entity.ToTable("Tour");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityDestinationId).HasColumnName("CityDestinationID");
            entity.Property(e => e.DepartureLocation).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CityDestination).WithMany(p => p.Tours)
                .HasForeignKey(d => d.CityDestinationId)
                .HasConstraintName("FK_TourID");
        });

        modelBuilder.Entity<TourPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TourPlan__3214EC27B11510F7");

            entity.ToTable("TourPlan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TourId).HasColumnName("TourID");

            entity.HasOne(d => d.Tour).WithMany(p => p.TourPlans)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK_TourPlanID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
