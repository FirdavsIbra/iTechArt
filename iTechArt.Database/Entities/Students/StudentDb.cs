using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Database.Entities.Students
{
    public sealed class StudentDb
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets first name of student.
        /// </summary>
        [MaxLength(64)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of student.
        /// </summary>
        [MaxLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets email of student.
        /// </summary>
        [MaxLength(128)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or set password of student.
        /// </summary>
        [MaxLength(128)]
        public string Password { get; set; }

        /// <summary>
        /// Get or set major of student study.
        /// </summary>
        
        [MaxLength(128)]
        public string Majority { get; set; }

        /// <summary>
        /// Gets or sets gender of student.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets birthday of student
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets university of student.
        /// </summary>
        [MaxLength(128)]
        public string University { get; set; }
    }
}
