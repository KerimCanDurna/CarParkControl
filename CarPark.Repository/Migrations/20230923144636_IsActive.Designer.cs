﻿// <auto-generated />
using System;
using CarPark.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarPark.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230923144636_IsActive")]
    partial class IsActive
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarPark.Core.Model.FirstClassVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AutoPilot")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("FirstClassVehicle");
                });

            modelBuilder.Entity("CarPark.Core.Model.SecondClassVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("SpareTire")
                        .HasColumnType("bit");

                    b.Property<int>("TrunkCapacity")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("SecondClassVehicle");
                });

            modelBuilder.Entity("CarPark.Core.Model.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Utility")
                        .HasColumnType("int");

                    b.Property<int>("VehicleClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleClassId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarPark.Core.Model.VehicleClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceCoefficient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleClasses");
                });

            modelBuilder.Entity("CarPark.Core.Model.FirstClassVehicle", b =>
                {
                    b.HasOne("CarPark.Core.Model.Vehicle", null)
                        .WithOne("FirstClassVehicle")
                        .HasForeignKey("CarPark.Core.Model.FirstClassVehicle", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPark.Core.Model.SecondClassVehicle", b =>
                {
                    b.HasOne("CarPark.Core.Model.Vehicle", null)
                        .WithOne("SecondClassVehicle")
                        .HasForeignKey("CarPark.Core.Model.SecondClassVehicle", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPark.Core.Model.Vehicle", b =>
                {
                    b.HasOne("CarPark.Core.Model.VehicleClass", "VehicleClasses")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleClasses");
                });

            modelBuilder.Entity("CarPark.Core.Model.Vehicle", b =>
                {
                    b.Navigation("FirstClassVehicle")
                        .IsRequired();

                    b.Navigation("SecondClassVehicle")
                        .IsRequired();
                });

            modelBuilder.Entity("CarPark.Core.Model.VehicleClass", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
