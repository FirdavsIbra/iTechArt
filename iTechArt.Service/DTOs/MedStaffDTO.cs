using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Service.Parsers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Service.DTOs
{
    internal sealed class MedStaffDTO : IMedStaff
    {
        /// <summary>
        /// gets && internal sets Unical Id of a medStaff
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// gets && internal sets Firstname of a medStaff
        /// </summary>
        [MaxLength(24)]
        public string FirstName { get; internal set; }

        /// <summary>
        /// gets && internal sets Lastname of a medStaff
        /// </summary>
        [MaxLength(24)]
        public string LastName { get; internal set; }

        /// <summary>
        /// gets && internal sets Gender of a medStaff
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// gets && internal sets Email address of a medStaff
        /// </summary>
        [MaxLength(32)]
        public string Email { get; internal set; }

        /// <summary>
        /// gets && internal sets Phone number of a medStaff
        /// string
        /// </summary>
        [MaxLength(16)]
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// gets && internal sets Date of birth of a medStaff
        /// </summary>
        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateOnly DateOfBirth { get; internal set; }

        /// <summary>
        /// gets && internal sets Address of a medStaff
        /// </summary>
        [MaxLength(24)]
        public string Address { get; internal set; }

        /// <summary>
        /// gets && internal sets Monthly salary of a medStaff
        /// </summary>
        public decimal Salary { get; internal set; }

        /// <summary>
        /// gets && internal sets Name of a hospital where the medStaff works
        /// </summary>
        [MaxLength(24)]
        public string HospitalName { get; internal set; }

        /// <summary>
        /// gets && internal sets Postal code of a city where the medStaff works
        /// </summary>
        [MaxLength(16)]
        public string PostalCode { get; internal set; }

        /// <summary>
        /// gets && internal sets Work shift of a medStaff
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
