using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Database.Entities.Groceries
{
    public sealed class GroceryDb
    {
        /// <summary>
        /// get or sets ID of grocery employee
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// get or sets Fist Name of grocery employee
        /// </summary>
        [MaxLength(32)]
        [Column("first_Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// get or sets Surname of grocery employee
        /// </summary>
        [MaxLength(32)]
        [Column("last_Name")]
        public string LastName { get; set; }

        /// <summary>
        /// get or sets Birthdate of grocery employee
        /// </summary>
        [Column("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// get or sets Gender of grocery employee
        /// </summary>
        [Column("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// get or sets Email of grocery employee
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// get or sets Job position of grocery employee
        /// </summary>
        [Column("job_title")]
        public string Jobtitle { get; set; }

        /// <summary>
        /// get or sets Current department of grocery employee
        /// </summary>
        [Column("department_retail")]
        public string Departmentretail { get; set; }

        /// <summary>
        /// get or sets Salary of each grocery employee
        /// </summary>
        [Column("salary")]
        public double Salary { get; set; }
    }
}
