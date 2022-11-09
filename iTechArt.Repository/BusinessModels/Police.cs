using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Police : IPolice
    {
        /// <summary>
        /// Gets and Internal Sets Police Officers Id.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers Firstname.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers Lastname.
        /// </summary>
        public string Surname { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers email address.
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers gender.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers address.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers job title.
        /// </summary> 
        public string JobTitle { get; internal set; }

        /// <summary>
        /// Gets and Internal Sets Police Officers salary in US dollars with 2 double precision.
        /// </summary>
        public double Salary { get; internal set; }
    }
}
