﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt.Data;

#nullable disable

namespace projekt.Migrations
{
    [DbContext(typeof(projektContext))]
    partial class projektContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("projekt.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("projekt.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DestinationID")
                        .HasColumnType("int");

                    b.Property<int?>("LineID")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("PlaneID")
                        .HasColumnType("int");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.Property<int?>("TerminalID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationID");

                    b.HasIndex("LineID");

                    b.HasIndex("PlaneID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TerminalID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("projekt.Models.FlightPassenger", b =>
                {
                    b.Property<int>("FlightPassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightPassengerID"), 1L, 1);

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.HasKey("FlightPassengerID");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("FlightPassenger");
                });

            modelBuilder.Entity("projekt.Models.FlightStaff", b =>
                {
                    b.Property<int>("FlightStaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightStaffID"), 1L, 1);

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("FlightStaffID");

                    b.HasIndex("FlightId");

                    b.HasIndex("StaffId");

                    b.ToTable("FlightStaff");
                });

            modelBuilder.Entity("projekt.Models.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("projekt.Models.LinePlane", b =>
                {
                    b.Property<int>("LinePlaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinePlaneID"), 1L, 1);

                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.HasKey("LinePlaneID");

                    b.HasIndex("LineId");

                    b.HasIndex("PlaneId");

                    b.ToTable("LinePlanes");
                });

            modelBuilder.Entity("projekt.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Citizenship")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IDCardNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("projekt.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Shortcut")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("projekt.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("projekt.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("projekt.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("projekt.Models.Flight", b =>
                {
                    b.HasOne("projekt.Models.Destination", "Destination")
                        .WithMany("Flights")
                        .HasForeignKey("DestinationID");

                    b.HasOne("projekt.Models.Line", "Line")
                        .WithMany("Flights")
                        .HasForeignKey("LineID");

                    b.HasOne("projekt.Models.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneID");

                    b.HasOne("projekt.Models.Status", "Status")
                        .WithMany("Flights")
                        .HasForeignKey("StatusID");

                    b.HasOne("projekt.Models.Terminal", "Terminal")
                        .WithMany("Flights")
                        .HasForeignKey("TerminalID");

                    b.Navigation("Destination");

                    b.Navigation("Line");

                    b.Navigation("Plane");

                    b.Navigation("Status");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("projekt.Models.FlightPassenger", b =>
                {
                    b.HasOne("projekt.Models.Flight", "Flight")
                        .WithMany("FlightPassengers")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt.Models.Passenger", "Passenger")
                        .WithMany("FlightPassengers")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("projekt.Models.FlightStaff", b =>
                {
                    b.HasOne("projekt.Models.Flight", "Flight")
                        .WithMany("FlightStaffs")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt.Models.Staff", "Staff")
                        .WithMany("FlightStaffs")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("projekt.Models.LinePlane", b =>
                {
                    b.HasOne("projekt.Models.Line", "Line")
                        .WithMany("LinePlanes")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt.Models.Plane", "Plane")
                        .WithMany("LinePlanes")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("projekt.Models.Destination", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("projekt.Models.Flight", b =>
                {
                    b.Navigation("FlightPassengers");

                    b.Navigation("FlightStaffs");
                });

            modelBuilder.Entity("projekt.Models.Line", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("LinePlanes");
                });

            modelBuilder.Entity("projekt.Models.Passenger", b =>
                {
                    b.Navigation("FlightPassengers");
                });

            modelBuilder.Entity("projekt.Models.Plane", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("LinePlanes");
                });

            modelBuilder.Entity("projekt.Models.Staff", b =>
                {
                    b.Navigation("FlightStaffs");
                });

            modelBuilder.Entity("projekt.Models.Status", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("projekt.Models.Terminal", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
