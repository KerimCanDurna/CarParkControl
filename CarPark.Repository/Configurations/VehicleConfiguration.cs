using CarPark.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Repository.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.PlateNumber)
                .IsRequired()
                .IsUnicode();
           //  builder.HasIndex(x => x.PlateNumber).IsUnique();

            builder.Property(x => x.Fee).IsRequired().HasColumnType("decimal(18,2)");


        }

    }
}
