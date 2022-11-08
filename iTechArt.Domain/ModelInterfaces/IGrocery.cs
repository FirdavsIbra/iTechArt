using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IGrocery
    {
        /// <summary>
        /// Id of grocery store
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// First name of grocery employee
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Last name of grocery employee
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Date of birth of grocery employee
        /// </summary>
        public DateTime Birthday { get; }

        /// <summary>
        /// Gender of grocery employee
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Email of grocery employee
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Jop position of grocery employee
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Which department employee works
        /// </summary>
        public string DepartmentRetail { get; }

        /// <summary>
        /// Salary of grocery employee
        /// </summary>
        public double Salary { get; }
    }
}
