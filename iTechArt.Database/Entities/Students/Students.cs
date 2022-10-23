using iTechArt.Database.DbContexts;
using iTechArt.Database.Enums;

namespace iTechArt.Database.Entities.Students
{
    public sealed class Students : IDbModel
    {
        public long Id { get; set; }

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
