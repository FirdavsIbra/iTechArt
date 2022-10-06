using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Location
    {
        [Key]
        [Required]
        public int LocationId { get; set; }

        public string Street_Address { get; set; }

        public string Postal_Code { get; set; }

        public int CityId { get; set; }
    }
}
