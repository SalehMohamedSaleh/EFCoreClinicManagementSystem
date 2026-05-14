using EFCoreClinicManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // MultipleActiveResultSets=true
            // يسمح لك بتنفيذ عدة عمليات على قاعدة البيانات في وقت واحد عبر اتصال واحد،
            // وهو أمر مفيد عند التعامل مع الاستعلامات المتداخلة.
            optionsBuilder.UseSqlServer("Server=.;Database=ClinicManagementSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
