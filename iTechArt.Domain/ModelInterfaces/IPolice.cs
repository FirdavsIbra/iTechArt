namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get;}

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public string Gender { get; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Police Officers job title
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Police Officers height in cm with 2 precision (like 170.24)
        /// </summary>
        public double HeightInCm { get; }

        /// <summary>
        /// Police Officers weight in kg with 2 precision (like 75.34)
        /// </summary>
        public double WeightInKg { get; }
    }
}
