namespace iTechArt.Domain.ModelInterfaces
{
    public interface IAirport
    {
        public long Id { get; }

        public string AirportName { get; }

        public DateTime BuiltDate { get; }

        public short Capacity { get; }

        public string Address { get; }

        public string City { get; }

        public short EmpoyeesCount { get; }

        public long PassengersPerYear { get; }

        public int FlightsPerYear { get; }

        public short AverageTicketPrice { get; }
    }
}
