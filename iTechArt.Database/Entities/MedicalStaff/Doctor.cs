using iTechArt.Database.DbContexts;
using iTechArt.Database.Enums;

namespace iTechArt.Database.Entities.MedicalStaff
{
    public sealed class Doctor : IDbModel
    {
        /// <summary>
        /// Unical Id of a Doctor
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Firstname of a Doctor
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname of a Doctor
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gender of a Doctor
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Email address of a Doctor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of a Doctor
        /// string
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Date of birth of a Doctor
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Address of a Doctor
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Monthly salary of a Doctor
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Name of a hospital where the Doctor works
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// Postal code of a city where the Doctor works
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Work shift of a Doctor
        /// </summary>
        public Shift Shift { get; set; }
    }
}
