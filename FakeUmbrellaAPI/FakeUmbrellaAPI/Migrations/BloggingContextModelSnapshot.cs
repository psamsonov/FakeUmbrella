﻿// <auto-generated />
using System;
using FakeUmbrellaAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeUmbrellaAPI.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("FakeUmbrellaAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
