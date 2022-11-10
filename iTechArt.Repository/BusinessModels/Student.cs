using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.Text.Json.Serialization;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Student : IStudent
    {
        /// <summary>
        /// Gets or sets id of student.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets first name of student.
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets or sets last name of student.
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets or sets email of student.
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Gets or sets password of student.
        /// </summary>
        public string Password { get; internal set; }

        /// <summary>
        /// Gets or sets string value majority, field of study.
        /// </summary>
        public string Majority { get; internal set; }

        /// <summary>
        /// Gets or sets gender of student.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets or sets birth date of student.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets or sets name of university of student.
        /// </summary>
        public string University { get; internal set; }
    }
}
