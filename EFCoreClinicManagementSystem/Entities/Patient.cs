using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Entities
{
    //Patient: Id, Name, Age, Phone
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        [Phone]
        public string Phone { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
