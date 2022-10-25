using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPupil
    {
        /// <summary>
        /// Id if pupil
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Name of pupil
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Surname of pupil
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Birthdate of pupil
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// Gender of pupil
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Phone number of pupil
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Address of pupil
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// The city, where pupil lives
        /// </summary>
        public string City { get; }

        /// <summary>
        /// The name of school, where pupil study
        /// </summary>
        public string SchoolName { get; }

        /// <summary>
        /// The grade of study of pupil
        /// </summary>
        public byte Grade { get; }

        /// <summary>
        /// The language of education
        /// </summary>
        public CourseLanguage CourseLanguage { get; }

        /// <summary>
        /// The shift of study
        /// </summary>
        public Shift Shift { get; }
    }
}
