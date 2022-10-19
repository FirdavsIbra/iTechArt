using iTechArt.Database.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IDoctor
    {
        public long Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Gender Gender { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public DateTime DateOfBirth { get; }

        public string Address { get; }

        public decimal Salary { get; }

        public string HospitalName { get; }

        public string PostalCode { get; }

        public Shift Shift { get; }
    }
}
