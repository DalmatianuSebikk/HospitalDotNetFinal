﻿// <auto-generated />
using System;
using HospitalDotNetFinal.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalDotNetFinal.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220126160304_AddOtherTable")]
    partial class AddOtherTable
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

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Medic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumarDeTelefon")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NumeMedic")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpecializareMedic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpitalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpitalId");

                    b.ToTable("Medici");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.MedicPacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicId")
                        .HasColumnType("int");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("PacientId");

                    b.ToTable("MedicPacient");
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

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoalaId")
                        .HasColumnType("int");

                    b.Property<string>("CNP")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("NumarDeTelefon")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NumePacient")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SpitalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoalaId")
                        .IsUnique()
                        .HasFilter("[BoalaId] IS NOT NULL");

                    b.HasIndex("SpitalId");

                    b.ToTable("Pacienti");
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

                    b.Property<int?>("OrasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrasId")
                        .IsUnique()
                        .HasFilter("[OrasId] IS NOT NULL");

                    b.ToTable("Spitale");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Medic", b =>
                {
                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Spital", "Spital")
                        .WithMany("Medici")
                        .HasForeignKey("SpitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spital");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.MedicPacient", b =>
                {
                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Medic", "Medic")
                        .WithMany("MediciPacienti")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Pacient", "Pacient")
                        .WithMany("MediciPacienti")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Pacient", b =>
                {
                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Boala", "Boala")
                        .WithOne("Pacient")
                        .HasForeignKey("HospitalDotNetFinal.DAL.Entities.Pacient", "BoalaId");

                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Spital", "Spital")
                        .WithMany("Pacienti")
                        .HasForeignKey("SpitalId");

                    b.Navigation("Boala");

                    b.Navigation("Spital");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Spital", b =>
                {
                    b.HasOne("HospitalDotNetFinal.DAL.Entities.Oras", "Oras")
                        .WithOne("Spital")
                        .HasForeignKey("HospitalDotNetFinal.DAL.Entities.Spital", "OrasId");

                    b.Navigation("Oras");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Boala", b =>
                {
                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Medic", b =>
                {
                    b.Navigation("MediciPacienti");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Oras", b =>
                {
                    b.Navigation("Spital");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Pacient", b =>
                {
                    b.Navigation("MediciPacienti");
                });

            modelBuilder.Entity("HospitalDotNetFinal.DAL.Entities.Spital", b =>
                {
                    b.Navigation("Medici");

                    b.Navigation("Pacienti");
                });
#pragma warning restore 612, 618
        }
    }
}