using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.Entities.Grocery
{
    public sealed class Grocery:Auditable
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Fist Name of grocery employee
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Surname of grocery employee
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Birthdate of grocery employee
        /// </summary>
        public DateTime birthday { get; set; }

        /// <summary>
        /// Gender of grocery employee
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Email of grocery employee
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Job position of grocery employee
        /// </summary>
        public string job_title { get; set; }

        /// <summary>
        /// Current department of grocery employee
        /// </summary>
        public string department_retail { get; set; }

        /// <summary>
        /// Salary of each grocery employee
        /// </summary>
        public double Salary { get; set; }
    }
}
