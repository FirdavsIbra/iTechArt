using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.Text.Json.Serialization;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IMedStaff
    {
        /// <summary>
        /// gets Id of a medStaff
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// gets Firstname of a medStaff
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// gets Lastname of a medStaff
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// gets Gender of a medStaff
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// gets Email of a medStaff
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// gets Phonenumber of a medStaff
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// gets Date of birth of a medStaff
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; }

        /// <summary>
        /// gets Address of a medStaff
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// gets Current salay of a medStaff
        /// </summary>
        public decimal Salary { get; }

        /// <summary>
        /// gets Hospital name where the medStaff works
        /// </summary>
        public string HospitalName { get; }

        /// <summary>
        /// gets Postal code of the city where medStaff lives
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// gets Shift of a medStaff [day/night]
        /// </summary>
        public Shift Shift { get; }
    }
}
