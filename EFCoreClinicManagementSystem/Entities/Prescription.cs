using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Entities
{
    //Prescription: Id, MedicineName, Dosage, AppointmentId
    public class Prescription
    {
        public int Id { get; set; }
        public string MedicineName { get; set; } = null!;
        public string Dosage { get; set; } = null!;
        [ForeignKey("AppointmentId")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

    }
}
