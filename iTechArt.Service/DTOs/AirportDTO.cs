using System.ComponentModel.DataAnnotations;

namespace iTechArt.Service.DTOs
{
    internal sealed class AirportDTO
    {
        /// <summary>
        /// Airport Name
        /// </summary>
        [MaxLength(16)]
        public string AirportName { get; set; }

        /// <summary>
        /// The built date of airport
        /// </summary>
        public DateTime BuiltDate { get; set; }

        /// <summary>
        /// A number of people can be in at the same time at the airport
        /// </summary>
        public ushort Capacity { get; set; }

        /// <summary>
        ///  Address location of the airport
        /// </summary>
        [MaxLength(16)]
        public string Address { get; set; }

        /// <summary>
        /// City location of the airport
        /// </summary>
        [MaxLength(16)]
        public string City { get; set; }

        /// <summary>
        /// A number of employees
        /// </summary>
        public ushort EmpoyeesCount { get; set; }

        /// <summary>
        /// The number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; set; }

        /// <summary>
        /// The number of flights from a particular airport in a year
        /// </summary>
        public uint FlightsPerYear { get; set; }

        /// <summary>
        /// The average price of tickets
        /// </summary>
        public ushort AverageTicketPrice { get; set; }
    }
}
