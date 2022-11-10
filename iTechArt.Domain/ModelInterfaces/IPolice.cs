using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        /// <summary>
        /// Gets Police Officers Id.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets Police Officers Firstname.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets Police Officers Lastname.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Gets Police Officers email address.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets Police Officers gender.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets Police Officers address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets Police Officers job title.
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Gets Police Officers salary in US dollars with 2 double precision.
        /// </summary>
        public double Salary { get; }
    }
}
