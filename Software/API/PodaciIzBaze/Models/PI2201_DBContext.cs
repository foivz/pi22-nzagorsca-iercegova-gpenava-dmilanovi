using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PodaciIzBaze.Models
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

        public virtual DbSet<TmpParkingSession> TmpParkingSessions { get; set; } = null!;
        public virtual DbSet<TmpParkingSpace> TmpParkingSpaces { get; set; } = null!;
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
            modelBuilder.Entity<TmpParkingSession>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_parking_session");

                entity.Property(e => e.PssEndTime).HasColumnName("pss_end_time");

                entity.Property(e => e.PssParkingSessionId).HasColumnName("pss_parking_session_id");

                entity.Property(e => e.PssParkingSpotId).HasColumnName("pss_parking_spot_id");

                entity.Property(e => e.PssSensorId).HasColumnName("pss_sensor_id");

                entity.Property(e => e.PssStartTime).HasColumnName("pss_start_time");
            });

            modelBuilder.Entity<TmpParkingSpace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_parking_space");

                entity.Property(e => e.PspAddressName)
                    .HasMaxLength(50)
                    .HasColumnName("psp_address_name");

                entity.Property(e => e.PspCalculatedFreePlaces).HasColumnName("psp_calculated_free_places");

                entity.Property(e => e.PspCalculatedOccupiedPlaces).HasColumnName("psp_calculated_occupied_places");

                entity.Property(e => e.PspCityName)
                    .HasMaxLength(50)
                    .HasColumnName("psp_city_name");

                entity.Property(e => e.PspLabel)
                    .HasMaxLength(150)
                    .HasColumnName("psp_label");

                entity.Property(e => e.PspLatitude).HasColumnName("psp_latitude");

                entity.Property(e => e.PspLongitude).HasColumnName("psp_longitude");

                entity.Property(e => e.PspParkingSpaceId).HasColumnName("psp_parking_space_id");
            });

            modelBuilder.Entity<TmpParkingSpot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_parking_spot");

                entity.Property(e => e.SptIndex).HasColumnName("spt_index");

                entity.Property(e => e.SptLabel)
                    .HasMaxLength(150)
                    .HasColumnName("spt_label");

                entity.Property(e => e.SptLatitude).HasColumnName("spt_latitude");

                entity.Property(e => e.SptLongitude).HasColumnName("spt_longitude");

                entity.Property(e => e.SptOccupied).HasColumnName("spt_occupied");

                entity.Property(e => e.SptOccupiedTimestamp).HasColumnName("spt_occupied_timestamp");

                entity.Property(e => e.SptParkingSpaceId).HasColumnName("spt_parking_space_id");

                entity.Property(e => e.SptParkingSpotId).HasColumnName("spt_parking_spot_id");

                entity.Property(e => e.SptSpotType)
                    .HasMaxLength(150)
                    .HasColumnName("spt_spot_type");
            });

            modelBuilder.Entity<TmpSensor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_sensor");

                entity.Property(e => e.SnrBleMac)
                    .HasMaxLength(17)
                    .HasColumnName("snr_ble_mac")
                    .IsFixedLength();

                entity.Property(e => e.SnrCurrentMagdataTime).HasColumnName("snr_current_magdata_time");

                entity.Property(e => e.SnrNbpsBatteryLevel).HasColumnName("snr_nbps_battery_level");

                entity.Property(e => e.SnrNbpsBatteryVoltage).HasColumnName("snr_nbps_battery_voltage");

                entity.Property(e => e.SnrNbpsCellId).HasColumnName("snr_nbps_cell_id");

                entity.Property(e => e.SnrNbpsNetworkSignal).HasColumnName("snr_nbps_network_signal");

                entity.Property(e => e.SnrNbpsPacketsSent).HasColumnName("snr_nbps_packets_sent");

                entity.Property(e => e.SnrNbpsRsrqValue).HasColumnName("snr_nbps_rsrq_value");

                entity.Property(e => e.SnrSensorId).HasColumnName("snr_sensor_id");
            });

            modelBuilder.Entity<TmpUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tmp_users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.CarTable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("car_table");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lozinka");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.TipKorisnika)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipKorisnika");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
