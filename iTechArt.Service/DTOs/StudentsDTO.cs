using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System.Xml.Serialization;

namespace iTechArt.Service.DTOs
{
    [XmlRoot("record")]
    public sealed class StudentsDTO: IStudents
    {
        /// <summary>
        /// Gets or sets id of student
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Gets or sets name of student
        /// </summary>
        public string FirstName { get;  set; }

        /// <summary>
        /// Gets or sets last name of student
        /// </summary>
        public string LastName { get;  set; }

        /// <summary>
        /// Gets or sets email of student
        /// </summary>
        public string Email { get;  set; }

        /// <summary>
        /// Gets or sets password of student
        /// </summary>
        public string Password { get;  set; }

        /// <summary>
        /// Gets or sets string value majority, field of study
        /// </summary>
        public string Majority { get;  set; }

        /// <summary>
        /// Gets or sets gender of student
        /// </summary>
        public Gender Gender { get;  set; }

        /// <summary>
        /// Gets or sets birth date of student
        /// </summary>
        public DateTime DateOfBirth { get;  set; }

        /// <summary>
        /// Gets or sets name of university of student
        /// </summary>
        public string University { get;  set; }
    }
}
