using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Police
{
    public class Location
    {
        [Key]
        [Required]
        public int LocationId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }
    }
}
