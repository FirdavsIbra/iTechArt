using CsvHelper.Configuration.Attributes;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public long Id { get; set; } 

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Police Officers job title
        /// </summary> 
        public string JobTitle { get; set; }

        /// <summary>
        /// Police Officers salary in US dollars with 2 double precision
        /// </summary>
        public double Salary { get; set; }
    }
}
