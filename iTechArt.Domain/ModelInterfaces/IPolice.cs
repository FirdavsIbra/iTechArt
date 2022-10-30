using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Police Officers job title
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Police Officers salary in US dollars with 2 double precision
        /// </summary>
        public double Salary { get; }
    }
}
