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
    public class PatientService
    {
       private readonly AppDbContext _appDbContext;
        public PatientService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        #region Add A Patient
        public async Task AddPatientAsync(Patient patient)
        {
            if (patient == null)
                Console.WriteLine("Can't Add A New patient Because It Is Empty:");
            else
            {
                try   // May Be DoctorId (FK) Not Found
                {

                    _appDbContext.Patients.Add(patient);
                    await _appDbContext.SaveChangesAsync();
                    Console.WriteLine($" patient {patient.Name} Is Added successfully");

                }
                catch (DbUpdateException)
                {
                    
                    _appDbContext.Entry(patient).State = EntityState.Detached;
                    Console.WriteLine("Database Error: invalid DoctorId");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Unexpected Error: {ex.Message}");
                }

            }

        }
        #endregion

        #region  Hard Delete Patient
        public async Task HardDeletePatientAsync(int patientId)
        {
            await _appDbContext.Patients
                 .Where(p => p.Id == patientId)
                 .ExecuteDeleteAsync();
            Console.WriteLine("A Patient Is Deleted");
            // Don't Need To SaveChanges Because It Deletes From DB Not Memory 
        }
        #endregion

        #region Update A Patient 
        public async Task UpdatePatientByEFAsync(Patient patient)
        {
            if (patient == null)
                Console.WriteLine("Can't Update Patient Because It Is Empty");
            else
            {
                // Ef Will Compaire And Update
                _appDbContext.Patients.Update(patient);
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Patient {patient.Name} updated successfully.");

            }
        }

        public async Task UpdatePatientManualAsync(Patient patient)
        {
            var _patient = await _appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == patient.Id);
            if (_patient == null)
                Console.WriteLine("Can't Update Patient Because Not Found");
            else
            {
                _patient.Name = patient.Name;
                _patient.Age = patient.Age;
                _patient.Phone = patient.Phone;
        
                // _appDbContext.Patients.Update(_patient);
                // We Not Need It
                // Because EF Will Trake The Object And Update It

                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Patient {patient.Name} updated successfully.");

            }
        }

        #endregion

        #region View A Patient Details
        public async Task ViewPatientWihtIdAsync(int PatientId)
        {
            var _patient = await _appDbContext.Patients
                                .AsNoTrackingWithIdentityResolution()
                                .Include(p=>p.Appointments)
                                .FirstOrDefaultAsync(p => p.Id == PatientId);

            if (_patient == null)
                Console.WriteLine("Can't View Patient Because Not Match PatientId");
            else
            {

                Console.WriteLine("\n================= Patient DETAILS =================");
                Console.WriteLine($"ID             : {_patient.Id}");
                Console.WriteLine($"Name           : {_patient.Name}");
                Console.WriteLine($"Phone          : {_patient.Phone}");
                Console.WriteLine($"Age            : {_patient.Age}");
                Console.WriteLine("==================================================");
                Console.WriteLine("\n--- Appointments List ---\n");
                if (_patient.Appointments != null && _patient.Appointments.Any())
                {
                    foreach (var App in _patient.Appointments)
                        Console.WriteLine($"AppointmentDate Is: {App.Date}");
                }
                else 
                {
                    Console.WriteLine("No appointments found for this patient");
                }

            }
        }

        #endregion




    }
}
