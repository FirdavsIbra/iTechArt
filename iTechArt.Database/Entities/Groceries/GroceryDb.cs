using iTechArt.Database.DbContexts;
using iTechArt.Database.Enums;

namespace iTechArt.Database.Entities.Groceries
{
    public sealed class GroceryDb
    {
        /// <summary>
        /// get or sets ID of grocery employee
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// get or sets Fist Name of grocery employee
        /// </summary>
        [MaxLength(32)]
        public string first_Name { get; set; }

        /// <summary>
        /// get or sets Surname of grocery employee
        /// </summary>
        [MaxLength(32)]
        public string last_Name { get; set; }

        /// <summary>
        /// get or sets Birthdate of grocery employee
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime birthday { get; set; }

        /// <summary>
        /// get or sets Gender of grocery employee
        /// </summary>
        public Gender gender { get; set; }

        /// <summary>
        /// get or sets Email of grocery employee
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        /// <summary>
        /// get or sets Job position of grocery employee
        /// </summary>
        public string job_title { get; set; }

        /// <summary>
        /// get or sets Current department of grocery employee
        /// </summary>
        public string department_retail { get; set; }

        /// <summary>
        /// get or sets Salary of each grocery employee
        /// </summary>
        public double salary { get; set; }
    }
}
