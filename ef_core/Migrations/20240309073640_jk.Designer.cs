﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace csharpTest.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240309073640_jk")]
    partial class jk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirportArrival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stop")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AirportArrival");
                });

            modelBuilder.Entity("AirportDeparture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stop")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AirportDeparture");
                });

            modelBuilder.Entity("Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("Flight", b =>
                {
                    b.Property<int>("DepartureId")
                        .HasColumnType("int");

                    b.Property<int>("ArrivalId")
                        .HasColumnType("int");

                    b.HasKey("DepartureId", "ArrivalId");

                    b.HasIndex("ArrivalId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Flight", b =>
                {
                    b.HasOne("AirportArrival", "Arrival")
                        .WithMany("Flights")
                        .HasForeignKey("ArrivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportDeparture", "Departure")
                        .WithMany("Flights")
                        .HasForeignKey("DepartureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arrival");

                    b.Navigation("Departure");
                });

            modelBuilder.Entity("AirportArrival", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AirportDeparture", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}