using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public sealed class Doctor : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public decimal Salary { get; set; }

        public string HospitalName { get; set; }

        public string PostalCode { get; set; }

        public Shift Shift { get; set; }
    }
}
