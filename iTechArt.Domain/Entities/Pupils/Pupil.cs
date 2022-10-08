using iTechArt.Domain.Entities.Commons;
using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Domain.Entities.Pupils
{
    public class Pupil : Auditable
    {

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [Range(1, 2)]
        public Gender Gender { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public long SchoolId { get; set; }
        
        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }
        
        [Required]
        [Range(1, 11)]
        public byte Grade { get; set; }
        
        [Required]
        [Range(1, 3)]
        public CourseLanguage CourseLanguage { get; set; }
        
        [Required]
        [Range(1, 2)]
        public Shift Shift { get; set; }
    }
}
