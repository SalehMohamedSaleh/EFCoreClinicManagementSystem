using EFCoreClinicManagementSystem.Data;
using EFCoreClinicManagementSystem.Entities;
using EFCoreClinicManagementSystem.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Services
{
    internal class AppointmentService
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Add Appointment
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            if (appointment == null)
                Console.WriteLine("Can't Add A New Appointment Because It Is Empty:");
           
            else
            {   // Prevent duplicate appointments.
                bool IsBusy = await _appDbContext.Appointments
                                           .AnyAsync(App => App.DoctorId == appointment.DoctorId && App.Date == appointment.Date);
                if (IsBusy)
                    Console.WriteLine("Can't Add A New Appointment Because Doctor Or Date Is Busy:");
                else
                {
                    try
                    {
                        _appDbContext.Appointments.Add(appointment);
                        await _appDbContext.SaveChangesAsync();
                        Console.WriteLine($" Appointment {appointment.Id} In {appointment.Date} Is Added successfully");

                    }
                    catch (DbUpdateException)
                    {
                        _appDbContext.Entry(appointment).State = EntityState.Detached;
                        Console.WriteLine("Database Error: invalid DoctorId Or PatientId");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" Unexpected Error: {ex.Message}");

                    }
                }
            }
        }

        #endregion

        #region Delete Appointment
        public async Task DeleteAppointmentAsync(int appointmentId)
        { 
            var appointment = await _appDbContext.Appointments
                                                 .FindAsync(appointmentId);
            if (appointment == null)
                Console.WriteLine($"No A AppointmentIs Match: {appointmentId}");
            else
            {
                _appDbContext.Appointments.Remove(appointment);
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine($" Appointment {appointment.Id} Is Deleted successfully");
            }
        }
        #endregion

        #region Update Appointment
      
        public async Task UpdateAppointmentAsync(int appointmentId,DateTime appDatatime,int doctorId, AppointmentStatus status)
        {
            var appointment = await _appDbContext.Appointments
                                                 .FindAsync(appointmentId);

            if (appointment == null)
                Console.WriteLine($"No A AppointmentIs Match: ");
            
            else
            {
                appointment.Date = appDatatime;
                appointment.DoctorId = doctorId;
                appointment.Status = status;
                try
                {
                    await _appDbContext.SaveChangesAsync();
                    Console.WriteLine($" Appointment {appointment.Id} Is Uppdated successfully");
                }
                catch (DbUpdateException)
                {
                    Console.WriteLine($"Database Error: ");
                }
                catch(Exception ex)  
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        #endregion

        #region View Appointment Details
        public async Task ViewAppointmentDetailsWithIdAsync(int appointmentId)
        {
            var _appointment = await _appDbContext.Appointments
                                .AsNoTrackingWithIdentityResolution()
                                .Include(App => App.Doctor)
                                .Include(App =>App.Patient)
                                .Include(App=>App.Prescriptions)
                                .FirstOrDefaultAsync(App => App.Id == appointmentId);
            if (_appointment == null)
                Console.WriteLine("Can't View Appointment Because Not Match AppointmentId");
            else
            {
                Console.WriteLine("\n================= Appointment DETAILS =================");
                Console.WriteLine($"ID             : {_appointment.Id}");
                Console.WriteLine($"Date           : {_appointment.Date}");
                Console.WriteLine($"Doctor         : {_appointment.Doctor.Name}");
                Console.WriteLine($"Patient        : {_appointment.Patient.Name}");
                Console.WriteLine($"Status         : {_appointment.Status}");
                Console.WriteLine("==================================================\n");

                Console.WriteLine("\n================= AppointmentPrescriptions DETAILS =================");
                foreach (var Prescription in _appointment.Prescriptions)
                {
                    Console.WriteLine($"ID             : {Prescription.Id}");
                    Console.WriteLine($"MedicineName           : {Prescription.MedicineName}");
                    Console.WriteLine($"Dosage         : {Prescription.Dosage}");

                }
            }
        }

        #endregion

        #region Search appointments by doctor name.
        public async Task SearchAppointmentsByDoctorNameAsync(string doctorName)
        {
            var _appointments = await _appDbContext.Appointments
                                .AsNoTrackingWithIdentityResolution()
                                .Where(App=>(App.Doctor.Name).Contains(doctorName))
                                .Include(App => App.Doctor)
                                //.Include(App => App.Patient)
                                //.Include(App => App.Prescriptions)
                                .ToListAsync();
            if (_appointments == null || !_appointments.Any())
                Console.WriteLine("Can't View Appointment Because Not Match DoctorName");
            else
            {

                Console.WriteLine("\n================= Appointments Details =================");
                foreach (var _appointment in _appointments)
                {
                    Console.WriteLine($"ID                     : {_appointment.Id}");
                    Console.WriteLine($"Date                   : {_appointment.Date}");
                    Console.WriteLine($"Doctor Name            : {_appointment.Doctor.Name}");
                    Console.WriteLine($"Status                 : {_appointment.Status}");

                }
            }
        }


        #endregion

        #region View Appointments By Pagination.
        public async Task ViewAppointmentsByPaginationAsync(int pageNumber , int pageSize)
        {
            int skipCount = (pageNumber - 1) * pageSize;
            var appoint_Paginations = await _appDbContext.Appointments
                                                    .AsNoTracking()
                                                    .OrderBy(App=>App.Date)
                                                    .Skip(skipCount)
                                                    .Take(pageSize)
                                                    .ToListAsync();

            foreach (var appoint_Pagination in appoint_Paginations)
            {
                Console.WriteLine($"ID             : {appoint_Pagination.Id}");
                Console.WriteLine($"Date           : {appoint_Pagination.Date}");
                Console.WriteLine($"Status         : {appoint_Pagination.Status}");

            }

        }
        #endregion



    }
}
