﻿// <auto-generated />
using HospitalDotNetFinal.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalDotNetFinal.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220126140654_AddOrasSpital")]
    partial class AddOrasSpital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Boala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gravitate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeBoala")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Boli");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Oras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocuitoriOras")
                        .HasColumnType("int");

                    b.Property<string>("NumeOras")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Orase");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Spital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeSpital")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrasId")
                        .IsUnique();

                    b.ToTable("Spitale");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Spital", b =>
                {
                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Oras", "Oras")
                        .WithOne("Spital")
                        .HasForeignKey("HospitalDotNetFinal.DAL.Entities.Spital", "OrasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oras");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Oras", b =>
                {
                    b.Navigation("Spital");
                });
#pragma warning restore 612, 618
        }
    }
}