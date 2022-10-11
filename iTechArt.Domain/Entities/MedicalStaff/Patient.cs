using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Patient : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Location Address { get; set; }
    }
}
