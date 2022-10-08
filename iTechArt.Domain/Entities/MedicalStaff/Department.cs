using iTechArt.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Department : Auditable
    {
        public string DeptName { get; set; }

        public long HospitalId { get; set; }
    }
}
