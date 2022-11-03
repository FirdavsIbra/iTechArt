using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Service.DTOs
{
    public sealed class PupilForCreationDto : IPupil
    {
        /// <summary>
        /// Gets or sets id of pupil
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the name of pupil
        /// </summary>
        [MaxLength(64)]
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets or sets surname of pupil
        /// </summary>
        [MaxLength(64)]
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets or sets birthdate of pupil
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets or sets gender of pupil
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets or sets phone number of pupil
        /// </summary>
        [MaxLength(64)]
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Gets or sets address of pupil
        /// </summary>
        [MaxLength(64)]
        public string Address { get; internal set; }

        /// <summary>
        /// Gets or sets the city, where pupil lives
        /// </summary>
        [MaxLength(64)]
        public string City { get; internal set; }

        /// <summary>
        /// Gets or sets the name of school, where pupil study
        /// </summary>
        [MaxLength(256)]
        public string SchoolName { get; internal set; }

        /// <summary>
        /// Gets or sets the grade of study of pupil
        /// </summary>
        public byte Grade { get; internal set; }

        /// <summary>
        /// Gets or sets the language of education
        /// </summary>
        public CourseLanguage CourseLanguage { get; internal set; }

        /// <summary>
        /// Gets or sets shift of study
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
