using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Department
    {
        [Key]
        [Required]
        public int Department_Id { get; set; }

        public string Dept_Name { get; set; }

        public int Hospital_ID { get; set; }
    }
}
