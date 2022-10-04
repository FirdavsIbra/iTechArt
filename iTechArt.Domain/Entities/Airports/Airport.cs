using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public class Airport : Auditable
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }
    }
}
