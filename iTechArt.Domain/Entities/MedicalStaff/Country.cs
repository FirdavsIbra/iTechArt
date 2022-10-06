using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Country
    {
        [Key]
        [Required]
        public int Country_Id { get; set; }

        public string Country_Name { get; set; }
    }
}
