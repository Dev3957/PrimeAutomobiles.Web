using Microsoft.EntityFrameworkCore;
using PrimeAutomobiles.Data.Models;

namespace PrimeAutomobiles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public DbSet<ServiceRepresentative> ServiceRepresentatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints

            // Vehicle-Owner (Customer) Relationship
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceRecord-Vehicle Relationship
            modelBuilder.Entity<ServiceRecord>()
                .HasOne(sr => sr.Vehicle)
                .WithMany(v => v.ServiceRecords)
                .HasForeignKey(sr => sr.VehicleID)
                .OnDelete(DeleteBehavior.Cascade);

            // ServiceRecord-ServiceRepresentative Relationship
            modelBuilder.Entity<ServiceRecord>()
                .HasOne(sr => sr.ServiceRepresentative)
                .WithMany(sa => sa.ServiceRecords)
                .HasForeignKey(sr => sr.ServiceAdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            // BillOfMaterial-ServiceRecord Relationship
            modelBuilder.Entity<BillOfMaterial>()
                .HasOne(bom => bom.ServiceRecord)
                .WithMany(sr => sr.BillOfMaterials)
                .HasForeignKey(bom => bom.ServiceID)
                .OnDelete(DeleteBehavior.Cascade);

            // Additional configuration for unique constraints (like VIN, Email, and Phone)
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.VIN)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Phone)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<ServiceRepresentative>()
                .HasIndex(sa => sa.Phone)
                .IsUnique();

            modelBuilder.Entity<ServiceRepresentative>()
                .HasIndex(sa => sa.Email)
                .IsUnique();
        }
    }
}
