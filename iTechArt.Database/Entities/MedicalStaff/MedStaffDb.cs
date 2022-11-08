using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Database.Entities.MedicalStaff
{
    public sealed class MedStaffDb
    {
        /// <summary>
        /// gets && sets Unical Id of a medStaff
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// gets && sets Firstname of a medStaff
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; set; }

        /// <summary>
        /// gets && sets Lastname of a medStaff
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; set; }

        /// <summary>
        /// gets && sets Gender of a medStaff
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// gets && sets Email address of a medStaff
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// gets && sets Phone number of a medStaff
        /// string
        /// </summary>
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// gets && sets Date of birth of a medStaff
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// gets && sets Address of a medStaff
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// gets && sets Monthly salary of a medStaff
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// gets && sets Name of a hospital where the medStaff works
        /// </summary>
        [MaxLength(32)]
        public string HospitalName { get; set; }

        /// <summary>
        /// gets && sets Postal code of a city where the medStaff works
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; set; }

        /// <summary>
        /// gets && sets Work shift of a medStaff
        /// </summary>
        public Shift Shift { get; set; }
    }
}
