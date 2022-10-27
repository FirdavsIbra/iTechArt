using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Police : IPolice
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public string Gender { get; internal set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Police Officers job title
        /// </summary> 
        public string JobTitle { get; internal set; }

        /// <summary>
        /// Police Officers height in cm with 2 precision (like 170.24)
        /// </summary>
        public double HeightInCm { get; internal set; }

        /// <summary>
        /// Police Officers weight in kg with 2 precision (like 75.34)
        /// </summary>
        public double WeightInKg { get; internal set; }
    }
}
