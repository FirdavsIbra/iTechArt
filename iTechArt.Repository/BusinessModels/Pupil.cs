using iTechArt.Domain.Enums;
using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.Text.Json.Serialization;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Pupil : IPupil
    {
        /// <summary>
        /// Gets or sets id of pupil.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the name of pupil.
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets or sets surname of pupil.
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets or sets birthdate of pupil.
        /// </summary>
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets or sets gender of pupil.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets or sets phone number of pupil.
        /// </summary>
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Gets or sets address of pupil.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Gets or sets the city, where pupil lives.
        /// </summary>
        public string City { get; internal set; }

        /// <summary>
        /// Gets or sets the name of school, where pupil study.
        /// </summary>
        public string SchoolName { get; internal set; }

        /// <summary>
        /// Gets or sets the grade of study of pupil.
        /// </summary>
        public int Grade { get; internal set; }

        /// <summary>
        /// Gets or sets the language of education.
        /// </summary>
        public CourseLanguage CourseLanguage { get; internal set; }

        /// <summary>
        /// Gets or sets shift of study.
        /// </summary>
        public Shift Shift { get; internal set; }
    }
}
