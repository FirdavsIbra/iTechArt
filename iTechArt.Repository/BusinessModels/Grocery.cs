using iTechArt.Database.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Grocery : IGrocery
    {
        /// <summary>
        /// Id of grocery
        /// </summary>
        public long Id { get;internal set; }
        /// <summary>
        /// First name of grocery employee
        /// </summary>
        public string FirstName { get; internal set; }
        /// <summary>
        /// Last name of grocery employee
        /// </summary>
        public string LastName { get; internal set; }
        /// <summary>
        /// Date of birth of grocery employee
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }
        /// <summary>
        /// Gender of grocery employee
        /// </summary>
        public Gender Gender { get; internal set; }
        /// <summary>
        /// Email of grocery employee
        /// </summary>
        public string Email { get; internal set; }
        /// <summary>
        /// Jop position of grocery employee
        /// </summary>
        public string JobTitle { get; internal set; }
        /// <summary>
        /// Which department employee works
        /// </summary>
        public string DepartmentRetail { get; internal set; }
        /// <summary>
        /// Salary of grocery employee
        /// </summary>
        public double Salary { get; internal set; }
    }
}
