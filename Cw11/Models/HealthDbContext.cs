using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;

namespace Cw11.Models
{
    public class HealthDbContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public HealthDbContext() { }

        public HealthDbContext(DbContextOptions options)
        :base(options){

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16597;Integrated Security=True");
            }
        }

           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicament>().HasKey(m => m.IdMedicament).HasAnnotation("DatabaseGenerated", "DatabaseGeneratedOption.Identity");
            modelBuilder.Entity<Prescription>().HasKey(p => p.IdPrescription).HasAnnotation("DatabaseGenerated", "DatabaseGeneratedOption.Identity");
            modelBuilder.Entity<Prescription_Medicament>().HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<Prescription_Medicament>().HasOne(pm => pm.Medicament).WithMany(m => m.Prescription_Medicaments).HasForeignKey(pm => pm.IdMedicament);
            modelBuilder.Entity<Prescription_Medicament>().HasOne(pm => pm.Prescription).WithMany(p => p.Prescription_Medicaments).HasForeignKey(pm => pm.IdPrescription);

            seedData(modelBuilder);
        }
        private void seedData(ModelBuilder modelBuilder)
        {
            var dictMedicament = new List<Medicament>();
            dictMedicament.Add(new Medicament { IdMedicament = 1, Name = "Polopiryna", Description = "Lek przeciwzapalny", Type = "Bez recepty" });
            dictMedicament.Add(new Medicament { IdMedicament = 2, Name = "Acard", Description = "Lek sercowy", Type = "Bez recepty" });
            dictMedicament.Add(new Medicament { IdMedicament = 3, Name = "Witamina C", Description = "Lek ogólnodostępny", Type = "Witamina" });
            var dictDoctors = new List<Doctor>();
            dictDoctors.Add(new Doctor { IdDoctor = 1, FirstName = "Eryk", LastName = "Latacz", Email = "eryklatacz@wp.pl" });
            dictDoctors.Add(new Doctor { IdDoctor = 2, FirstName = "Lucyna", LastName = "Kasza", Email = "lucynakasza@onet.pl" });
            dictDoctors.Add(new Doctor { IdDoctor = 3, FirstName = "Hanna", LastName = "Lis", Email = "hannalis@onet.pl" });
            var dictPatients = new List<Patient>();
            dictPatients.Add(new Patient { IdPatient = 1, FirstName = "Janina", LastName = "Nowak", Birthdate = DateTime.Parse("17-06-1999") });
            dictPatients.Add(new Patient { IdPatient = 2, FirstName = "Alan", LastName = "Mucka", Birthdate = DateTime.Parse("02-02-1981") });
            dictPatients.Add(new Patient { IdPatient = 3, FirstName = "Krystian", LastName = "Latacz", Birthdate = DateTime.Parse("02-02-1981") });
            var dictPrescriptions = new List<Prescription>();
            dictPrescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(15), IdDoctor = 3, IdPatient = 2 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(45), IdDoctor = 3, IdPatient = 1 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(8), IdDoctor = 2, IdPatient = 2 });
            var dictPrescriptionMedicaments = new List<Prescription_Medicament>();
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 3, Dose = 100, Details = "szczegół1" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 20, Details = "Szczegóły2" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 5, Details = "Szczegóły3" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 3, Dose = 50, Details = "Szczegóły4" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 100, Details = "Szczegóły5" });
            modelBuilder.Entity<Medicament>().HasData(dictMedicament);
            modelBuilder.Entity<Doctor>().HasData(dictDoctors);
            modelBuilder.Entity<Patient>().HasData(dictPatients);
            modelBuilder.Entity<Prescription>().HasData(dictPrescriptions);
            modelBuilder.Entity<Prescription_Medicament>().HasData(dictPrescriptionMedicaments);
        }
    }
       
}
