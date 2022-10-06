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
        public int City_Id { get; set; }

        public string City_Name { get; set; }

        public int Country_Id { get; set; }
    }
}
