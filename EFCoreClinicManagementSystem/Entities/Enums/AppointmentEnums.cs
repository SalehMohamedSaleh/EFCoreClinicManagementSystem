using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreClinicManagementSystem.Entities.Enums
{
    public enum AppointmentStatus
    {
        Pending = 1,   // قيد الانتظار
        Confirmed = 2, // مؤكد
        Cancelled = 3, // ملغي
        Completed = 4  // مكتمل
    }
}
