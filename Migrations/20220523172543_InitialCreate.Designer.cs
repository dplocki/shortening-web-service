﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShorteningWebService.Database;

#nullable disable

namespace ShorteningWebService.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220523172543_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ShorteningWebService.LinkMap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OriginalLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shorted")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("LinkMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
