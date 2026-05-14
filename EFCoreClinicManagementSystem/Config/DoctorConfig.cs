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
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(d => d.Id);

            builder.ToTable(t => t.HasCheckConstraint("CK_Doctor_Name_MinLength", "LEN(Name) >= 3"));
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.ToTable(t => t.HasCheckConstraint("CK_Doctor_Specialization_MinLength", "LEN(Specialization)>=3"));
            builder.Property(d => d.Specialization)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(d => d.Salary)
                   .IsRequired() 
                   .HasPrecision(18, 2);

            builder.Property(d => d.IsDeleted)
                   .HasDefaultValue(false);
            builder.HasQueryFilter(d => !d.IsDeleted);

            builder.HasMany(doc => doc.Appointments)
                   .WithOne(Appoint => Appoint.Doctor)
                   .HasForeignKey(Appoint => Appoint.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);//لعدم حذف الموعد إذا تم حذف الطبيب


        }
    }
}
