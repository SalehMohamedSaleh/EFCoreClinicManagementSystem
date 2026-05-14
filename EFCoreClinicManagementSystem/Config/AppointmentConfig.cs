using EFCoreClinicManagementSystem.Entities;
using EFCoreClinicManagementSystem.Entities.Enums;
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
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(Appoint => Appoint.Id);
            // Global Query Filter 
            builder.HasQueryFilter(Appoint => Appoint.Status != AppointmentStatus.Cancelled);

            builder.Property(Appoint => Appoint.Date)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()")// إنشاء التاريخ في قاعدة البيانات
                   .ValueGeneratedOnAdd();// لا يمكن تعديل التاريخ بعد الإنشاء

            builder.Property(Appoint => Appoint.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .HasDefaultValue(AppointmentStatus.Pending);

            builder.Property(Appoint => Appoint.DoctorId)
                   .IsRequired();

            builder.Property(Appoint => Appoint.PatientId)
                   .IsRequired();
                  
        }
    }
}
