using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Domain.Entities.Pupils
{
    public class School
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public ushort SchoolNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, 5)]
        public SchoolType SchoolType { get; set; }

    }
}