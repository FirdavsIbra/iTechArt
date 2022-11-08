using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Grocery : IGrocery
    {
        /// <summary>
        /// gets or internal sets Id of grocery
        /// </summary>
        public long Id { get;internal set; }
        /// <summary>
        /// gets or internal sets First name of grocery employee
        /// </summary>
        public string FirstName { get; internal set; }
        /// <summary>
        /// gets or internal sets Last name of grocery employee
        /// </summary>
        public string LastName { get; internal set; }
        /// <summary>
        /// gets or internal sets Date of birth of grocery employee
        /// </summary>
        public DateTime Birthday { get; internal set; }
        /// <summary>
        /// gets or internal sets Gender of grocery employee
        /// </summary>
        public Gender Gender { get; internal set; }
        /// <summary>
        /// gets or internal sets Email of grocery employee
        /// </summary>
        public string Email { get; internal set; }
        /// <summary>
        /// gets or internal sets Jop position of grocery employee
        /// </summary>
        public string JobTitle { get; internal set; }
        /// <summary>
        /// gets or internal sets Which department employee works
        /// </summary>
        public string DepartmentRetail { get; internal set; }
        /// <summary>
        /// gets or internal sets Salary of grocery employee
        /// </summary>
        public double Salary { get; internal set; }
    }
}
