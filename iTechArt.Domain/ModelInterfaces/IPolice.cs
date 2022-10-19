namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        public long Id { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Gender { get; }

        public string Address { get; }

        public string JobTitle { get; }

        public double Height { get; }

        public double Weight { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
