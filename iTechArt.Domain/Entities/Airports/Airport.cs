using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public abstract class Airport : Auditable
    {
        public string AirportName { get; set; }
        public DateTime BuiltDate { get; set; }
        public ushort Capacity { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ushort EmpoyeesCount { get; set; }
        public long PassengersPerYear { get; set; }
        public uint FlightsPerYear { get; set; }
        public ushort AverageTicketPrice { get; set; }
    }
}
