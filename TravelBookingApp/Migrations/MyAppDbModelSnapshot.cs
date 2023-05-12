﻿// <auto-generated />
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirlineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirlinesTable");
                });

            modelBuilder.Entity("TravelBookingApp.Model.Flights", b =>
                {
                    b.Property<string>("FlightCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightCode");

                    b.ToTable("FlightsTable");
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
#pragma warning restore 612, 618
        }
    }
}
