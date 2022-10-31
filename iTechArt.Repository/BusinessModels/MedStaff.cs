using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class MedStaff : IMedStaff
    {
        /// <summary>
        /// gets && internal sets Unical Id of a Doctor
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// gets && internal sets Firstname of a Doctor
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; internal set; }

        /// <summary>
        /// gets && internal sets Lastname of a Doctor
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; internal set; }

        /// <summary>
        /// gets && internal sets Gender of a Doctor
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// gets && internal sets Email address of a Doctor
        /// </summary>
        [MaxLength(32)]
        public string Email { get; internal set; }

        /// <summary>
        /// gets && internal sets Phone number of a Doctor
        /// string
        /// </summary>
        [MaxLength(16)]
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// gets && internal sets Date of birth of a Doctor
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// gets && internal sets Address of a Doctor
        /// </summary>
        [MaxLength(24)]
        public string Address { get; internal set; }

        /// <summary>
        /// gets && internal sets Monthly salary of a Doctor
        /// </summary>
        public decimal Salary { get; internal set; }

        /// <summary>
        /// gets && internal sets Name of a hospital where the Doctor works
        /// </summary>
        [MaxLength(24)]
        public string HospitalName { get; internal set; }

        /// <summary>
        /// gets && internal sets Postal code of a city where the Doctor works
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; internal set; }

        /// <summary>
        /// gets && internal sets Work shift of a Doctor
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
