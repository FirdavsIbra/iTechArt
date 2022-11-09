using iTechArt.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Database.Entities.Airports
{
    public sealed class AirportDb
    {
        /// <summary>
        /// gets or sets Id of airport
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// gets or sets Airport Name
        /// </summary>
        [MaxLength(32)]
        public string AirportName { get; set; }

        /// <summary>
        /// gets or sets The built date of airport
        /// </summary>

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BuiltDate { get; set; }

        /// <summary>
        /// gets or sets A number of people can be in at the same time at the airport
        /// </summary>
        public ushort Capacity { get; set; }

        /// <summary>
        /// gets or sets Address location of the airport
        /// </summary>
        [MaxLength(64)]
        public string Address { get; set; }

        /// <summary>
        /// gets or sets City location of the airport
        /// </summary>
        [MaxLength(64)]
        public string City { get; set; }

        /// <summary>
        /// gets or sets A number of employees
        /// </summary>
        public ushort EmpoyeesCount { get; set; }

        /// <summary>
        /// gets or sets The number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; set; }

        /// <summary>
        /// gets or sets The number of flights from a particular airport in a year
        /// </summary>
        public uint FlightsPerYear { get; set; }

        /// <summary>
        /// gets or sets The average price of tickets
        /// </summary>
        public ushort AverageTicketPrice { get; set; }
    }
}
