using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class AirlineDBContext : DbContext
    {
        public AirlineDBContext()
        {
        }

        public AirlineDBContext(DbContextOptions<AirlineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAirlineRegister> TblAirlineRegisters { get; set; }
        public virtual DbSet<TblBookingdetail> TblBookingdetails { get; set; }
        public virtual DbSet<TblFlightdetail> TblFlightdetails { get; set; }
        public virtual DbSet<TblPassengerList> TblPassengerLists { get; set; }
        public virtual DbSet<TblUserdetail> TblUserdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AirlineDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAirlineRegister>(entity =>
            {
                entity.HasKey(e => e.AirlineId)
                    .HasName("PK_tblAirlineDetails");

                entity.ToTable("tblAirlineRegister");

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RegBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RegOn)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblBookingdetail>(entity =>
            {
                entity.ToTable("tblBookingdetails");

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.BookedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsOneWay)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFlightdetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("tblFlightdetails");

                entity.Property(e => e.AddedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalDetails).HasColumnType("datetime");

                entity.Property(e => e.DepartureDetails).HasColumnType("datetime");

                entity.Property(e => e.FlightName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentUsed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MealOption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SchldDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPassengerList>(entity =>
            {
                entity.HasKey(e => e.PsngrId)
                    .HasName("PK_tblPassengerDetails");

                entity.ToTable("tblPassengerLists");

                entity.Property(e => e.BookedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsMealOpted)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PsngrGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PsngrName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PsngrSeatNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserdetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_tblUserDetails");

                entity.ToTable("tblUserdetails");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
