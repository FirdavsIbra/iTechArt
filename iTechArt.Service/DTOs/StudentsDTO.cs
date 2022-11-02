using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iTechArt.Service.DTOs
{
    [XmlRoot("record")]
    public sealed class StudentsDTO:IStudents
    {
        /// <summary>
        /// Gets/Sets Id of business model entities
        /// </summary>
        public long Id { get;  set; }

        /// <summary>
        /// Gets/Sets First name of student
        /// </summary>
        public string FirstName { get;  set; }

        /// <summary>
        /// Gets/Sets Last name of student
        /// </summary>
        public string LastName { get;  set; }

        /// <summary>
        /// Gets/Sets Email of student
        /// </summary>
        public string Email { get;  set; }

        /// <summary>
        /// Gets/Sets Password of student
        /// </summary>
        public string Password { get;  set; }

        /// <summary>
        /// Gets/Sets String value majority, field of study
        /// </summary>
        public string Majority { get;  set; }

        /// <summary>
        /// Gets/Sets boolean Gender entity of student
        /// </summary>
        public Gender Gender { get;  set; }

        /// <summary>
        /// Gets/Sets Birthday of student
        /// </summary>
        public DateTime DateOfBirth { get;  set; }

        /// <summary>
        /// Gets/Sets Name of university of student
        /// </summary>
        public string University { get;  set; }
    }
}
