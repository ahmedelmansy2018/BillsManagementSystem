﻿// <auto-generated />
using System;
using Data_Access_layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Access_layer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211001203337_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business_Objects.BILDTL", b =>
                {
                    b.Property<int>("DTLCOD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BILCOD")
                        .HasColumnType("int");

                    b.Property<int?>("BILHDRBILCOD")
                        .HasColumnType("int");

                    b.Property<int>("ITMCOD")
                        .HasColumnType("int");

                    b.Property<int?>("ITMDTLITMCOD")
                        .HasColumnType("int");

                    b.Property<decimal>("ITMPRC")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ITMQTY")
                        .HasColumnType("int");

                    b.HasKey("DTLCOD");

                    b.HasIndex("BILHDRBILCOD");

                    b.HasIndex("ITMDTLITMCOD");

                    b.ToTable("BILDTLs");
                });

            modelBuilder.Entity("Business_Objects.BILHDR", b =>
                {
                    b.Property<int>("BILCOD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BILDAT")
                        .HasColumnType("datetime2");

                    b.Property<string>("BILIMG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ITMPRC")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("VNDCOD")
                        .HasColumnType("int");

                    b.Property<int?>("VNDDTLVNDCOD")
                        .HasColumnType("int");

                    b.HasKey("BILCOD");

                    b.HasIndex("VNDDTLVNDCOD");

                    b.ToTable("BILHDRs");
                });

            modelBuilder.Entity("Business_Objects.ITMDTL", b =>
                {
                    b.Property<int>("ITMCOD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ITMNAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ITMPRC")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ITMCOD");

                    b.ToTable("ITMDTLs");

                    b.HasData(
                        new
                        {
                            ITMCOD = 1,
                            ITMNAM = "panana",
                            ITMPRC = 50m
                        },
                        new
                        {
                            ITMCOD = 2,
                            ITMNAM = "tea",
                            ITMPRC = 30m
                        },
                        new
                        {
                            ITMCOD = 3,
                            ITMNAM = "suger",
                            ITMPRC = 40m
                        });
                });

            modelBuilder.Entity("Business_Objects.VNDDTL", b =>
                {
                    b.Property<int>("VNDCOD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VNDNAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VNDCOD");

                    b.ToTable("VNDDTLs");

                    b.HasData(
                        new
                        {
                            VNDCOD = 1,
                            VNDNAM = "Ahmed"
                        },
                        new
                        {
                            VNDCOD = 2,
                            VNDNAM = "ALi"
                        },
                        new
                        {
                            VNDCOD = 3,
                            VNDNAM = "Saad"
                        });
                });

            modelBuilder.Entity("Business_Objects.BILDTL", b =>
                {
                    b.HasOne("Business_Objects.BILHDR", "BILHDR")
                        .WithMany("BILDTL")
                        .HasForeignKey("BILHDRBILCOD");

                    b.HasOne("Business_Objects.ITMDTL", "ITMDTL")
                        .WithMany("BILDTL")
                        .HasForeignKey("ITMDTLITMCOD");
                });

            modelBuilder.Entity("Business_Objects.BILHDR", b =>
                {
                    b.HasOne("Business_Objects.VNDDTL", "VNDDTL")
                        .WithMany("BILHDRs")
                        .HasForeignKey("VNDDTLVNDCOD");
                });
#pragma warning restore 612, 618
        }
    }
}
