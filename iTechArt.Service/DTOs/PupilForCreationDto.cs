using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Service.DTOs
{
    public sealed class PupilForCreationDto : IPupil
    {
        /// <summary>
        /// Gets or sets id of pupil
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of pupil
        /// </summary>
        [MaxLength(64)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets surname of pupil
        /// </summary>
        [MaxLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets birthdate of pupil
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets gender of pupil
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets phone number of pupil
        /// </summary>
        [MaxLength(64)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets address of pupil
        /// </summary>
        [MaxLength(64)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city, where pupil lives
        /// </summary>
        [MaxLength(64)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name of school, where pupil study
        /// </summary>
        [MaxLength(256)]
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the grade of study of pupil
        /// </summary>
        public byte Grade { get; set; }

        /// <summary>
        /// Gets or sets the language of education
        /// </summary>
        public CourseLanguage CourseLanguage { get; set; }

        /// <summary>
        /// Gets or sets shift of study
        /// </summary>
        public Shift Shift { get; set; }
    }
}
