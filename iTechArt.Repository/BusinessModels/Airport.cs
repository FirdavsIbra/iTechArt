using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Airport : IAirport
    {
        public long Id { get; set; }

        public string AirportName { get; set; }

        public DateTime BuiltDate { get; set; }

        public short Capacity { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public short EmpoyeesCount { get; set; }

        public long PassengersPerYear { get; set; }

        public int FlightsPerYear { get; set; }

        public short AverageTicketPrice { get; set; }
    }
}
