using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Domain.Entities.Pupils
{
    public class School : Auditable
    {
        [Required]
        public ushort SchoolNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, 5)]
        public SchoolType SchoolType { get; set; }

    }
}