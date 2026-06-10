using Microsoft.IdentityModel.Tokens;
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
        public string Name { get; private set; } = null!;
        public string Specialization { get; private set; } = null!;
        public decimal Salary { get; private set; }
        public bool IsDeleted { get; private set; } 
        public ICollection<Appointment> Appointments { get; private set; } = new HashSet<Appointment>();
        public Doctor(string name,string specialization,decimal salary)
        {
            if (string.IsNullOrWhiteSpace(name)) 
               throw new ArgumentException("الاسم فارغ اعد المحاولة");
            if (name.Length < 3) throw new ArgumentException("الاسم لا يقل عن ثلاثة أحرف");
            Name = name;

            if (string.IsNullOrWhiteSpace(specialization))
                throw new ArgumentException("التخصص فارغ اعد المحاولة");
            if (specialization.Length < 10) throw new ArgumentException("التخصص لا يقل عن ثلاثة أحرف");
            Specialization = specialization;

            if (salary > 1000 || salary < 20000)
                throw new ArgumentOutOfRangeException("الراتب بين ألف إلى عشرين ألف");
            Salary = salary;

            IsDeleted = false;

        }
        public void IsDeletedMethod() => IsDeleted = true;

    }
}
