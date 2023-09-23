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
    internal class FirsrClassVehicleConfiguration : IEntityTypeConfiguration<FirstClassVehicle>
    {
        public void Configure(EntityTypeBuilder<FirstClassVehicle> builder)
        {
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

           
           
        }
    }
}
