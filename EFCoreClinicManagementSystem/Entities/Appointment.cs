using EFCoreClinicManagementSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Entities
{
    //Appointment: Id, Date, Status, DoctorId, PatientId
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}
