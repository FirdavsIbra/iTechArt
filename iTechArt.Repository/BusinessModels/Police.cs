using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal class Police : IPolice
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string JobTitle { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
