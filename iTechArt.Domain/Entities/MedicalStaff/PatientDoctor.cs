using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class PatientDoctor : Auditable
    {
        public string Description { get; set; }

        public bool IsCured { get; set; }

        public long PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        public long DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public Staff Staff { get; set; }
    }
}
