using EFCoreClinicManagementSystem.Data;
using EFCoreClinicManagementSystem.Entities;
using EFCoreClinicManagementSystem.Entities.Enums;
using EFCoreClinicManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreClinicManagementSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            #region Open Connction Wiht DB By AppDbContext Object

            using AppDbContext appDbContext = new AppDbContext();

            #endregion

            #region Create Service Objects

            DoctorService doctorService = new DoctorService(appDbContext);
            PatientService patientService = new PatientService(appDbContext);
            AppointmentService appointmentService = new AppointmentService(appDbContext);

            #endregion

            #region Add Data To DataBase

            #region Add List Of Doctors

            //List<Doctor> newdoctors = new List<Doctor>
            //{
            //    new Doctor { Name = "Dr. James Wilson", Specialization = "Cardiology", Salary = 15000m },
            //    new Doctor { Name = "Dr. Mary Johnson", Specialization = "Pediatrics", Salary = 12000m },
            //    new Doctor { Name = "Dr. Robert Smith", Specialization = "Dermatology", Salary = 14000m },
            //    new Doctor { Name = "Dr. Patricia Brown", Specialization = "Orthopedics", Salary = 18000m },
            //    new Doctor { Name = "Dr. Michael Davis", Specialization = "Neurology", Salary = 22000m },
            //    new Doctor { Name = "Dr. Linda Miller", Specialization = "Ophthalmology", Salary = 13500m },
            //    new Doctor { Name = "Dr. William Taylor", Specialization = "General Surgery", Salary = 19000m },
            //    new Doctor { Name = "Dr. Elizabeth Moore", Specialization = "Psychiatry", Salary = 11000m },
            //    new Doctor { Name = "Dr. David Anderson", Specialization = "Radiology", Salary = 17500m },
            //    new Doctor { Name = "Dr. Barbara Thomas", Specialization = "Oncology", Salary = 21000m },
            //};

            //for (int i = 0; i < 10; i++)
            //    await doctorService.AddDoctorAsync(newdoctors[i]);

            #endregion

            #region Add List Of Patients

            //List<Patient> patients = new List<Patient>
            //{
            //    new Patient { Name = "John Doe", Age = 35, Phone = "01012345678" },
            //    new Patient { Name = "Alice Smith", Age = 28, Phone = "01123456789" },
            //    new Patient { Name = "Michael Brown", Age = 45, Phone = "01234567890" },
            //    new Patient { Name = "Emma Wilson", Age = 22, Phone = "01545678901" },
            //    new Patient { Name = "Robert Taylor", Age = 60, Phone = "01098765432" },
            //    new Patient { Name = "Sophia Garcia", Age = 31, Phone = "01187654321" },
            //    new Patient { Name = "William Miller", Age = 52, Phone = "01276543210" },
            //    new Patient { Name = "Olivia Davis", Age = 19, Phone = "01565432109" },
            //    new Patient { Name = "David Martinez", Age = 40, Phone = "01011223344" },
            //    new Patient { Name = "Isabella Clark", Age = 27, Phone = "01122334455" }
            //};
            //for (int i = 0; i < 10; i++)
            //    await patientService.AddPatientAsync(patients[i]);

            #endregion

            #region Add List Of Appointments

            //List<Appointment> appointments = new List<Appointment>
            //{
            //    new Appointment { Date = DateTime.Now.AddDays(1), Status = AppointmentStatus.Pending, DoctorId = 1, PatientId = 1 },
            //    new Appointment { Date = DateTime.Now.AddDays(2), Status = AppointmentStatus.Confirmed, DoctorId = 2, PatientId = 2 },
            //    new Appointment { Date = DateTime.Now.AddDays(3), Status = AppointmentStatus.Pending, DoctorId = 3, PatientId = 3 },
            //    new Appointment { Date = DateTime.Now.AddDays(4), Status = AppointmentStatus.Cancelled, DoctorId = 4, PatientId = 4 },
            //    new Appointment { Date = DateTime.Now.AddDays(5), Status = AppointmentStatus.Pending, DoctorId = 5, PatientId = 5 },
            //    new Appointment { Date = DateTime.Now.AddDays(6), Status = AppointmentStatus.Confirmed, DoctorId = 6, PatientId = 6 },
            //    new Appointment { Date = DateTime.Now.AddDays(7), Status = AppointmentStatus.Pending, DoctorId = 7, PatientId = 7 },
            //    new Appointment { Date = DateTime.Now.AddDays(8), Status = AppointmentStatus.Confirmed, DoctorId = 8, PatientId = 8 },
            //    new Appointment { Date = DateTime.Now.AddDays(9), Status = AppointmentStatus.Cancelled, DoctorId = 9, PatientId = 9 },
            //    new Appointment { Date = DateTime.Now.AddDays(10), Status = AppointmentStatus.Completed, DoctorId = 10, PatientId = 10 }
            //};

            //for (int i = 0; i < 10; i++)
            //    await appointmentService.AddAppointmentAsync(appointments[i]);

            #endregion

            #region Add List Of Presceiption

            //List<Prescription> prescriptions = new List<Prescription>
            //{
            //    new Prescription { MedicineName = "Amoxicillin", Dosage = "500mg - 3 times a day", AppointmentId = 1 },
            //    new Prescription { MedicineName = "Ibuprofen", Dosage = "400mg - every 8 hours as needed", AppointmentId = 2 },
            //    new Prescription { MedicineName = "Lisinopril", Dosage = "10mg - once daily in the morning", AppointmentId = 3 },
            //    new Prescription { MedicineName = "Metformin", Dosage = "850mg - twice daily with meals", AppointmentId = 4 },
            //    new Prescription { MedicineName = "Atorvastatin", Dosage = "20mg - once daily at bedtime", AppointmentId = 5 },
            //    new Prescription { MedicineName = "Omeprazole", Dosage = "20mg - 30 minutes before breakfast", AppointmentId = 6 },
            //    new Prescription { MedicineName = "Salbutamol Inhaler", Dosage = "2 puffs - every 4 to 6 hours", AppointmentId = 7 },
            //    new Prescription { MedicineName = "Levothyroxine", Dosage = "50mcg - once daily on empty stomach", AppointmentId = 8 },
            //    new Prescription { MedicineName = "Amlodipine", Dosage = "5mg - once daily", AppointmentId = 9 },
            //    new Prescription { MedicineName = "Paracetamol", Dosage = "1g - every 6 hours for pain", AppointmentId = 10 }
            //};

            //await appDbContext.Prescriptions.AddRangeAsync(prescriptions);
            //await appDbContext.SaveChangesAsync();
            //Console.WriteLine("All prescriptions have been added successfully!");
            #endregion

            #endregion

            #region LINQ Queries

            #region Get all appointments with doctor and patient information using Include().

            //var appointments = await appDbContext.Appointments
            //                                     .AsNoTrackingWithIdentityResolution()
            //                                     .Include(Ap => Ap.Doctor)
            //                                     .Include(Ap => Ap.Patient)
            //                                     .ToListAsync();
            //foreach (var appointment in appointments)
            //{
            //    Console.WriteLine($"[Appointment ID: {appointment.Id}]");
            //    Console.WriteLine($"Date:            {appointment.Date}");
            //    Console.WriteLine($"Status:          {appointment.Status}");
            //    Console.WriteLine($"Doctor:          {appointment.Doctor.Name}");
            //    Console.WriteLine($"Patient:         {appointment.Patient.Name}");
            //    Console.WriteLine("==================================================");
            //}

            #endregion

            #region Get doctors ordered by salary descending.

            //var doctors = await appDbContext.Doctors
            //                          .AsNoTrackingWithIdentityResolution()
            //                          .OrderByDescending(d => d.Salary)
            //                          .ToListAsync();
            //foreach (var doctor in doctors)
            //    Console.WriteLine($"{doctor.Name,-25} | {doctor.Specialization,-20} | {doctor.Salary,10:C}");

            #endregion

            #region Get patients older than 30 years.

            //var patients = await appDbContext.Patients
            //                                 .AsNoTrackingWithIdentityResolution()
            //                                 .Where(p => p.Age > 30)
            //                                 .ToListAsync();

            //Console.WriteLine($"\n{"Patient Name",-25} | {"Age",-5} | {"Phone",-15}");
            //Console.WriteLine(new string('-', 50));
            //foreach (var patient in patients)
            //{
            //    Console.WriteLine($"{patient.Name,-25} | {patient.Age,-5} | {patient.Phone,-15}");
            //}

            //Console.WriteLine($"\nTotal Patients found: {patients.Count}");

            #endregion

            #region Get number of appointments for each doctor using GroupBy().

            //var doctorAppointmentNumbers = appDbContext.Appointments.GroupBy(Ap => Ap.Doctor.Id)
            //                                                        .Select(group => new { DoctorId = group.Key , Total = group.Count() });
            //foreach (var d in doctorAppointmentNumbers)
            //{
            //    Console.WriteLine($"{d.DoctorId}: {d.Total}");
            //}

            #endregion

            #region Get doctor with highest number of appointments.

            //var topdoctor = appDbContext.Appointments.GroupBy(Ap => Ap.Doctor.Id)
            //                                                        .Select(group => new { DoctorId = group.Key, Total = group.Count() })
            //                                                        .OrderByDescending(k=>k.Total)
            //                                                        .FirstOrDefault();
            //if(topdoctor != null)
            //    Console.WriteLine($"{topdoctor.DoctorId}: {topdoctor.Total}");
            //else Console.WriteLine("No Doctor Found:");

            #endregion

            #endregion

        }
    }
}
