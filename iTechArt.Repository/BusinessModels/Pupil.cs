using iTechArt.Database.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Pupil : IPupil
    {
        public long Id { get; set; }

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
