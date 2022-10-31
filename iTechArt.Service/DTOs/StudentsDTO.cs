using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.DTOs
{
    internal sealed class StudentsDTO:IStudents
    {
        /// <summary>
        /// Gets/Sets Id of business model entities
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets/Sets First name of student
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets/Sets Last name of student
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets/Sets Email of student
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Gets/Sets Password of student
        /// </summary>
        public string Password { get; internal set; }

        /// <summary>
        /// Gets/Sets String value majority, field of study
        /// </summary>
        public string Majority { get; internal set; }

        /// <summary>
        /// Gets/Sets boolean Gender entity of student
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets/Sets Birthday of student
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Gets/Sets Name of university of student
        /// </summary>
        public string University { get; internal set; }
    }
}
