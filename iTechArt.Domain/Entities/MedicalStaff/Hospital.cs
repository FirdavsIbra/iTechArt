using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Hospital
    {
        [Key]
        [Required]
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public int LocationId { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}