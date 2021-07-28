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
    [Migration("20210727210815_readded_additional_saints_props")]
    partial class readded_additional_saints_props
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

                    b.Property<int?>("beatifiedYear")
                        .HasColumnType("int");

                    b.Property<string>("biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("canonizedYear")
                        .HasColumnType("int");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("deathYear")
                        .HasColumnType("int");

                    b.Property<DateTime?>("feastDay")
                        .HasColumnType("datetime2");

                    b.Property<bool>("martyr")
                        .HasColumnType("bit");

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
