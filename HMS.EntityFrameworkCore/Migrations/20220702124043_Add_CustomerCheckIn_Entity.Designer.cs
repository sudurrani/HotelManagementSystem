﻿// <auto-generated />
using System;
using HMS.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HMS.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(HMSDbContext))]
    [Migration("20220702124043_Add_CustomerCheckIn_Entity")]
    partial class Add_CustomerCheckIn_Entity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HMS.Core.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NIC")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("NationalityId")
                        .HasColumnType("bigint");

                    b.Property<string>("PassportNo")
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("ProfessionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(5)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HMS.Core.Entities.CustomerCheckIn", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FromLocationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OutDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Remaining")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ToLocationId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalRent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("RoomId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("CustomerCheckIn");
                });

            modelBuilder.Entity("HMS.Core.Entities.CustomerRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<decimal>("AdvancePayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CommingFromId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("NextDestinationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("RoomRentFor24Hour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommingFromId");

                    b.HasIndex("NextDestinationId");

                    b.HasIndex("RoomId");

                    b.ToTable("CustomerRooms");
                });

            modelBuilder.Entity("HMS.Core.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            CreatedDateTime = new DateTime(2022, 7, 2, 17, 40, 42, 372, DateTimeKind.Local).AddTicks(1845),
                            IsDeleted = false,
                            Name = "Muhammad Zeb"
                        });
                });

            modelBuilder.Entity("HMS.Core.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HMS.Core.Entities.Nationality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("HMS.Core.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ContactPerson1Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson2Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson2Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson3Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson3Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("HMS.Core.Entities.Profession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("HMS.Core.Entities.PurposeOfVisit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(200)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("purposeOfVisits");
                });

            modelBuilder.Entity("HMS.Core.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            CreatedDateTime = new DateTime(2022, 7, 2, 17, 40, 42, 373, DateTimeKind.Local).AddTicks(9881),
                            IsDeleted = false,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("HMS.Core.Entities.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HMS.Core.Entities.Test", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("HMS.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            CreatedDateTime = new DateTime(2022, 7, 2, 17, 40, 42, 374, DateTimeKind.Local).AddTicks(1348),
                            EmployeeId = 1L,
                            IsDeleted = false,
                            Password = "123",
                            RoleId = 1L,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("HMS.Core.Entities.Customer", b =>
                {
                    b.HasOne("HMS.Core.Entities.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.HasOne("HMS.Core.Entities.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionId");

                    b.Navigation("Nationality");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("HMS.Core.Entities.CustomerCheckIn", b =>
                {
                    b.HasOne("HMS.Core.Entities.Customer", "Customer")
                        .WithMany("CustomerCheckIn")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("FromLocationId");

                    b.HasOne("HMS.Core.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Core.Entities.Location", "DepartureLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId");

                    b.Navigation("Customer");

                    b.Navigation("DepartureLocation");

                    b.Navigation("Location");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HMS.Core.Entities.CustomerRoom", b =>
                {
                    b.HasOne("HMS.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("CommingFromId");

                    b.HasOne("HMS.Core.Entities.Location", "DepartureLocation")
                        .WithMany()
                        .HasForeignKey("NextDestinationId");

                    b.HasOne("HMS.Core.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureLocation");

                    b.Navigation("Location");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HMS.Core.Entities.PurposeOfVisit", b =>
                {
                    b.HasOne("HMS.Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("HMS.Core.Entities.User", b =>
                {
                    b.HasOne("HMS.Core.Entities.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HMS.Core.Entities.Customer", b =>
                {
                    b.Navigation("CustomerCheckIn");
                });

            modelBuilder.Entity("HMS.Core.Entities.Employee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HMS.Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
