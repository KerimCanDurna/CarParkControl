using CarPark.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleClass> VehicleClasses { get; set; }

        // Sınıf bilgilerimizi vehicles üzerinden yapmak için kapattık ,
        // bu sınıfları tanımlasak da olur du fakat best practice olarak bu şekilde kullanılması daha uygun
        //public DbSet<FirstClassVehicle> FirstClassVehicles { get; set; }
        //public DbSet<SecondClassVehicle> SecondClassVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
