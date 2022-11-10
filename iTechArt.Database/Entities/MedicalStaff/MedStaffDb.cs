using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Database.Entities.MedicalStaff
{
    public sealed class MedStaffDb
    {
        /// <summary>
        /// Gets && sets Unical Id of a medStaff.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets && sets Firstname of a medStaff.
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets && sets Lastname of a medStaff.
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets && sets Gender of a medStaff.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets && sets Email address of a medStaff.
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// Gets && sets Phone number of a medStaff.
        /// </summary>
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets && sets Date of birth of a medStaff.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets && sets Address of a medStaff.
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// Gets && sets Monthly salary of a medStaff.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets && sets Name of a hospital where the medStaff works.
        /// </summary>
        [MaxLength(32)]
        public string HospitalName { get; set; }

        /// <summary>
        /// Gets && sets Postal code of a city where the medStaff works.
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets && sets Work shift of a medStaff.
        /// </summary>
        public Shift Shift { get; set; }
    }
}
