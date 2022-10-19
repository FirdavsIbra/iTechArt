using iTechArt.Database.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPupil
    {
        public long Id { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime DateOfBirth { get; }

        public Gender Gender { get; }

        public string PhoneNumber { get; }

        public string Address { get; }

        public string City { get; }

        public string SchoolNumber { get; }

        public byte Grade { get; }

        public CourseLanguage CourseLanguage { get; }

        public Shift Shift { get; }
    }
}
