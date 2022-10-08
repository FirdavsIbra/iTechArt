using iTechArt.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Staff : Auditable
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string JobTitle { get; set; }

        public long SalaryId { get; set; }

        public DateTime BirthDate { get; set; }

        public long DepartmentId { get; set; }

        public DateTime HireDate { get; set; }
    }
}
