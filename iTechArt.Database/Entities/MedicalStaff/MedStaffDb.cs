using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Database.Entities.MedicalStaff
{
    public sealed class MedStaffDb
    {
        /// <summary>
        /// gets && sets Unical Id of a Doctor
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// gets && sets Firstname of a Doctor
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; set; }

        /// <summary>
        /// gets && sets Lastname of a Doctor
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; set; }

        /// <summary>
        /// gets && sets Gender of a Doctor
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// gets && sets Email address of a Doctor
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// gets && sets Phone number of a Doctor
        /// string
        /// </summary>
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// gets && sets Date of birth of a Doctor
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// gets && sets Address of a Doctor
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// gets && sets Monthly salary of a Doctor
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// gets && sets Name of a hospital where the Doctor works
        /// </summary>
        [MaxLength(32)]
        public string HospitalName { get; set; }

        /// <summary>
        /// gets && sets Postal code of a city where the Doctor works
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; set; }

        /// <summary>
        /// gets && sets Work shift of a Doctor
        /// </summary>
        public Shift Shift { get; set; }
    }
}
