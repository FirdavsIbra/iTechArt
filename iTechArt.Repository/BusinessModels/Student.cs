using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Student : IStudent
    {
        /// <summary>
        /// Id of business model entities
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// First name of student
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Last name of student
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Email of student
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Password of student
        /// </summary>
        public string Password { get; internal set; }

        /// <summary>
        /// String value majority, field of study
        /// </summary>
        public string Majority { get; internal set; }

        /// <summary>
        /// Gender entity of student
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Birthday of student
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Name of university of student
        /// </summary>
        public string University { get; internal set; }
    }
}
