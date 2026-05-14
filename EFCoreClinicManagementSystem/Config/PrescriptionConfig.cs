using EFCoreClinicManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Config
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");
            builder.HasKey(Pres => Pres.Id);

            builder.Property(pres => pres.MedicineName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(nameof(Prescription.Dosage))
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(pres => pres.AppointmentId)
                   .IsRequired();

            builder.HasOne(pres => pres.Appointment)
                   .WithMany(Appoint => Appoint.Prescriptions)
                   .HasForeignKey(pres => pres.AppointmentId);
                   
        }
    }
}
