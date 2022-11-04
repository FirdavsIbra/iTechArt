namespace iTechArt.Domain.ModelInterfaces
{
    public interface IAirport
    {
        /// <summary>
        /// Gets id of airport
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets airport Name
        /// </summary>
        public string AirportName { get; }

        /// <summary>
        /// Gets the built date of airport
        /// </summary>
        public DateTime BuiltDate { get; }

        /// <summary>
        /// Gets a number of people can be in at the same time at the airport
        /// </summary>
        public ushort Capacity { get; }

        /// <summary>
        ///  Gets address location of the airport
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets city location of the airport
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets a number of employees
        /// </summary>
        public ushort EmployeesCount { get; }

        /// <summary>
        /// Gets the number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; }

        /// <summary>
        /// Gets the number of flights from a particular airport in a year
        /// </summary>
        public uint FlightsPerYear { get; }

        /// <summary>
        /// Gets the average price of tickets
        /// </summary>
        public ushort AverageTicketPrice { get; }
    }
}
