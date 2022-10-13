using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Police
{
    public class Building
    {
        [Key]
        [Required]
        public int BuildingId { get; set; }

        public string BuildingName { get; set; }

        public int LocationId { get; set; }
    }
}
