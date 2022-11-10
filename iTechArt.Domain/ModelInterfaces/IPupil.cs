using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPupil
    {
        /// <summary>
        /// Gets id if pupil.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets name of pupil.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets surname of pupil.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets birthdate of pupil.
        /// </summary>
        public DateOnly DateOfBirth { get; }

        /// <summary>
        /// Gets gender of pupil.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets phone number of pupil.
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Gets address of pupil.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets a city, where pupil lives.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets name of school, where pupil study.
        /// </summary>
        public string SchoolName { get; }

        /// <summary>
        /// Gets grade of study of pupil.
        /// </summary>
        public int Grade { get; }

        /// <summary>
        /// Gets a language of education.
        /// </summary>
        public CourseLanguage CourseLanguage { get; }

        /// <summary>
        /// Gets a shift of study.
        /// </summary>
        public Shift Shift { get; }
    }
}
