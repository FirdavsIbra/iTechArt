using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Airport : IAirport
    {
        /// <summary>
        /// gets or internal sets Id of airport
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// gets or internal sets Airport Name
        /// </summary>

        [MaxLength(64)]
        public string AirportName { get; internal set; }

        /// <summary>
        /// gets or internal sets The built date of airport
        /// </summary>

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BuiltDate { get; internal set; }

        /// <summary>
        /// gets or internal sets A number of people can be in at the same time at the airport
        /// </summary>

        public ushort Capacity { get; internal set; }

        /// <summary>
        /// gets or internal sets  Address location of the airport
        /// </summary>

        [MaxLength(64)]
        public string Address { get; internal set; }

        /// <summary>
        /// gets or internal sets City location of the airport
        /// </summary>

        [MaxLength(32)]
        public string City { get; internal set; }

        /// <summary>
        /// gets or internal sets A number of employees
        /// </summary>

        public ushort EmployeesCount { get; internal set; }

        /// <summary>
        /// gets or internal sets The number of passengers who fly from a particular airport
        /// </summary>

        public long PassengersPerYear { get; internal set; }

        /// <summary>
        /// gets or internal sets The number of flights from a particular airport in a year
        /// </summary>

        public uint FlightsPerYear { get; internal set; }

        /// <summary>
        /// gets or internal sets The average price of tickets
        /// </summary>
        public ushort AverageTicketPrice { get; internal set; }
    }
}
