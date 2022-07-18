using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;

        }

        public BaseDbContext()
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<Location>(location =>
            {
                location.ToTable("Locations").HasKey(k => k.Id);
                location.Property(p => p.Id).HasColumnName("Id");
                location.Property(p => p.Longitude).HasColumnName("Longitude");
                location.Property(p => p.Latitude).HasColumnName("Latitude");


            });


            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.ToTable("Vehicles").HasKey(k => k.Id);
                vehicle.Property(p => p.Id).HasColumnName("Id");
                vehicle.Property(p => p.YearModel).HasColumnName("YearModel");
                vehicle.Property(p => p.Make).HasColumnName("Make");
                vehicle.Property(p => p.DateAdded).HasColumnName("DateAdded");
                vehicle.Property(p => p.Licensed).HasColumnName("Licensed");
                vehicle.Property(p => p.Model).HasColumnName("Model");
                vehicle.Property(p => p.Price).HasColumnName("Price");

            });


            modelBuilder.Entity<Warehouse>(warehouse =>
            {
                warehouse.ToTable("Warehouses").HasKey(k => k.Id);
                warehouse.Property(p => p.Id).HasColumnName("Id");
                warehouse.Property(p => p.LocationId).HasColumnName("LocationId");

                warehouse.HasOne(p => p.Location);
                warehouse.HasMany(c => c.Cars);

            });



            modelBuilder.Entity<Car>(car =>
            {
                car.ToTable("Cars").HasKey(k => k.Id);
                car.Property(p => p.Id).HasColumnName("Id");
                car.Property(p => p.VehicleId).HasColumnName("VehicleId");
                car.Property(p => p.Location).HasColumnName("Location");

                car.HasMany(p => p.Vehicles);

            });








        }
    }
}
