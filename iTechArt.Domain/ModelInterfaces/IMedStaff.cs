using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.Text.Json.Serialization;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IMedStaff
    {
        /// <summary>
        /// Gets Id of a medStaff.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets Firstname of a medStaff.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets Lastname of a medStaff.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets Gender of a medStaff.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets Email of a medStaff.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets Phonenumber of a medStaff.
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Gets Date of birth of a medStaff.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; }

        /// <summary>
        /// Gets Address of a medStaff.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets Current salay of a medStaff.
        /// </summary>
        public decimal Salary { get; }

        /// <summary>
        /// Gets Hospital name where the medStaff works.
        /// </summary>
        public string HospitalName { get; }

        /// <summary>
        /// Gets Postal code of the city where medStaff lives.
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// Gets Shift of a medStaff [day/night].
        /// </summary>
        public Shift Shift { get; }
    }
}
