﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cSharpBelt.Models;

namespace cSharpBelt.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200821164031_HappeningAttending")]
    partial class HappeningAttending
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cSharpBelt.Models.Attending", b =>
                {
                    b.Property<int>("AttendingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HappeningID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AttendingID");

                    b.HasIndex("HappeningID");

                    b.HasIndex("UserID");

                    b.ToTable("Attending");
                });

            modelBuilder.Entity("cSharpBelt.Models.Happening", b =>
                {
                    b.Property<int>("HappeningID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("HappeningDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HappeningTitle")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("HappeningID");

                    b.HasIndex("UserID");

                    b.ToTable("Happening");
                });

            modelBuilder.Entity("cSharpBelt.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cSharpBelt.Models.Attending", b =>
                {
                    b.HasOne("cSharpBelt.Models.Happening", "Happening")
                        .WithMany("GuestsAttending")
                        .HasForeignKey("HappeningID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cSharpBelt.Models.User", "User")
                        .WithMany("HappeningsAttending")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cSharpBelt.Models.Happening", b =>
                {
                    b.HasOne("cSharpBelt.Models.User", "UserCreator")
                        .WithMany("HappeningCreated")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
