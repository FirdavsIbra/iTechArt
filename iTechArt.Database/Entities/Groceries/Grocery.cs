using iTechArt.Database.DbContexts;
using iTechArt.Database.Enums;

namespace iTechArt.Database.Entities.Groceries
{
    public sealed class Grocery : IDbModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Fist Name of grocery employee
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of grocery employee
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birthdate of grocery employee
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gender of grocery employee
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Email of grocery employee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Job position of grocery employee
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Current department of grocery employee
        /// </summary>
        public string DepartmentRetail { get; set; }

        /// <summary>
        /// Salary of each grocery employee
        /// </summary>
        public double Salary { get; set; }
    }
}
