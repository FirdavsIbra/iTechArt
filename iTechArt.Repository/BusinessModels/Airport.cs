using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Airport : IAirport
    {
        /// <summary>
        /// Id of airport
        /// </summary>
        public long Id { get; internal set; }
        /// <summary>
        /// Airport Name
        /// </summary>
        public string AirportName { get; internal set; }
        /// <summary>
        /// The built date of airport
        /// </summary>
        public DateTime BuiltDate { get; internal set; }
        /// <summary>
        /// A number of people can be in at the same time at the airport
        /// </summary>
        public short Capacity { get; internal set; }
        /// <summary>
        ///  Address location of the airport
        /// </summary>
        public string Address { get; internal set; }
        /// <summary>
        /// City location of the airport
        /// </summary>
        public string City { get; internal set; }
        /// <summary>
        /// A number of employees
        /// </summary>
        public short EmpoyeesCount { get; internal set; }
        /// <summary>
        /// The number of passengers who fly from a particular airport
        /// </summary>
        public long PassengersPerYear { get; internal set; }
        /// <summary>
        /// The number of flights from a particular airport in a year
        /// </summary>
        public int FlightsPerYear { get; internal set; }
        /// <summary>
        /// The average price of tickets
        /// </summary>
        public short AverageTicketPrice { get; internal set; }
    }
}
