using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class MedStaff : IMedStaff
    {
        /// <summary>
        /// Gets && internal sets Unical Id of a medStaff.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets && internal sets Firstname of a medStaff.
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets && internal sets Lastname of a medStaff.
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets && internal sets Gender of a medStaff.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets && internal sets Email address of a medStaff.
        /// </summary>
        [MaxLength(32)]
        public string Email { get; internal set; }

        /// <summary>
        /// Gets && internal sets Phone number of a medStaff.
        /// string.
        /// </summary>
        [MaxLength(16)]
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Gets && internal sets Date of birth of a medStaff.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets && internal sets Address of a medStaff.
        /// </summary>
        [MaxLength(24)]
        public string Address { get; internal set; }

        /// <summary>
        /// Gets && internal sets Monthly salary of a medStaff.
        /// </summary>
        public decimal Salary { get; internal set; }

        /// <summary>
        /// Gets && internal sets Name of a hospital where the medStaff works.
        /// </summary>
        [MaxLength(24)]
        public string HospitalName { get; internal set; }

        /// <summary>
        /// Gets && internal sets Postal code of a city where the medStaff works.
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; internal set; }

        /// <summary>
        /// Gets && internal sets Work shift of a medStaff.
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
