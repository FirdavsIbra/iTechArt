using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class City
    {
        [Key]
        [Required]
        public int CityId { get; set; }

        public string CityName { get; set; }
    }
}
