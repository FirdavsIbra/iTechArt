using iTechArt.Database.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Grocery : IGrocery
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }

        public string DepartmentRetail { get; set; }

        public double Salary { get; set; }
    }
}
