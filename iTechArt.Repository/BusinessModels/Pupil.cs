using iTechArt.Database.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Pupil : IPupil
    {
        /// <summary>
        /// Id of pupil
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Name of pupil
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Surname of pupil
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Birthdate of pupil
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Gender of pupil
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Phone number of pupil
        /// </summary>
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Address of pupil
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// The city, where pupil lives
        /// </summary>
        public string City { get; internal set; }

        /// <summary>
        /// The name of school, where pupil study
        /// </summary>
        public string SchoolName { get; internal set; }

        /// <summary>
        /// The grade of study of pupil
        /// </summary>
        public byte Grade { get; internal set; }

        /// <summary>
        /// The language of education
        /// </summary>
        public CourseLanguage CourseLanguage { get; internal set; }

        /// <summary>
        /// The shift of study
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
