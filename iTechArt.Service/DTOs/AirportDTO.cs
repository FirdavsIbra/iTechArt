﻿using System.ComponentModel.DataAnnotations;

namespace iTechArt.Service.DTOs
{
    internal sealed class AirportDTO
    {
        /// <summary>
        /// Airport Name
        /// </summary>
        [MaxLength(32)]
        public string AirportName { get; internal set; }

        /// <summary>
        /// The built date of airport
        /// </summary>
        public DateTime BuiltDate { get; internal set; }

        /// <summary>
        /// A number of people can be in at the same time at the airport
        /// </summary>
        public ushort Capacity { get; internal set; }

        /// <summary>
        ///  Address location of the airport
        /// </summary>
        [MaxLength(32)]
        public string Address { get; internal set; }

        /// <summary>
        /// City location of the airport
        /// </summary>
        [MaxLength(16)]
        public string City { get; internal set; }

        /// <summary>
        /// A number of employees
        /// </summary>
        public ushort EmpoyeesCount { get; internal set; }

        /// <summary>
        /// The number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; internal set; }

        /// <summary>
        /// The number of flights from a particular airport in a year
        /// </summary>
        public uint FlightsPerYear { get; internal set; }

        /// <summary>
        /// The average price of tickets
        /// </summary>
        public ushort AverageTicketPrice { get; internal set; }
    }
}