﻿// <auto-generated />
using System;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw11.Migrations
{
    [DbContext(typeof(HealthDbContext))]
    [Migration("20200612215136_InitialAddedTables")]
    partial class InitialAddedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw11.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Cw11.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("Cw11.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Cw11.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDocotor")
                        .HasColumnType("int");

                    b.Property<int?>("IdDoctorNavigationIdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<int?>("IdPatientNavigationIdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctorNavigationIdDoctor");

                    b.HasIndex("IdPatientNavigationIdPatient");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Cw11.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.Property<int?>("IdMedicamentNavigationIdMedicament")
                        .HasColumnType("int");

                    b.Property<int?>("IdPrescriptionNavigationIdPrescription")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament");

                    b.HasIndex("IdMedicamentNavigationIdMedicament");

                    b.HasIndex("IdPrescriptionNavigationIdPrescription");

                    b.ToTable("Prescription_Medicaments");
                });

            modelBuilder.Entity("Cw11.Models.Prescription", b =>
                {
                    b.HasOne("Cw11.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctorNavigationIdDoctor");

                    b.HasOne("Cw11.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatientNavigationIdPatient");
                });

            modelBuilder.Entity("Cw11.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("Cw11.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("Prescription_Medicaments")
                        .HasForeignKey("IdMedicamentNavigationIdMedicament");

                    b.HasOne("Cw11.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("Prescription_Medicaments")
                        .HasForeignKey("IdPrescriptionNavigationIdPrescription");
                });
#pragma warning restore 612, 618
        }
    }
}