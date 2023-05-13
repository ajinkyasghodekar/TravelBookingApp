﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBookingApp.Data;

#nullable disable

namespace TravelBookingApp.Migrations
{
    [DbContext(typeof(MyAppDb))]
    partial class MyAppDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelBookingApp.Model.Airlines", b =>
                {
                    b.Property<string>("AirlineCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirlineCode");

                    b.ToTable("AirlinesTable");
                });

            modelBuilder.Entity("TravelBookingApp.Model.AuthSecurity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthSecurityTable");
                });

            modelBuilder.Entity("TravelBookingApp.Model.Flights", b =>
                {
                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightCode");

                    b.HasIndex("AirlineCode");

                    b.ToTable("FlightsTable");
                });

            modelBuilder.Entity("TravelBookingApp.Model.Journeys", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlightCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPassengers")
                        .HasColumnType("int");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TravelDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AirlineCode");

                    b.HasIndex("FlightCode");

                    b.ToTable("JourneysTable");
                });

            modelBuilder.Entity("TravelBookingApp.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ajinkya@gmail.com",
                            Name = "Ajinkya",
                            Password = "Ajinkya123",
                            Role = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ajay@gmail.com",
                            Name = "Ajay",
                            Password = "Ajay123",
                            Role = "user"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Sam@gmail.com",
                            Name = "Sam",
                            Password = "Sam123",
                            Role = "user"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Ram@gmail.com",
                            Name = "Ram",
                            Password = "Ram123",
                            Role = "user"
                        },
                        new
                        {
                            Id = 5,
                            Email = "john@gmail.com",
                            Name = "John",
                            Password = "John123",
                            Role = "user"
                        });
                });

            modelBuilder.Entity("TravelBookingApp.Model.Flights", b =>
                {
                    b.HasOne("TravelBookingApp.Model.Airlines", "Airlines")
                        .WithMany()
                        .HasForeignKey("AirlineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airlines");
                });

            modelBuilder.Entity("TravelBookingApp.Model.Journeys", b =>
                {
                    b.HasOne("TravelBookingApp.Model.Airlines", "Airlines")
                        .WithMany()
                        .HasForeignKey("AirlineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelBookingApp.Model.Flights", "Flights")
                        .WithMany()
                        .HasForeignKey("FlightCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airlines");

                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
