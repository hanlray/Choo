﻿// <auto-generated />
using System;
using Choo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Choo.Migrations
{
    [DbContext(typeof(ChooDbContext))]
    [Migration("20191128001028_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Choo.CarPassage", b =>
                {
                    b.Property<int>("CarPassageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("PassTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainPassageId")
                        .HasColumnType("int");

                    b.HasKey("CarPassageId");

                    b.HasIndex("TrainPassageId");

                    b.ToTable("CarPassage");

                    b.HasData(
                        new
                        {
                            CarPassageId = 1,
                            CarNumber = 1,
                            PassTime = new DateTime(2018, 8, 18, 7, 22, 16, 0, DateTimeKind.Unspecified),
                            TrainPassageId = 1
                        },
                        new
                        {
                            CarPassageId = 2,
                            CarNumber = 2,
                            PassTime = new DateTime(2018, 8, 18, 7, 22, 18, 0, DateTimeKind.Unspecified),
                            TrainPassageId = 1
                        },
                        new
                        {
                            CarPassageId = 3,
                            CarNumber = 1,
                            PassTime = new DateTime(2018, 8, 18, 8, 22, 16, 0, DateTimeKind.Unspecified),
                            TrainPassageId = 2
                        },
                        new
                        {
                            CarPassageId = 4,
                            CarNumber = 2,
                            PassTime = new DateTime(2018, 8, 18, 8, 22, 18, 0, DateTimeKind.Unspecified),
                            TrainPassageId = 2
                        });
                });

            modelBuilder.Entity("Choo.TrainPassage", b =>
                {
                    b.Property<int>("TrainPassageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PassTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainNumber")
                        .HasColumnType("int");

                    b.HasKey("TrainPassageId");

                    b.ToTable("TrainPassages");

                    b.HasData(
                        new
                        {
                            TrainPassageId = 1,
                            PassTime = new DateTime(2018, 8, 18, 7, 22, 16, 0, DateTimeKind.Unspecified),
                            TrainNumber = 1
                        },
                        new
                        {
                            TrainPassageId = 2,
                            PassTime = new DateTime(2018, 8, 18, 8, 22, 16, 0, DateTimeKind.Unspecified),
                            TrainNumber = 1
                        });
                });

            modelBuilder.Entity("Choo.CarPassage", b =>
                {
                    b.HasOne("Choo.TrainPassage", "TrainPassage")
                        .WithMany("CarPassages")
                        .HasForeignKey("TrainPassageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
