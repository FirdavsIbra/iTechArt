using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Police
{
    public class Department
    {
        [Key]
        [Required]
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public int BuildingId { get; set; }
    }
}
