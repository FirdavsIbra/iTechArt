using iTechArt.Database.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Doctor : IDoctor
    {
        public long Id { get; set; }

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
