using iTechArt.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class StaffHospitalContraction : Auditable
    {
        public long StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }

        public long HospitalId { get; set; }
        [ForeignKey(nameof(HospitalId))]
        public Hospital Hospital { get; set; }

        public decimal Salary { get; set; }
    }
}
