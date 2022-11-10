using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.Text.Json.Serialization;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IStudent
    {
        /// <summary>
        /// Gets id of student.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets first name of student.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets last name of student.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets email of student.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets password of student.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets string value majority, field of study.
        /// </summary>
        public string Majority { get; }

        /// <summary>
        /// Gets gender of student.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets birthday of student
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; }

        /// <summary>
        /// Gets name of university of student.
        /// </summary>
        public string University { get; }
    }
}
