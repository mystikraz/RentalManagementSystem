using Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<SubMeter> SubMeters { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>(b =>
            {
                b.HasMany(e => e.Buildings)
                    .WithOne(e => e.Address)
                    .HasForeignKey(ur => ur.AddressId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<Building>(b =>
            {
                b.HasMany(e => e.Flats)
                    .WithOne(e => e.Building)
                    .HasForeignKey(ur => ur.BuildingId)
                    .IsRequired();
                b.HasOne(e => e.Meter)
                   .WithMany(e => e.Buildings)
                   .HasForeignKey(ur => ur.MeterId);
                b.Property(p => p.Rate)
                   .HasColumnType("decimal(18,4)");
            });
            builder.Entity<Flat>(b =>
            {
                b.HasMany(e => e.Rooms)
                    .WithOne(e => e.Flat)
                    .HasForeignKey(ur => ur.FlatId)
                    .IsRequired();
                b.HasOne(e => e.SubMeter)
                    .WithMany(e => e.Flats)
                    .HasForeignKey(ur => ur.SubMeterId);
                b.Property(p => p.Rate)
               .HasColumnType("decimal(18,4)");
            });
            builder.Entity<Room>(b =>
            {
                b.HasOne(e => e.SubMeter)
                    .WithMany(e => e.Rooms)
                    .HasForeignKey(ur => ur.SubMeterId)
               .OnDelete(DeleteBehavior.NoAction);
                b.Property(p => p.Rate)
                .HasColumnType("decimal(18,4)");
            });
            builder.Entity<Tenant>(b =>
            {
                b.HasOne(e => e.Building)
                    .WithOne(e => e.Tenant)
                    .HasForeignKey<Tenant>(ur => ur.BuildingId)
               .OnDelete(DeleteBehavior.NoAction);
                b.HasOne(e => e.Flat)
                   .WithOne(e => e.Tenant)
                   .HasForeignKey<Tenant>(ur => ur.BuildingId)
                    .OnDelete(DeleteBehavior.NoAction); ;
                b.HasOne(e => e.Room)
                  .WithOne(e => e.Tenant)
                  .HasForeignKey<Tenant>(ur => ur.BuildingId)
                   .OnDelete(DeleteBehavior.NoAction); ;
            });
            builder.Entity<Rent>(b =>
            {
                b.HasOne(e => e.Tenant)
                    .WithMany(e => e.Rents)
                    .HasForeignKey(ur => ur.TenantId);
                b.Property(p => p.Price)
                 .HasColumnType("decimal(18,4)");
            });
            builder.Entity<Meter>(b =>
            {
                b.Property(p => p.Rate)
              .HasColumnType("decimal(18,4)");
            });
            builder.Entity<SubMeter>(b =>
            {
                b.Property(p => p.Rate)
              .HasColumnType("decimal(18,4)");
            });
        }
    }
}