using iTechArt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.Dtos
{
    public sealed class PoliceDto
    {
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
        /// Police Officers salary in US dollars with 2 double precision
        /// </summary>
        public double Salary { get; internal set; }
    }
}
