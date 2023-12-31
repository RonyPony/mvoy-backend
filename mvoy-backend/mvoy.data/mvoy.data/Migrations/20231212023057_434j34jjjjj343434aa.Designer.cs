﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvoy.data.DataContext;

#nullable disable

namespace mvoy.data.Migrations
{
    [DbContext(typeof(MvoyContext))]
    [Migration("20231212023057_434j34jjjjj343434aa")]
    partial class _434j34jjjjj343434aa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("mvoy.core.Models.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("motorcycleUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<Guid>("tripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("offers");
                });

            modelBuilder.Entity("mvoy.core.Models.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DestinyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("arrivingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("clientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("distance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("leavingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("mvoy.core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("creationDate");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<string>("UserKind")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("userType");

                    b.Property<string>("birthDate")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("birthDate");

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("cedula");

                    b.Property<int>("contactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasColumnName("gender");

                    b.Property<bool>("isDriver")
                        .HasColumnType("bit");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname");

                    b.Property<string>("lastname2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname2");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("midName");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("mvoy.core.Models.UserContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("relativeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("relativePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usersContactInfo");
                });

            modelBuilder.Entity("mvoy.core.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("mvoy.core.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("chasis")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("chasis");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("color");

                    b.Property<string>("license")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("licencia");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("marca");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("modelo");

                    b.Property<Guid>("ownerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("placa");

                    b.Property<string>("seguro")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("seguro");

                    b.Property<string>("tieneSeguro")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("hasinsurance");

                    b.Property<string>("year")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("vehicles");
                });

            modelBuilder.Entity("mvoy.core.Models.UserRole", b =>
                {
                    b.HasOne("mvoy.core.Models.User", null)
                        .WithMany("roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mvoy.core.Models.User", b =>
                {
                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}
