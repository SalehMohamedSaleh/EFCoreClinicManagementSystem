using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Entities
{
    //Doctor: Id, Name, Specialization, Salary
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; } 
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
