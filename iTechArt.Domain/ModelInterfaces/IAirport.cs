namespace iTechArt.Domain.ModelInterfaces
{
    public interface IAirport
    {
        /// <summary>
        /// Id of airport
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// Airport Name
        /// </summary>
        public string AirportName { get; }
        /// <summary>
        /// The built date of airport
        /// </summary>
        public DateTime BuiltDate { get; }
        /// <summary>
        /// A number of people can be in at the same time at the airport
        /// </summary>
        public short Capacity { get; }
        /// <summary>
        ///  Address location of the airport
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// City location of the airport
        /// </summary>
        public string City { get; }
        /// <summary>
        /// A number of employees
        /// </summary>
        public short EmpoyeesCount { get; }
        /// <summary>
        /// The number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; }
        /// <summary>
        /// The number of flights from a particular airport in a year
        /// </summary>
        public int FlightsPerYear { get; }
        /// <summary>
        /// The average price of tickets
        /// </summary>
        public short AverageTicketPrice { get; }
    }
}
