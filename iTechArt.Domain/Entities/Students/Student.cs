using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;

namespace iTechArt.Domain.Entities.Students
{
    public abstract class Student : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Majority { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string University { get; set; }
    }
}
