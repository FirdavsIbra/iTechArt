namespace iTechArt.Domain.Entities.Airports
{
    public class Airport
    {
        public ulong Id { get; set; }
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
