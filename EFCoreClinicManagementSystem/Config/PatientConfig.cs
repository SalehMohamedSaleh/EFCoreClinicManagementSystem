using EFCoreClinicManagementSystem.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Config
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(nameof(Patient.Id));

            builder.ToTable(t => t.HasCheckConstraint("Ck_Patient_Name_Length", "LEN(Name)>3"));
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(p => p.Age)
                   .IsRequired();

            builder.Property(p => p.Phone)
                   .IsRequired();

            builder.HasMany(p => p.Appointments)
                   .WithOne(Appoint => Appoint.Patient)
                   .HasForeignKey(Appoint => Appoint.PatientId);
                   
        }
    }
}
