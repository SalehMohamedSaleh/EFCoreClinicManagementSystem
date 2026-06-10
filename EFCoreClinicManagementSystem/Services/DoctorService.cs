using EFCoreClinicManagementSystem.Data;
using EFCoreClinicManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Services
{
    public class DoctorService
    {
       
       private readonly AppDbContext _appDbContext;

        public DoctorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Add Anew Doctor

        public async Task AddDoctorAsync(Doctor doctor)
        {
           
            if (doctor == null)
                Console.WriteLine("Can't Add A New Doctor Because It Is Empty:");
            else
            {
                _appDbContext.Doctors.Add(doctor);
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Doctor {doctor.Name} Is Added successfully");

            }
        }

        #endregion

        #region A SoftDelete Doctor
        public async Task SoftDeletedDoctorAsync(int doctorId)
        {
            var doctor = await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
            if (doctor == null)
                Console.WriteLine($"No A DoctorId Match: {doctorId}");
            else
            {
                doctor.IsDeletedMethod();
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine("A Doctor Is Deleted Softelly");
            }
        }

        #endregion

        #region A Hard Delete Doctor
        public async Task HardDeleteDoctorAsync(int doctorId)
        {
           await _appDbContext.Doctors
                .Where(d=>d.Id==doctorId)
                .ExecuteDeleteAsync();
           Console.WriteLine("A Doctor Is Deleted");
            // Don't Need To SaveChanges Because It Deletes From DB Not Memory 
        }
        #endregion

        #region Update A Doctor
        public async Task UpdateDoctorByEFAsync(Doctor doctor)
        {
            if (doctor == null)
                Console.WriteLine("Can't Update Adoctor Because It Is Empty");
            else 
            {
                // Ef Will Compaire And Update
                _appDbContext.Doctors.Update(doctor);
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Doctor {doctor.Name} updated successfully.");
               
            }
        }

        public async Task UpdateDoctorManualAsync(Doctor doctor)
        { 
            var _doctor = await _appDbContext.Doctors.FirstOrDefaultAsync(d=>d.Id == doctor.Id);
            if (_doctor == null)
                Console.WriteLine("Can't Update Doctor Because Not Found");
            else
            {
                //_doctor.Name = doctor.Name;
                //_doctor.Salary = doctor.Salary;
                //_doctor.Specialization = doctor.Specialization;
                //_doctor.IsDeleted = doctor.IsDeleted;

                 _appDbContext.Doctors.Update(_doctor);
                // We Not Need It
                // Because EF Will Trake The Object And Update It

                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Doctor {doctor.Name} updated successfully.");

            }
        }

        #endregion

        #region View A Doctor
        public async Task ViewDoctorWihtIdAsync(int DoctorId)
        {
            var _doctor = await _appDbContext.Doctors
                                .AsNoTrackingWithIdentityResolution()
                                .FirstOrDefaultAsync(d=>d.Id == DoctorId);
            if (_doctor == null)
                Console.WriteLine("Can't View Doctor Because Not Match DoctorId");
            else
            {
                Console.WriteLine("\n================= DOCTOR DETAILS =================");
                Console.WriteLine($"ID             : {_doctor.Id}");
                Console.WriteLine($"Name           : {_doctor.Name}");
                Console.WriteLine($"Specialization : {_doctor.Specialization}");
                Console.WriteLine($"Salary         : {_doctor.Salary:C}");
                Console.WriteLine($"Status         : {(_doctor.IsDeleted ? "Inactive (Soft Deleted)" : "Active")}");
                Console.WriteLine("==================================================\n");
            }
        }

        #endregion

    }
}
