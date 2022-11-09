using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.Dtos
{
    public class PoliceDto : IPolice
    {
        /// <summary>
        /// Gets and Sets Police Officers Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers Firstname.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers Lastname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers job title.
        /// </summary> 
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers salary in US dollars with 2 double precision.
        /// </summary>
        public double Salary { get; set; }
    }
}
