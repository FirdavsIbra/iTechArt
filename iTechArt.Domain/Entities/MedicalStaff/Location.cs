using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Location : Auditable
    {
        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string PostalCode { get; set; }
    }
}
