namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Police Officers job title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Police Officers height in cm with 2 precision (like 170.24)
        /// </summary>
        public double HeightInCm { get; set; }

        /// <summary>
        /// Police Officers weight in kg with 2 precision (like 75.34)
        /// </summary>
        public double WeightInKg { get; set; }

        /// <summary>
        /// Police Officers starting date
        /// </summary>
        public DateTime JobStartDate { get; set; }
    }
}
