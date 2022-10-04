using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.Airports
{
    public class Airplane : Auditable
    {
        public string Name { get; set; }
        public short NumberOfSeats { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
