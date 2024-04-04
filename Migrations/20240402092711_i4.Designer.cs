﻿// <auto-generated />
using System;
using APIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIS.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240402092711_i4")]
    partial class i4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIS.Models.Booking", b =>
                {
                    b.Property<int>("b_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("b_id"));

                    b.Property<DateTime>("Booking_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Journey_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("boarding_Point")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("bookingstatus")
                        .HasColumnType("bit");

                    b.Property<string>("drop_Point")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noofPassenger")
                        .HasColumnType("int");

                    b.Property<int>("r_id")
                        .HasColumnType("int");

                    b.Property<string>("v_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("b_id");

                    b.HasIndex("r_id");

                    b.HasIndex("v_id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("APIS.Models.Driver", b =>
                {
                    b.Property<int>("d_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("d_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("d_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("licenseno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mobileno")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("d_id");

                    b.HasIndex(new[] { "mobileno" }, "UniqueIndexD")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("APIS.Models.Route", b =>
                {
                    b.Property<int>("r_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("r_id"));

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("distance")
                        .HasColumnType("int");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("r_id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("APIS.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DOB")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("mobile_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "mobile_no" }, "UniqueIndex")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIS.Models.Vehicle", b =>
                {
                    b.Property<string>("v_no")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("fare")
                        .HasColumnType("int");

                    b.Property<int>("sitting_cap")
                        .HasColumnType("int");

                    b.Property<string>("v_Image")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("v_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("v_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("v_no");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("APIS.Models.Booking", b =>
                {
                    b.HasOne("APIS.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("r_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIS.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("v_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
