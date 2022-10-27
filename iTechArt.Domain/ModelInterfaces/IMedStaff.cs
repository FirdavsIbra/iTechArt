using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IMedStaff
    {
        /// <summary>
        /// gets Id of a doctor
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// gets Firstname of a doctor
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// gets Lastname of a doctor
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// gets Gender of a doctor
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// gets Email of a doctor
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// gets Phonenumber of a doctor
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// gets Date of birth of a doctor
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// gets Address of a doctor
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// gets Current salay of a doctor
        /// </summary>
        public decimal Salary { get; }

        /// <summary>
        /// gets Hospital name where the doctor works
        /// </summary>
        public string HospitalName { get; }

        /// <summary>
        /// gets Postal code of the city where doctor lives
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// gets Shift of a doctor [day/night]
        /// </summary>
        public Shift Shift { get; }
    }
}
