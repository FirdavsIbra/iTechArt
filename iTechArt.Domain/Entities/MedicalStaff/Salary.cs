using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.MedicalStaff
{
    public class Salary
    {
        [Key]
        [Required]
        public int Salary_Id { get; set; }

        public double Amount { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
