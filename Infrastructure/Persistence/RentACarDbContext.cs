using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

#nullable disable

namespace Infrastructure.Persistence
{
    public partial class RentACarDbContext : DbContext, IApplicationDbContext
    {
        public RentACarDbContext()
        {
        }

        public RentACarDbContext(DbContextOptions<RentACarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<TransferFee> TransferFees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.ApplyConfiguration(new Configurations.BookingConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CarConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CountryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.LocationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PackageConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TransferFeeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}