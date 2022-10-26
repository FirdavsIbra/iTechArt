namespace iTechArt.Database.Entities.Airports
{
    public sealed class AirportDb
    {
        /// <summary>
        /// Id of airport
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Airport Name
        /// </summary>
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
        public string Address { get; set; }

        /// <summary>
        /// City location of the airport
        /// </summary>
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
