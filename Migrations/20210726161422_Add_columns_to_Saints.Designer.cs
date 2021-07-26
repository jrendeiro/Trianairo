﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trianairo.Data;

namespace Trianairo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210726161422_Add_columns_to_Saints")]
    partial class Add_columns_to_Saints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Saint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("beatifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("canonizedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("deathDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("feastDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Saints");
                });
#pragma warning restore 612, 618
        }
    }
}
