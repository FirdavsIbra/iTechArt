using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data.Dtos.MedStaffDtos
{
    public class StaffDto
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Job_Title { get; set; }

        public int Salary_Id { get; set; }

        public DateOnly BirthDate { get; set; }

        public int Department_Id { get; set; }

        public DateOnly HireDate { get; set; }
    }
}
