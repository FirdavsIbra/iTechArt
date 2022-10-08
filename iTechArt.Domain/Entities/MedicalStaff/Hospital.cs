using iTechArt.Domain.Entities.Commons;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Hospital : Auditable
    {
        public string HospitalName { get; set; }

        public long LocationId { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}