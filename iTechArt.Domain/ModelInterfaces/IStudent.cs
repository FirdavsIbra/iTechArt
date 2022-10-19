using iTechArt.Database.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IStudent
    {
        public long Id { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public string Majority { get; }

        public Gender Gender { get; }

        public DateTime DateOfBirth { get; }

        public string University { get; }
    }
}
