using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Police
{
    public class PhsyicalDescription
    {
        [Key]
        [Required]
        public int PhyscId { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public int Age { get; set; }

        public string Etnithity { get; set; }

        public string Gender { get; set; }
    }
}
