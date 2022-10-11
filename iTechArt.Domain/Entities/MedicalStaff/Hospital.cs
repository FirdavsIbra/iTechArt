using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Hospital : Auditable
    {
        public string Name { get; set; }

        public long AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Location Address { get; set; }
    }
}
