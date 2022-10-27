using iTechArt.Domain.Enums;
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
        public string Name { get; internal set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string Surname { get; internal set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Police Officers job title
        /// </summary> 
        public string JobTitle { get; internal set; }

        /// <summary>
        /// Police Officers salary
        /// </summary>
        public double Salary { get; internal set; }
    }
}
