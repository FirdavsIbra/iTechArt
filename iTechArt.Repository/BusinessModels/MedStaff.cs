using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class MedStaff : IMedStaff
    {
        /// <summary>
        /// Unical Id of a Doctor
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Firstname of a Doctor
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Lastname of a Doctor
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Gender of a Doctor
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Email address of a Doctor
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Phone number of a Doctor
        /// string
        /// </summary>
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Date of birth of a Doctor
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Address of a Doctor
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Monthly salary of a Doctor
        /// </summary>
        public decimal Salary { get; internal set; }

        /// <summary>
        /// Name of a hospital where the Doctor works
        /// </summary>
        public string HospitalName { get; internal set; }

        /// <summary>
        /// Postal code of a city where the Doctor works
        /// </summary>
        public string PostalCode { get; internal set; }

        /// <summary>
        /// Work shift of a Doctor
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
