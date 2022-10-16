using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;

namespace iTechArt.Domain.Entities.Pupils
{
    public sealed class Pupil : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string SchoolNumber { get; set; }

        public byte Grade { get; set; }

        public CourseLanguage CourseLanguage { get; set; }

        public Shift Shift { get; set; }
    }
}
