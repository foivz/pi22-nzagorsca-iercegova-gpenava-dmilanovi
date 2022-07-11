using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Repository.Models;

namespace WebAPI.Repository
{
    public partial class PI2201_DBContext : DbContext
    {
        public PI2201_DBContext()
        {
        }

        public PI2201_DBContext(DbContextOptions<PI2201_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MlTablica> MlTablicas { get; set; } = null!;
        public virtual DbSet<ParkingSession> ParkingSessions { get; set; } = null!;
        public virtual DbSet<TmpMetereoloskiPodaci> TmpMetereoloskiPodacis { get; set; } = null!;
        public virtual DbSet<TmpParkingSpace> TmpParkingSpaces { get; set; } = null!;
        public virtual DbSet<TmpParkingSpaceLoad> TmpParkingSpaceLoads { get; set; } = null!;
        public virtual DbSet<TmpParkingSpot> TmpParkingSpots { get; set; } = null!;
        public virtual DbSet<TmpSensor> TmpSensors { get; set; } = null!;
        public virtual DbSet<TmpUser> TmpUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=31.147.204.119\\\\\\\\PISERVER,1433;Initial Catalog=PI2201_DB;trusted_connection=false;User id=PI2201_User;Password=--1HVzr}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSession>(entity =>
            {
                entity.Property(e => e.PssParkingSessionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TmpMetereoloskiPodaci>(entity =>
            {
                entity.HasKey(e => e.IdPodatka)
                    .HasName("PK_dbo.tmp_metereoloski_podaci");

                entity.Property(e => e.IdPodatka).ValueGeneratedNever();

                entity.Property(e => e.Cloudcover).IsFixedLength();

                entity.Property(e => e.Visibility).IsFixedLength();
            });

            modelBuilder.Entity<TmpSensor>(entity =>
            {
                entity.Property(e => e.SnrBleMac).IsFixedLength();
            });

            modelBuilder.Entity<TmpUser>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
