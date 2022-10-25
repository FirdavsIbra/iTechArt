using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IDoctor
    {
        /// <summary>
        /// Id of a doctor
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Firstname of a doctor
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Lastname of a doctor
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gender of a doctor
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Email of a doctor
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Phonenumber of a doctor
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Date of birth of a doctor
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// Address of a doctor
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Current salay of a doctor
        /// </summary>
        public decimal Salary { get; }

        /// <summary>
        /// Hospital name where the doctor works
        /// </summary>
        public string HospitalName { get; }

        /// <summary>
        /// Postal code of the city where doctor lives
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// Shift of a doctor [day/night]
        /// </summary>
        public Shift Shift { get; }
    }
}
