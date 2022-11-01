using CsvHelper.Configuration.Attributes;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.DTOs
{
    public class PoliceDto : IPolice
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        [Index(0)]
        public string Name { get; internal set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        [Index(1)]
        public string Surname { get; internal set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        [Index(2)]
        public string Email { get; internal set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        [Index(3)]
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        [Index(4)]
        public string Address { get; internal set; }

        /// <summary>
        /// Police Officers job title
        /// </summary> 
        [Index(5)]
        public string JobTitle { get; internal set; }

        /// <summary>
        /// Police Officers salary in US dollars with 2 double precision
        /// </summary>
        [Index(6)]
        public double Salary { get; internal set; }
    }
}
