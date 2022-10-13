using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Police
{
    public class Officer
    {
        [Key]
        [Required]
        public int OfficerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhysDesc { get; set; }

        public int DeptId { get; set; }

        public int JobId { get; set; }

        public double Salary { get; set; }
    }
}
