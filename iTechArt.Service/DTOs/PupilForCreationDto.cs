using iTechArt.Domain.Enums;

namespace iTechArt.Service.DTOs
{
    public sealed class PupilForCreationDto
    {
        /// <summary>
        /// Name of pupil
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of pupil
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birthdate of pupil
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gender of pupil
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Phone number of pupil
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Address of pupil
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city, where pupil lives
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The name of school, where pupil study
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// The grade of study of pupil
        /// </summary>
        public byte Grade { get; set; }

        /// <summary>
        /// The language of education
        /// </summary>
        public CourseLanguage CourseLanguage { get; set; }

        /// <summary>
        /// The shift of study
        /// </summary>
        public Shift Shift { get; set; }
    }
}
