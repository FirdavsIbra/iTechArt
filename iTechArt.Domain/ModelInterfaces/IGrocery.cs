using iTechArt.Database.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IGrocery
    {
        public long Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime DateOfBirth { get; }

        public Gender Gender { get; }

        public string Email { get; }

        public string JobTitle { get; }

        public string DepartmentRetail { get; }

        public double Salary { get; }
    }
}
