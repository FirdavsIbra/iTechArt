using iTechArt.Database.Enums;

namespace iTechArt.Database.Entities.Students
{
    public sealed class Students
    {

        /// <summary>
        /// Gets/Sets ID in Table
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets/Sets First name of Student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets/Sets Last name of student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets/Sets Email of student
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets/Sets Password of student
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets/Sets Major of student study
        /// </summary>
        public string Majority { get; set; }

        /// <summary>
        /// Gets/Sets Gender enum
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets/Sets Birthday of study
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets/Sets String value of University
        /// </summary>
        public string University { get; set; }
    }
}
