using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public class Address : Auditable
    {
        public string Name { get; set; }
        public string Addressline { get; set; }
    }
}
